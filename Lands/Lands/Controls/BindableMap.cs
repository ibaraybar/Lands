namespace Lands.Controls
{
   using System.Collections.Generic;
   using System.Collections.ObjectModel;
   using System.Collections.Specialized;
   using Xamarin.Forms;
   using Xamarin.Forms.Maps;

   public class BindableMap : Map
   {
      private List<Position> routeCoordinates = new List<Position>();
      public List<Position> RouteCoordinates
      {
         get
         {
            return routeCoordinates;
         }
         set
         {
            routeCoordinates = value;
         }
      }

      public static readonly BindableProperty RouteCoordinatesProperty = BindableProperty.Create(
          nameof(RouteCoordinates),
          typeof(ObservableCollection<Position>),
          typeof(BindableMap),
          new ObservableCollection<Position>(),
          BindingMode.TwoWay,
          propertyChanged: (b, o, n) =>
          {
             var bindable = (BindableMap)b;
             var collection = (ObservableCollection<Position>)n;
             foreach (var item in collection)
             {
                bindable.RouteCoordinates.Add(item);
             }
             collection.CollectionChanged += (sender, e) =>
             {
                Device.BeginInvokeOnMainThread(() =>
                {
                   switch (e.Action)
                   {
                      case NotifyCollectionChangedAction.Add:
                      case NotifyCollectionChangedAction.Replace:
                      case NotifyCollectionChangedAction.Remove:
                         if (e.OldItems != null)
                            foreach (var item in e.OldItems)
                               bindable.RouteCoordinates.Remove((Position)item);
                         if (e.NewItems != null)
                            foreach (var item in e.NewItems)
                               bindable.RouteCoordinates.Add((Position)item);
                         break;
                      case NotifyCollectionChangedAction.Reset:
                         bindable.RouteCoordinates.Clear();
                         break;
                   }
                });
             };
          }
      );

      public static readonly BindableProperty MapPinsProperty = BindableProperty.Create(
          nameof(Pins),
          typeof(ObservableCollection<Pin>),
          typeof(BindableMap),
          new ObservableCollection<Pin>(),
          propertyChanged: (b, o, n) =>
          {
             var bindable = (BindableMap)b;
             bindable.Pins.Clear();
             var collection = (ObservableCollection<Pin>)n;
             foreach (var item in collection)
                bindable.Pins.Add(item);
             collection.CollectionChanged += (sender, e) =>
             {
                Device.BeginInvokeOnMainThread(() =>
                {
                   switch (e.Action)
                   {
                      case NotifyCollectionChangedAction.Add:
                      case NotifyCollectionChangedAction.Replace:
                      case NotifyCollectionChangedAction.Remove:
                         if (e.OldItems != null)
                            foreach (var item in e.OldItems)
                               bindable.Pins.Remove((Pin)item);
                         if (e.NewItems != null)
                            foreach (var item in e.NewItems)
                               bindable.Pins.Add((Pin)item);
                         break;
                      case NotifyCollectionChangedAction.Reset:
                         bindable.Pins.Clear();
                         break;
                   }
                });
             };
          });

      public IList<Pin> MapPins { get; set; }
      public static readonly BindableProperty MapPositionProperty = BindableProperty.Create(
              nameof(MapPosition),
              typeof(Position),
          typeof(BindableMap),
              new Position(0, 0),
              propertyChanged: (b, o, n) =>
              {
                 ((BindableMap)b).MoveToRegion(MapSpan.FromCenterAndRadius(
                                       (Position)n, Distance.FromKilometers(400)));
              });
      public Position MapPosition { get; set; }
   }
}
