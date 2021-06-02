using System;
using System.Collections.Generic;
using System.Text;

namespace MappaVacciniIT
{
    public class Provincie
    {
        public string Comune { get; set; }
        public string Provincia { get; set; }
        public string Ospedale { get; set; }

        public override string ToString()
        {
            return $"{Comune} {Provincia} {Ospedale}";
        }
    }
}
