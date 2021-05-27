using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MappaVacciniIT.Droid;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android.Factories;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;


namespace MappaVacciniIT.Droid
{
    class BitmapConfig : IBitmapDescriptorFactory
    {
        public AndroidBitmapDescriptor ToNative(BitmapDescriptor descriptor)
        {
            int iconId = 0;
            switch (descriptor.Id)
            {
                case "ping":
                    iconId = Resource.Drawable.pin;
                    break;
                case "milan":
                    iconId = Resource.Drawable.duomodimilano;
                    break;
                case "liguria":
                    iconId = Resource.Drawable.liguria;
                    break;
                case "emilia":
                    iconId = Resource.Drawable.lasagna;
                    break;
                case "venezia":
                    iconId = Resource.Drawable.venezia;
                    break;
                case "trentino":
                    iconId = Resource.Drawable.trentino;
                    break;
                case "lazio":
                    iconId = Resource.Drawable.colosseum;
                    break;
            }

            return AndroidBitmapDescriptorFactory.FromResource(iconId);
        }
    }
}