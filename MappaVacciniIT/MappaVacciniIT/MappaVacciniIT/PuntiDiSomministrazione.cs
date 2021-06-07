
public class PuntiDiSomministrazione
{
    public Schema2 schema { get; set; }
    public Datum2[] data { get; set; }
}

public class Schema2
{
    public Field2[] fields { get; set; }
    public string[] primaryKey { get; set; }
    public string pandas_version { get; set; }
}

public class Field2
{
    public string name { get; set; }
    public string type { get; set; }
}

public class Datum2
{
    public int index { get; set; }
    public string area { get; set; }
    public string provincia { get; set; }
    public string comune { get; set; }
    public string presidio_ospedaliero { get; set; }
    public string codice_NUTS1 { get; set; }
    public string codice_NUTS2 { get; set; }
    public int codice_regione_ISTAT { get; set; }
    public string nome_area { get; set; }
}
