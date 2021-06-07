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
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MappaVacciniIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vicinanza : ContentPage
    {

        public string[] posizione = new string[3];
        public Vicinanza()
        {
            InitializeComponent();
            Metodo();
            GetPosition();

        }

        async void Metodo()
        {
            await GetCurrentLocation();
        }



        CancellationTokenSource cts;

        async Task GetCurrentLocation()
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
        public IList<Provincie> Provincies { get; private set; }
        public IList<OspedaliVicini> Final { get; private set; }
        static readonly HttpClient client = new HttpClient();
        async void GetPosition()
        {
            string url = "https://raw.githubusercontent.com/italia/covid19-opendata-vaccini/master/dati/punti-somministrazione-latest.json";
            
            Provincies = new List<Provincie>();
            Final = new List<OspedaliVicini>();
            string dati = "";
            try { 
            dati = await client.GetStringAsync(url);
            }
            catch { }
            PuntiDiSomministrazione pS = JsonConvert.DeserializeObject<PuntiDiSomministrazione>(dati);
            foreach (var item in pS.data)
            {
                Provincies.Add(new Provincie
                {
                    Comune = item.comune,
                    Ospedale = item.presidio_ospedaliero,
                    Provincia = item.provincia,
                    Regione = item.nome_area
                });
            }
            int c = 0;
            foreach (var item in Provincies)
            {

                string urlCoordinate = "https://dev.virtualearth.net/REST/v1/Locations?countryRegion=";
                string urlMatrix = "https://dev.virtualearth.net/REST/v1/Routes/DistanceMatrix?origins=";

                urlCoordinate += item.Regione + "&adminDistrict=";
                urlCoordinate += item.Provincia + "&locality=";
                urlCoordinate += item.Comune + "&key=Avj71Xjjmzat0XSahJl3TXwSG3fMeuX2ojTEgYGGWUBu3o6Uu2FqvLGS1Namhp03";
                string coord="";
                try
                {
                    coord = await client.GetStringAsync(urlCoordinate);
                } catch { }

                JObject bingSerach = JObject.Parse(coord);
                IList<JToken> resourceSets = bingSerach["resourceSets"].Children()["resources"].Children()["geocodePoints"].Children()["coordinates"].Children().ToList();
                string lat = resourceSets[0].ToString().Replace(",", ".");
                string lon = resourceSets[1].ToString().Replace(",", ".");

                posizione[0] = posizione[0].Replace(",", ".");
                posizione[1] = posizione[1].Replace(",", ".");

                urlMatrix += posizione[0] + "," + posizione[1] + "&destinations=";
                urlMatrix += lat + "," + lon + "&travelMode=driving&key=Avj71Xjjmzat0XSahJl3TXwSG3fMeuX2ojTEgYGGWUBu3o6Uu2FqvLGS1Namhp03";
                string distanza="";
                try
                {
                    distanza = await client.GetStringAsync(urlMatrix);
                }
                catch { }
                Matrix m = JsonConvert.DeserializeObject<Matrix>(distanza);
                string v = Math.Round((double.Parse(m.resourceSets[0].resources[0].results[0].travelDistance.ToString())),2).ToString();
                string v1 = Math.Round((double.Parse(m.resourceSets[0].resources[0].results[0].travelDuration.ToString())), 2).ToString();
                if (v!=null)
                {
                    if (double.Parse(v) < 50 && double.Parse(v) > 0)
                    {
                        Final.Add(new OspedaliVicini
                        {
                            Comune = item.Comune,
                            Ospedale = item.Ospedale,
                            Provincia = item.Provincia,
                            Distanza = v+" km",
                            Tempo = v1 +" min"
                        });
                    }
                }
                double val = (c*100) / Provincies.Count;
                Counter.Text = Math.Round(val,1).ToString();
                c++;
            }
            Final = Final.OrderBy(s => s.Distanza).ToList();
            Caricamento.IsVisible = false;
            Counter.IsVisible = false;
            Title.IsVisible = true;
            BindingContext = this;
        }
    }
}