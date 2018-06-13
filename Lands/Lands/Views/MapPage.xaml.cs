namespace Lands.Views
{
   using System;
   using Lands.ViewModels;
   using Xamarin.Forms;
   using Xamarin.Forms.Maps;
   using Xamarin.Forms.Xaml;

   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MapPage : ContentPage
   {
      public MapPage()
      {
         InitializeComponent();

         //PinToLandCenter();
      }

      //async void PinToLandCenter()
      //{
      //   var vm = BindingContext as LandViewModel;
      //   var pinLand = vm.LandPin;
      //   LandMap.Pins.Add(pinLand);
      //   LandMap.MoveToRegion(MapSpan.FromCenterAndRadius(pinLand.Position, Distance.FromKilometers(1)));
      //}
   }
}