﻿using Android.Content;
using Android.Graphics;
using Android.Views;
using System.ComponentModel;
using TOua.Controls;
using TOua.Droid.Renderers;
using TOua.Droid.Renderers.Helpers;
using TOua.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryExtended), typeof(EntryExtendedRenderer))]
namespace TOua.Droid.Renderers {
    public class EntryExtendedRenderer : EntryRenderer {

        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        private BorderRenderer _renderer;

        public EntryExtendedRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null) {
                return;
            }

            Control.Gravity = DefaultGravity;

            EntryExtended entryEx = Element as EntryExtended;

            UpdateBackground(entryEx);
            UpdatePadding(entryEx);
            UpdateTextAlighnment(entryEx);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null) {
                return;
            }

            EntryExtended entryEx = Element as EntryExtended;

            if (e.PropertyName == EntryExtended.BorderWidthProperty.PropertyName ||
                e.PropertyName == EntryExtended.BorderColorProperty.PropertyName ||
                e.PropertyName == EntryExtended.BorderRadiusProperty.PropertyName ||
                e.PropertyName == EntryExtended.BackgroundColorProperty.PropertyName) {
                UpdateBackground(entryEx);
            }
            else if (e.PropertyName == EntryExtended.LeftPaddingProperty.PropertyName ||
                e.PropertyName == EntryExtended.RightPaddingProperty.PropertyName) {
                UpdatePadding(entryEx);
            }
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName) {
                UpdateTextAlighnment(entryEx);
            }
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            if (disposing) {
                if (_renderer != null) {
                    _renderer.Dispose();
                    _renderer = null;
                }
            }
        }

        private void UpdateBackground(EntryExtended entryEx) {
            if (_renderer != null) {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(entryEx.BorderColor, entryEx.BackgroundColor, entryEx.BorderWidth, entryEx.BorderRadius);
            //Control.Background = new Android.Graphics.Drawables.ColorDrawable(BaseSingleton<ValuesResolver>.Instance.ResolveNativeColor(entryEx.BackgroundColor));
            //Control.Background.SetColorFilter(BaseSingleton<ValuesResolver>.Instance.ResolveNativeColor(entryEx.BackgroundColor), PorterDuff.Mode.SrcAtop);
            //Control.Background.SetColorFilter(Android.Graphics.Color.ParseColor("#fefefe"), PorterDuff.Mode.SrcAtop);
        }

        private void UpdatePadding(EntryExtended entryEx) {
            Control.SetPadding((int)Context.ToPixels(entryEx.LeftPadding), 0,
                (int)Context.ToPixels(entryEx.RightPadding), 0);
        }

        private void UpdateTextAlighnment(EntryExtended entryEx) {
            GravityFlags gravity = DefaultGravity;

            switch (entryEx.HorizontalTextAlignment) {
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }

            Control.Gravity = gravity;
        }
    }
}