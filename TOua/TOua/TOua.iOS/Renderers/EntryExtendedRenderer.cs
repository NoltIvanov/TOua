﻿using TOua.Controls;
using TOua.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryExtended), typeof(EntryExtendedRenderer))]
namespace TOua.iOS.Renderers {
    public class EntryExtendedRenderer : EntryRenderer {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            if (Control != null) {
                DisableNativeBorder();
            }

            if (e.OldElement != null) {
                // Unsubscribe from event handlers and cleanup any resources
            }

            if (e.NewElement != null) {
                // Configure the control and subscribe to event handlers
            }
        }

        private void DisableNativeBorder() {
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}