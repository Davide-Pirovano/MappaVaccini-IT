using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Threading;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;

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
            try
            {
                InitializeComponent();
                MyMap.IsVisible = false;
            
                Get();
            }
            catch { }
        }

        async void Get()
        {
            string dati = "";
            try
            {
                dati = await client.GetStringAsync(url);
            }
            catch{}
            DeserializzazioneVaccini dV = JsonConvert.DeserializeObject<DeserializzazioneVaccini>(dati);
            //somma dosi per regioni
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
            //creazioni pin regioni
            foreach (var item in totRegioni)
            {
                if (item.Key == "Lombardia")
                {
                    Pin pinLombardia = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString()+" vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(45.466944, 9.19),
                    };
                    MyMap.Pins.Add(pinLombardia);
                    pinLombardia.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Lombardia",item.Value));
                    };
                }
                else if(item.Key == "Toscana")
                {
                    Pin pinToscana = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(43.333333, 11.333333)
                    };
                    MyMap.Pins.Add(pinToscana);

                    pinToscana.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Toscana", item.Value));
                    };
                }
                else if (item.Key == "Piemonte")
                {
                    Pin pinPiemonte = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(45.066667, 7.7)
                    };
                    MyMap.Pins.Add(pinPiemonte);

                    pinPiemonte.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Piemonte", item.Value));
                    };
                }
                else if (item.Key == "Campania")
                {
                    Pin pinCampania = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(40.833333, 14.25)
                    };
                    MyMap.Pins.Add(pinCampania);

                    pinCampania.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Campania", item.Value));
                    };
                }
                else if (item.Key == "Molise")
                {
                    Pin pinMolise = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(42.002778, 14.994722)
                    };
                    MyMap.Pins.Add(pinMolise);


                    pinMolise.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Molise", item.Value));
                    };
                }
                else if (item.Key == "Marche")
                {
                    Pin pinMarche = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(43.616667, 13.516667)
                    };
                    MyMap.Pins.Add(pinMarche);


                    pinMarche.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Marche", item.Value));
                    };
                }
                else if (item.Key == "Liguria")
                {
                    Pin pinLiguria = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(44.407186, 8.933983)
                    };
                    MyMap.Pins.Add(pinLiguria);


                    pinLiguria.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Liguria", item.Value));
                    };
                }
                else if (item.Key == "Veneto")
                {
                    Pin pinVeneto = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(45.439722, 12.331944)
                    };
                    MyMap.Pins.Add(pinVeneto);

                    pinVeneto.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Veneto", item.Value));
                    };
                }
                else if (item.Key == "Lazio")
                {
                    Pin pinLazio = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(41.893056, 12.482778)
                    };
                    MyMap.Pins.Add(pinLazio);

                    pinLazio.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Lazio", item.Value));
                    };
                }
                else if (item.Key == "Emilia-Romagna")
                {
                    Pin pinEmilia = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(44.493889, 11.342778)
                    };
                    MyMap.Pins.Add(pinEmilia);

                    pinEmilia.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Emilia", item.Value));
                    };
                }
                else if (item.Key == "Friuli-Venezia Giulia")
                {
                    Pin pinFriuli = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(45.650278, 13.770278)
                    };
                    MyMap.Pins.Add(pinFriuli);
                    pinFriuli.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Friuli", item.Value));
                    };
                }
                else if (item.Key == "Sardegna")
                {
                    Pin pinSardegna = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(40.115112, 9.012081)
                    };
                    MyMap.Pins.Add(pinSardegna);
                    pinSardegna.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Sardegna", item.Value));
                    };
                }
                else if (item.Key == "Sicilia")
                {
                    Pin pinSicilia = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(37.491472, 14.062444)
                    };
                    MyMap.Pins.Add(pinSicilia);
                    pinSicilia.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Sicilia", item.Value));
                    };
                }
                else if (item.Key == "Puglia")
                {
                    Pin pinPuglia = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(40.7, 17.333333)
                    };
                    MyMap.Pins.Add(pinPuglia);
                    pinPuglia.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Puglia", item.Value));
                    };
                }
                else if (item.Key == "Umbria")
                {
                    Pin pinUmbria = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(43.1121, 12.3888)
                    };
                    MyMap.Pins.Add(pinUmbria);
                    pinUmbria.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Umbria", item.Value));
                    };
                }
                else if (item.Key == "Calabria")
                {
                    Pin pinCalabria = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(38.91, 16.5875)
                    };
                    MyMap.Pins.Add(pinCalabria);
                    pinCalabria.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Calabria", item.Value));
                    };
                }
                else if (item.Key == "Basilicata")
                {
                    Pin pinBasilicata = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Generic,
                        Position = new Position(40.633333, 15.8)
                    };
                    MyMap.Pins.Add(pinBasilicata);

                    pinBasilicata.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Basilicata", item.Value));
                    };
                }
                else if (item.Key == "Valle d'Aosta")
                {
                    Pin pinAosta = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.SavedPin,
                        Position = new Position(45.783333, 6.966667),
                    };
                    MyMap.Pins.Add(pinAosta);


                    pinAosta.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Aosta", item.Value));
                    };
                }
                else if (item.Key == "Trentino")
                {
                    Pin pinTrentino = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(46.066667, 11.116667)
                    };
                    MyMap.Pins.Add(pinTrentino);


                    pinTrentino.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Trentino", item.Value));
                    };
                }
                else if (item.Key == "Abruzzo")
                {
                    Pin pinAbruzzo = new Pin
                    {
                        Label = item.Key,
                        Address = (item.Value).ToString() + " vaccini somministrati",
                        Type = PinType.Place,
                        Position = new Position(42.354008, 13.391992)
                    };
                    MyMap.Pins.Add(pinAbruzzo);


                    pinAbruzzo.InfoWindowClicked += async (s, args) =>
                    {
                        await Navigation.PushAsync(new ListaProvincie("Abruzzo", item.Value));
                    };
                }
            }

            //creazione regioni

            Rootobject coordinate = new Rootobject();
            string val = "";
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("MappaVacciniIT.regioniFattebene.txt");
            using (StreamReader sr = new StreamReader(stream))
            {

                val = sr.ReadToEnd();

            }
            coordinate = JsonConvert.DeserializeObject<Rootobject>(val);
            List<Position> lista = new List<Position>();
            Dictionary<string, List<Position>> dizionario = new Dictionary<string, List<Position>>();

            foreach (var item in coordinate.features)
            {
                lista = new List<Position>();

                if (item.geometry.type == "Polygon")
                {
                    foreach (var b in item.geometry.coordinates[0])
                    {
                        lista.Add(new Position((double)b[1], (double)b[0]));
                    }
                }
                if (item.geometry.type == "MultiPolygon")
                {

                    foreach (var b in item.geometry.coordinates[0][0])
                    {
                        JToken token = (JToken)b;
                        var pnt = token.Children().ToArray();

                        lista.Add(new Position((double)pnt[1], (double)pnt[0]));
                    }


                }

                dizionario.Add(item.properties.reg_name, lista);

            }

            var colore = Color.Black;
            int bordi = 6;
            Polygon piemonte = new Polygon();
            piemonte.StrokeColor = colore;
            piemonte.StrokeWidth = bordi;
            Polygon abruzzo = new Polygon();
            abruzzo.StrokeColor = colore;
            abruzzo.StrokeWidth = bordi;
            Polygon basilicata = new Polygon();
            basilicata.StrokeColor = colore;
            basilicata.StrokeWidth = bordi;
            Polygon calabria = new Polygon();
            calabria.StrokeColor = colore;
            calabria.StrokeWidth = bordi;
            Polygon campania = new Polygon();
            campania.StrokeColor = colore;
            campania.StrokeWidth = bordi;
            Polygon emilia = new Polygon();
            emilia.StrokeColor = colore;
            emilia.StrokeWidth = bordi;
            Polygon friuli = new Polygon();
            friuli.StrokeColor = colore;
            friuli.StrokeWidth = bordi;
            Polygon lazio = new Polygon();
            lazio.StrokeColor = colore;
            lazio.StrokeWidth = bordi;
            Polygon liguria = new Polygon();
            liguria.StrokeColor = colore;
            liguria.StrokeWidth = 5;
            Polygon lombardia = new Polygon();
            lombardia.StrokeColor = colore;
            lombardia.StrokeWidth = bordi;
            Polygon marche = new Polygon();
            marche.StrokeColor = colore;
            marche.StrokeWidth = bordi;
            Polygon molise = new Polygon();
            molise.StrokeColor = colore;
            molise.StrokeWidth = bordi;
            Polygon puglia = new Polygon();
            puglia.StrokeColor = colore;
            puglia.StrokeWidth = bordi;
            Polygon sardegna = new Polygon();
            sardegna.StrokeColor = colore;
            sardegna.StrokeWidth = bordi;
            Polygon sicilia = new Polygon();
            sicilia.StrokeColor = colore;
            sicilia.StrokeWidth = bordi;
            Polygon toscana = new Polygon();
            toscana.StrokeColor = colore;
            toscana.StrokeWidth = bordi;
            Polygon trentino = new Polygon();
            trentino.StrokeColor = colore;
            trentino.StrokeWidth = bordi;
            Polygon umbria = new Polygon();
            umbria.StrokeColor = colore;
            umbria.StrokeWidth = bordi;
            Polygon aosta = new Polygon();
            aosta.StrokeColor = colore;
            aosta.StrokeWidth = bordi;
            Polygon veneto = new Polygon();
            veneto.StrokeColor = colore;
            veneto.StrokeWidth = bordi;

            //decisione colore regione
            foreach (var item in totRegioni)
            {
                if (item.Key == "Lombardia")
                {
                    if (item.Value > 1000000)
                    {
                        lombardia.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        lombardia.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        lombardia.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Veneto")
                {
                    if (item.Value > 1000000)
                    {
                        veneto.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        veneto.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        veneto.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Lazio")
                {
                    if (item.Value > 1000000)
                    {
                        lazio.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        lazio.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        lazio.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Marche")
                {
                    if (item.Value > 1000000)
                    {
                        marche.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        marche.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        marche.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Abruzzo")
                {
                    if (item.Value > 1000000)
                    {
                        abruzzo.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        abruzzo.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        abruzzo.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Toscana")
                {
                    if (item.Value > 1000000)
                    {
                        toscana.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        toscana.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        toscana.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Emilia-Romagna")
                {
                    if (item.Value > 1000000)
                    {
                        emilia.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        emilia.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        emilia.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Piemonte")
                {
                    if (item.Value > 1000000)
                    {
                        piemonte.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        piemonte.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        piemonte.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Friuli-Venezia Giulia")
                {
                    if (item.Value > 1000000)
                    {
                        friuli.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        friuli.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        friuli.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Campania")
                {
                    if (item.Value > 1000000)
                    {
                        campania.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        campania.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        campania.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Basilicata")
                {
                    if (item.Value > 1000000)
                    {
                        basilicata.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        basilicata.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        basilicata.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Molise")
                {
                    if (item.Value > 1000000)
                    {
                        molise.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        molise.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        molise.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Umbria")
                {
                    if (item.Value > 1000000)
                    {
                        umbria.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        umbria.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        umbria.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Sicilia")
                {
                    if (item.Value > 1000000)
                    {
                        sicilia.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        sicilia.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        sicilia.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Sardegna")
                {
                    if (item.Value > 1000000)
                    {
                        sardegna.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        sardegna.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        sardegna.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Puglia")
                {
                    if (item.Value > 1000000)
                    {
                        puglia.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        puglia.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        puglia.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Valle d'Aosta")
                {
                    if (item.Value > 1000000)
                    {
                        aosta.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        aosta.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        aosta.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Liguria")
                {
                    if (item.Value > 1000000)
                    {
                        liguria.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        liguria.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        liguria.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Calabria")
                {
                    if (item.Value > 1000000)
                    {
                        calabria.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        calabria.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        calabria.FillColor = Color.FromHex("231942");
                    }
                }
                if (item.Key == "Trentino")
                {
                    if (item.Value > 1000000)
                    {
                        trentino.FillColor = Color.FromHex("9F86C0");
                    }
                    else if (item.Value > 500000)
                    {
                        trentino.FillColor = Color.FromHex("5E548E");
                    }
                    else
                    {
                        trentino.FillColor = Color.FromHex("231942");
                    }
                }
            }

            //aggiunta regioni alla mappa
            foreach (var item in dizionario)
            {
                if (item.Key == "Piemonte")
                {
                    foreach (var a in item.Value)
                    {
                        piemonte.Geopath.Add(a);
                    }

                }
                if (item.Key == "Abruzzo")
                {
                    foreach (var a in item.Value)
                    {
                        abruzzo.Geopath.Add(a);
                    }

                }
                if (item.Key == "Basilicata")
                {
                    foreach (var a in item.Value)
                    {
                        basilicata.Geopath.Add(a);
                    }

                }
                if (item.Key == "Calabria")
                {
                    foreach (var a in item.Value)
                    {
                        calabria.Geopath.Add(a);
                    }

                }
                if (item.Key == "Campania")
                {
                    foreach (var a in item.Value)
                    {
                        campania.Geopath.Add(a);
                    }

                }
                if (item.Key == "Emilia-Romagna")
                {
                    foreach (var a in item.Value)
                    {
                        emilia.Geopath.Add(a);
                    }

                }
                if (item.Key == "Friuli-Venezia Giulia")
                {
                    foreach (var a in item.Value)
                    {
                        friuli.Geopath.Add(a);
                    }

                }
                if (item.Key == "Lazio")
                {
                    foreach (var a in item.Value)
                    {
                        lazio.Geopath.Add(a);
                    }

                }
                if (item.Key == "Liguria")
                {
                    foreach (var a in item.Value)
                    {
                        liguria.Geopath.Add(a);
                    }

                }
                if (item.Key == "Lombardia")
                {
                    foreach (var a in item.Value)
                    {
                        lombardia.Geopath.Add(a);
                    }

                }
                if (item.Key == "Marche")
                {
                    foreach (var a in item.Value)
                    {
                        marche.Geopath.Add(a);
                    }

                }
                if (item.Key == "Molise")
                {
                    foreach (var a in item.Value)
                    {
                        molise.Geopath.Add(a);
                    }

                }

                if (item.Key == "Puglia")
                {
                    foreach (var a in item.Value)
                    {
                        puglia.Geopath.Add(a);
                    }

                }

                if (item.Key == "Sardegna")
                {
                    foreach (var a in item.Value)
                    {
                        sardegna.Geopath.Add(a);
                    }

                }

                if (item.Key == "Sicilia")
                {
                    foreach (var a in item.Value)
                    {
                        sicilia.Geopath.Add(a);
                    }

                }

                if (item.Key == "Toscana")
                {
                    foreach (var a in item.Value)
                    {
                        toscana.Geopath.Add(a);
                    }

                }

                if (item.Key == "Trentino-Alto Adige/Südtirol")
                {
                    foreach (var a in item.Value)
                    {
                        trentino.Geopath.Add(a);
                    }

                }

                if (item.Key == "Umbria")
                {
                    foreach (var a in item.Value)
                    {
                        umbria.Geopath.Add(a);
                    }

                }

                if (item.Key == "Valle d'Aosta/Vallée d'Aoste")
                {
                    foreach (var a in item.Value)
                    {
                        aosta.Geopath.Add(a);
                    }

                }


                if (item.Key == "Veneto")
                {
                    foreach (var a in item.Value)
                    {
                        veneto.Geopath.Add(a);
                    }

                }

            }

            MyMap.MapElements.Add(piemonte);
            MyMap.MapElements.Add(abruzzo);
            MyMap.MapElements.Add(basilicata);
            MyMap.MapElements.Add(calabria);
            MyMap.MapElements.Add(campania);
            MyMap.MapElements.Add(emilia);
            MyMap.MapElements.Add(friuli);
            MyMap.MapElements.Add(lazio);
            MyMap.MapElements.Add(liguria);
            MyMap.MapElements.Add(lombardia);
            MyMap.MapElements.Add(marche);
            MyMap.MapElements.Add(molise);
            MyMap.MapElements.Add(puglia);
            MyMap.MapElements.Add(sardegna);
            MyMap.MapElements.Add(sicilia);
            MyMap.MapElements.Add(toscana);
            MyMap.MapElements.Add(trentino);
            MyMap.MapElements.Add(umbria);
            MyMap.MapElements.Add(aosta);
            MyMap.MapElements.Add(veneto);

            Caricamento.IsVisible = false;
            MyMap.IsVisible = true;
            MapType.IsVisible = true;
            Button.IsVisible = true;
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.870000, 12.600000), Distance.FromKilometers(500)));

        }

        public string mapType = "Satellite";

        private void MapType_Toggled(object sender, ToggledEventArgs e)
        {
            if (mapType == "Street")
            {
                MyMap.MapType = Xamarin.Forms.Maps.MapType.Satellite;
                mapType = "Satellite";
            }
            else
            {
                MyMap.MapType = Xamarin.Forms.Maps.MapType.Street;
                mapType = "Street";
            }
        }

        private void BackToItaly_Clicked(object sender, EventArgs e)
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(41.870000, 12.600000), Distance.FromKilometers(500)));
        }
    }
}
