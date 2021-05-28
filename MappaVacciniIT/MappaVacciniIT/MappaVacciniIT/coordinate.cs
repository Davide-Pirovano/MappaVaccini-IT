
public class Rootobject
{
    public string type { get; set; }
    public float[] bbox { get; set; }
    public Feature[] features { get; set; }
}

public class Feature
{
    public string type { get; set; }
    public Geometry geometry { get; set; }
    public Properties properties { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public object[][][] coordinates { get; set; }
}

public class Properties
{
    public string reg_name { get; set; }
    public int reg_istat_code_num { get; set; }
    public string reg_istat_code { get; set; }
}
