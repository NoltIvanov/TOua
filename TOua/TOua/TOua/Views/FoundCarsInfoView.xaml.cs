using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOua.Views.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TOua.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoundCarsInfoView : ContentPageBaseView {
        public FoundCarsInfoView() {
            InitializeComponent();
        }
    }
}