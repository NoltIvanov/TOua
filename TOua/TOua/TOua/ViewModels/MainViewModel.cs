using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TransportAndOwner.ViewModels.Base;
using TransportAndOwner.ViewModels.Test;
using Xamarin.Forms;

namespace TransportAndOwner.ViewModels {
    public sealed class MainViewModel : ViewModelBase {

        string _name = "Hello world";
        public string Name {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ICommand TestCommand => new Command(async () => await OnTestAsync());

        /// <summary>
        ///     ctor().
        /// </summary>
        public MainViewModel() {

        }

        public override Task InitializeAsync(object navigationData) {
            return base.InitializeAsync(navigationData);
        }

        private async Task OnTestAsync() {
            await NavigationService.NavigateToAsync<TestViewModel>();
        }
    }
}
