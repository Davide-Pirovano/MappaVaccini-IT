using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MappaVacciniIT
{
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();
        static string url = "https://raw.githubusercontent.com/italia/covid19-opendata-vaccini/master/dati/somministrazioni-vaccini-summary-latest.json";
        string dati;
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
                {"Provincia Autonoma Trento",0 },
                {"Valle d'Aosta / Vallée d'Aoste",0 },
                {"Liguria",0 },
                {"Calabria",0 },
                {"Provincia Autonoma Bolzano / Bozen",0 },
            };
        public MainPage()
        {
            InitializeComponent();
            Get();
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
                    totRegioni["Provincia Autonoma Trento"] += item.totale;
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
                    totRegioni["Valle d'Aosta / Vallée d'Aoste"] += item.totale;
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
                    totRegioni["Provincia Autonoma Bolzano / Bozen"] += item.totale;
                }
            }

        }

        async void Get()
        {
            dati = await client.GetStringAsync(url);
        }
    }
}
