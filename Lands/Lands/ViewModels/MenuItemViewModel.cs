namespace Lands.ViewModels
{
   using GalaSoft.MvvmLight.Command;
   using Lands.Helpers;
   using Lands.Views;
   using System.Windows.Input;
   using Xamarin.Forms;

   public class MenuItemViewModel
    {
      #region Properties
      public string Icon { get; set; }

      public string Title { get; set; }

      public string PageName { get; set; }
      #endregion

      #region Commands
      public ICommand NavigateCommand
      {
         get
         {
            return new RelayCommand(Navigate);
         }
      }

      private void Navigate()
      {
         App.Master.IsPresented = false;

         if (this.PageName == "LoginPage")
         {
            Settings.IsRemembered = "false";
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = null;
            mainViewModel.User = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
         }

         if (this.PageName == "MyProfilePage")
         {
            MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
            App.Navigator.PushAsync(new MyProfilePage());
         }
      }
      #endregion
   }
}
