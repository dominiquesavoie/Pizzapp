using System;
using Cirrious.CrossCore.Touch.Views;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using CoreLocation;
using MapKit;
using AddressBookUI;
using System.Linq;

namespace Pizzapp
{
    public class GeocoderViewControllerAdapter: MvxBaseViewControllerAdapter
    {
        readonly CLGeocoder _geocoder;
        readonly Action<string> _addressChanged;

        public GeocoderViewControllerAdapter (MvxViewController viewController, MKMapView mapView, Action<string> addressChanged)
            :base(viewController)
        {
            _geocoder = new CLGeocoder ();
            _addressChanged = addressChanged;
            mapView.RegionChanged += MapView_RegionChanged;
            mapView.SetRegion (new MapKit.MKCoordinateRegion (new CoreLocation.CLLocationCoordinate2D (45.5316085, -73.6227476), new MapKit.MKCoordinateSpan (0.01, 0.01)), animated: true);


        }

        void MapView_RegionChanged (object sender, MKMapViewChangeEventArgs e)
        {
            var mapView = (MKMapView)sender;
            _geocoder.ReverseGeocodeLocation(new CLLocation(mapView.CenterCoordinate.Latitude, mapView.CenterCoordinate.Longitude), (placemarks, error) => 
                {
                    if(placemarks.Any())
                    {
                        var address = ABAddressFormatting.ToString(placemarks[0].AddressDictionary, addCountryName: false);
                        _addressChanged.Invoke(address);
                    }
                });
        }
    }
}

