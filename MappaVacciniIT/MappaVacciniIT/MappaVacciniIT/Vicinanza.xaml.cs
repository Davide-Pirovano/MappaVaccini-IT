using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;
using System.Threading;
using Xamarin.Forms.Xaml;

namespace MappaVacciniIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vicinanza : ContentPage
    {

        public string[] posizione = new string[3];
        public Vicinanza()
        {
            InitializeComponent();
            GetCurrentLocation();
        }


        CancellationTokenSource cts;

        async void GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                if (location != null)
                {
                    posizione[0] = location.Latitude.ToString();
                    posizione[1] = location.Longitude.ToString();
                    posizione[2] = location.Altitude.ToString();
                }
            }
            catch { }

        }

        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }
    }
}