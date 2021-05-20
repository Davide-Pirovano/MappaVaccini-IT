using System;
public class DeserializzazioneVaccini
{
    public Schema schema { get; set; }
    public Datum[] data { get; set; }
}

public class Schema
{
    public Field[] fields { get; set; }
    public string[] primaryKey { get; set; }
    public string pandas_version { get; set; }
}

public class Field
{
    public string name { get; set; }
    public string type { get; set; }
}

public class Datum
{
    public int index { get; set; }
    public DateTime data_somministrazione { get; set; }
    public string area { get; set; }
    public int totale { get; set; }
    public int sesso_maschile { get; set; }
    public int sesso_femminile { get; set; }
    public int categoria_operatori_sanitari_sociosanitari { get; set; }
    public int categoria_personale_non_sanitario { get; set; }
    public int categoria_ospiti_rsa { get; set; }
    public int categoria_personale_scolastico { get; set; }
    public int categoria_60_69 { get; set; }
    public int categoria_70_79 { get; set; }
    public int categoria_over80 { get; set; }
    public int categoria_soggetti_fragili { get; set; }
    public int categoria_forze_armate { get; set; }
    public int categoria_altro { get; set; }
    public int prima_dose { get; set; }
    public int seconda_dose { get; set; }
    public string codice_NUTS1 { get; set; }
    public string codice_NUTS2 { get; set; }
    public int codice_regione_ISTAT { get; set; }
    public string nome_area { get; set; }
}
