using Android.Content;
using System.ComponentModel;
using TOua.Controls;
using TOua.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LabelExtended), typeof(LabelExtendedRenderer))]
namespace TOua.Droid.Renderers {
    public class LabelExtendedRenderer : LabelRenderer {

        public LabelExtendedRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e) {
            base.OnElementChanged(e);

            UseLineHeightMultiplier();
            SetLetterSpacing();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == LabelExtended.LineHeightProperty.PropertyName) {
                UseLineHeightMultiplier();
                UpdateLayout();
            }
            else if (e.PropertyName == LabelExtended.LetterSpacingProperty.PropertyName) {
                SetLetterSpacing();
                UpdateLayout();
            }
        }

        private void UseLineHeightMultiplier() {
            Control.SetLineSpacing(0, ((LabelExtended)Element).LineHeight);
        }

        private void SetLetterSpacing() {
            Control.LetterSpacing = ((LabelExtended)Element).LetterSpacing;
        }
    }
}