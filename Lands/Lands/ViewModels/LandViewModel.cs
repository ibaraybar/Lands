namespace Lands.ViewModels
{
   using Lands.Models;
   using System.Collections.Generic;
   using System.Collections.ObjectModel;
   using System.Linq;
   using Xamarin.Forms.Maps;

   public class LandViewModel : BaseViewModel
    {
      #region Attributes
      private ObservableCollection<Border> borders;
      private ObservableCollection<Currency> currencies;
      private ObservableCollection<Language> languages;
      private ObservableCollection<Pin> landPins;
      private Position landPosition;
      #endregion

      #region Properties
      public Land Land { get; set; }

      public ObservableCollection<Border> Borders
      {
         get { return this.borders; }
         set { SetValue(ref this.borders, value); }
      }

      public ObservableCollection<Currency> Currencies
      {
         get { return this.currencies; }
         set { SetValue(ref this.currencies, value); }
      }

      public ObservableCollection<Language> Languages
      {
         get { return this.languages; }
         set { SetValue(ref this.languages, value); }
      }

      public ObservableCollection<Pin> LandPins
      {
         get { return this.landPins; }
         set { this.landPins = value; OnPropertyChanged("LandPins"); }
      }

      public Position LandPosition
      {
         get { return this.landPosition; }
         set { this.landPosition = value; OnPropertyChanged("LandPosition"); }
      }
      #endregion

      #region Constructors
      public LandViewModel(Land land)
      {
         this.Land = land;
         this.LoadBorders();
         this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
         this.Languages = new ObservableCollection<Language>(this.Land.Languages);
         this.LandPosition = new Position(this.Land.Latlng[0], this.Land.Latlng[1]);
         //this.LandPosition = new Position(10.0, -78.0);
         var pin = new Pin
         {
            Position = this.LandPosition,
            Label = this.Land.Name,
            Type = PinType.Place
         };
         this.LandPins = new ObservableCollection<Pin>();
         this.LandPins.Add(pin);
      }
      #endregion

      #region Methods
      private void LoadBorders()
      {
         this.Borders = new ObservableCollection<Border>();
         foreach (var border in this.Land.Borders)
         {
            var land = MainViewModel.GetInstance().LandsList.Where(
               l => l.Alpha3Code == border).FirstOrDefault();
            if (land != null)
            {
               this.Borders.Add(new Border
               {
                  Code = land.Alpha3Code,
                  Name = land.Name
               });
            }
         }
      }
      #endregion

      //#region Singleton
      //private static LandViewModel instance;

      //public static LandViewModel GetInstance()
      //{
      //   if (instance == null)
      //   {
      //      return new LandViewModel(land);
      //   }

      //   return instance;
      //}
      //#endregion
   }
}
