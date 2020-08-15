using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEFPlacementer
{
    class Options
    {
        [Option('l', "Load", Required = false)]
        public string URL { get; set; }

        [Option('c', "Close", Required = false)]
        public bool Close { get; set; }

        [Option('p', "Position", Required = false)]
        public string PositionString { get; set; }
    }
}
