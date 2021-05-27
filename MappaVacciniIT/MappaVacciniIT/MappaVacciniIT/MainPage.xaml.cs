using Newtonsoft.Json;
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

namespace MappaVacciniIT
{
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();
        static string url = "https://raw.githubusercontent.com/italia/covid19-opendata-vaccini/master/dati/somministrazioni-vaccini-summary-latest.json";
        public Dictionary<string, int> totRegioni = new Dictionary<string, int>() {
                {"Lombardia",0 },
                {"Veneto",0 },
                {"Lazio",0 },
                {"Marche",0 },
                {"Abruzzo",0 },
                {"Toscana",0 },
                {"Emilia-Romagna",0 },
                {"Piemonte",0 },
                {"Friuli-Venezia Giulia",0 },
                {"Campania",0 },
                {"Basilicata",0 },
                {"Molise",0 },
                {"Umbria",0 },
                {"Sardegna",0 },
                {"Sicilia",0 },
                {"Puglia",0 },
                {"Valle d'Aosta",0 },
                {"Liguria",0 },
                {"Calabria",0 },
                {"Trentino",0 },
            };
        public string[] posizione = new string[3];
        public MainPage()
        {
            InitializeComponent();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.870000, 12.600000), Distance.FromKilometers(500)));
            MyMap.UiSettings.RotateGesturesEnabled = false;
            try
            {
                Get();
            }
            catch { }

            GetCurrentLocation();
        }

        async void Get()
        {
            string dati = await client.GetStringAsync(url);
            DeserializzazioneVaccini dV = JsonConvert.DeserializeObject<DeserializzazioneVaccini>(dati);
            foreach (var item in dV.data)
            {

                if (item.nome_area == "Lombardia")
                {
                    totRegioni["Lombardia"] += item.totale;
                }
                else if (item.nome_area == "Veneto")
                {
                    totRegioni["Veneto"] += item.totale;
                }
                else if (item.nome_area == "Piemonte")
                {
                    totRegioni["Piemonte"] += item.totale;
                }
                else if (item.nome_area == "Abruzzo")
                {
                    totRegioni["Abruzzo"] += item.totale;
                }
                else if (item.nome_area == "Marche")
                {
                    totRegioni["Marche"] += item.totale;
                }
                else if (item.nome_area == "Lazio")
                {
                    totRegioni["Lazio"] += item.totale;
                }
                else if (item.nome_area == "Campania")
                {
                    totRegioni["Campania"] += item.totale;
                }
                else if (item.nome_area == "Provincia Autonoma Trento")
                {
                    totRegioni["Trentino"] += item.totale;
                }
                else if (item.nome_area == "Umbria")
                {
                    totRegioni["Umbria"] += item.totale;
                }
                else if (item.nome_area == "Emilia-Romagna")
                {
                    totRegioni["Emilia-Romagna"] += item.totale;
                }
                else if (item.nome_area == "Molise")
                {
                    totRegioni["Molise"] += item.totale;
                }
                else if (item.nome_area == "Friuli-Venezia Giulia")
                {
                    totRegioni["Friuli-Venezia Giulia"] += item.totale;
                }
                else if (item.nome_area == "Toscana")
                {
                    totRegioni["Toscana"] += item.totale;
                }
                else if (item.nome_area == "Sicilia")
                {
                    totRegioni["Sicilia"] += item.totale;
                }
                else if (item.nome_area == "Basilicata")
                {
                    totRegioni["Basilicata"] += item.totale;
                }
                else if (item.nome_area == "Puglia")
                {
                    totRegioni["Puglia"] += item.totale;
                }
                else if (item.nome_area == "Sardegna")
                {
                    totRegioni["Sardegna"] += item.totale;
                }
                else if (item.nome_area == @"Valle d'Aosta / Vallée d'Aoste")
                {
                    totRegioni["Valle d'Aosta"] += item.totale;
                }
                else if (item.nome_area == @"Liguria")
                {
                    totRegioni["Liguria"] += item.totale;
                }
                else if (item.nome_area == @"Calabria")
                {
                    totRegioni["Calabria"] += item.totale;
                }
                else if (item.nome_area == @"Provincia Autonoma Bolzano / Bozen")
                {
                    totRegioni["Trentino"] += item.totale;
                }
            }
            foreach (var item in totRegioni)
            {
                if (item.Key == "Lombardia")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString()+" vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(45.466944, 9.19)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if(item.Key == "Toscana")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(43.771389, 11.254167)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Piemonte")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(45.066667, 7.7)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Campania")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(40.833333, 14.25)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Molise")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(41.561, 14.6684)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Marche")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(43.616667, 13.516667)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Liguria")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(44.407186, 8.933983)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Veneto")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(45.439722, 12.331944)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Lazio")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(41.893056, 12.482778)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Emilia-Romagna")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(44.493889, 11.342778)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Friuli-Venezia Giulia")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(45.650278, 13.770278)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Sardegna")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(39.216667, 9.116667)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Sicilia")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(38.115658, 13.361262)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Puglia")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(41.125278, 16.866667)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Umbria")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(43.1121, 12.3888)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Calabria")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(38.91, 16.5875)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Basilicata")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Generic,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(40.633333, 15.8)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Valle d'Aosta")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.SavedPin,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(45.737222, 7.320556),
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Trentino")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(46.066667, 11.116667)
                    };
                    MyMap.Pins.Add(pin);
                }
                else if (item.Key == "Abruzzo")
                {
                    Pin pin = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Icon = BitmapDescriptorFactory.FromBundle("ping"),
                        Position = new Position(42.354008, 13.391992)
                    };
                    MyMap.Pins.Add(pin);
                }
            }
    }

        public string mapType = "Street";
        private void MapType_Clicked(object sender, EventArgs e)
        {
            if (mapType=="Street")
            {
                MyMap.MapType = Xamarin.Forms.GoogleMaps.MapType.Satellite;
                mapType = "Satellite";
            }
            else
            {
                MyMap.MapType = Xamarin.Forms.GoogleMaps.MapType.Street;
                mapType = "Street";
            }
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
            catch{}

            Prova.Text = posizione[0];
        }

        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }
    }
}
