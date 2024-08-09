using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResume2024.Models.PlanetModels;

public class Bodies
{
    public string type { get; set; }
    public Items items { get; set; }
}

public class Mass
{
    public string type { get; set; }
    public Properties3 properties { get; set; }
}

public class Knowncount
{
    public string type { get; set; }
    public Items4 items { get; set; }
}