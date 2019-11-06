using QPlanApp.Helpers;
using QPlanApp.ViewModels;
using Xamarin.Forms;

namespace QPlanApp.Views
{
    public partial class RestaurantsView : ContentPage
    {
        RestaurantsViewModel viewModel;

        public RestaurantsView()
        {
            if (Device.RuntimePlatform != Device.iOS)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }

            NavigationPage.SetBackButtonTitle(this, string.Empty);

            InitializeComponent();

            //MapHelper.CenterMapInDefaultLocation(this.Map);

            BindingContext = viewModel = new RestaurantsViewModel();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            StatusBarHelper.Instance.MakeTranslucentStatusBar(false);
            await this.viewModel.InitializeAsync();
        }
    }
}