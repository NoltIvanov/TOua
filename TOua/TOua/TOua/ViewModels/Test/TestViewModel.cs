using TransportAndOwner.ViewModels.Base;

namespace TransportAndOwner.ViewModels.Test {
    public sealed class TestViewModel : ViewModelBase {

        public TestViewModel() {
            DialogService.ToastAsync("hello");
        }
    }
}
