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
    public partial class ListaProvincie : ContentPage
    {
        string regione = "";
        static string url = "https://raw.githubusercontent.com/italia/covid19-opendata-vaccini/master/dati/punti-somministrazione-latest.json";
        HttpClient client = new HttpClient();
        public ListaProvincie(string s,int vaccini)
        {
            InitializeComponent();
            regione = s;
            Titolo.Text = "Centri Vaccinali " + regione;
            Vaccini.Text = vaccini.ToString() + " vaccini somministrati";
            Get();
        }
        public IList<Provincie> Provincies { get; private set; }
        async void Get()
        {
            string dati = "";
            Provincies = new List<Provincie>();
            try
            {
                dati = await client.GetStringAsync(url);
            }
            catch{}
            PuntiDiSomministrazione pS = JsonConvert.DeserializeObject<PuntiDiSomministrazione>(dati);
            foreach (var item in pS.data)
            {
                if (item.nome_area.Contains(regione))
                {
                    Provincies.Add(new Provincie
                    {
                        Comune = item.comune,
                        Ospedale = item.presidio_ospedaliero,
                        Provincia = item.provincia
                    });
                }
                else if (regione== "Trentino" && item.nome_area == @"Provincia Autonoma Trento")
                {
                    Provincies.Add(new Provincie
                    {
                        Comune = item.comune,
                        Ospedale = item.presidio_ospedaliero,
                        Provincia = item.provincia
                    });
                }
                else if (regione == "Trentino" && item.nome_area == @"Provincia Autonoma Bolzano / Bozen")
                {
                    Provincies.Add(new Provincie
                    {
                        Comune = item.comune,
                        Ospedale = item.presidio_ospedaliero,
                        Provincia = item.provincia
                    });
                }
            }
            BindingContext = this;
        }
    }
}