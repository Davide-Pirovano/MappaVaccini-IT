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
                        Icon = BitmapDescriptorFactory.FromBundle("milan"),
                        Position = new Position(45.585556, 9.930278)
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
                        Position = new Position(43.510926, 11.185614)
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
                        Position = new Position(45.171620, 7.920124)
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
                        Position = new Position(41.013412, 14.764958)
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
                        Position = new Position(41.633469, 14.577356)
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
                        Position = new Position(43.371091, 13.163432)
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
                        Position = new Position(44.313050, 8.321408)
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
                        Position = new Position(45.709543, 11.919564)
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
                        Position = new Position(42.012711, 12.903216)
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
                        Position = new Position(44.528191, 11.333755)
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
                        Position = new Position(46.204311, 12.968751)
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
                        Position = new Position(40.114762, 9.013230)
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
                        Position = new Position(37.585361, 14.179883)
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
                        Position = new Position(41.031655, 16.584052)
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
                        Position = new Position(42.883959, 12.513396)
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
                        Position = new Position(39.101225, 16.483641)
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
                        Position = new Position(40.518110, 16.120566)
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
                        Position = new Position(45.707832, 7.393762),
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
                        Position = new Position(46.061826, 11.136906)
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
                        Position = new Position(42.216067, 13.880059)
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
    }
}
