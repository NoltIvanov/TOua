using Xamarin.Forms;

namespace TOua.Controls.ActionBars {
    public class ActionBarBaseView : ContentView {
        private static readonly string _BINDING_CONTEXT_SOURCE_PATH = "ActionBarViewModel";

        public ActionBarBaseView() {
            SetBinding(BindingContextProperty, new Binding(_BINDING_CONTEXT_SOURCE_PATH));
        }
    }
}