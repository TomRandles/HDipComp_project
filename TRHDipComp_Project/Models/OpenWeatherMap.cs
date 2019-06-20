using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRHDipComp_Project.Models
{
    public class OpenWeatherMap
    {
        public string ApiResponse { get; set; }

        public Dictionary<string, string> Cities { get; set; }

    }
}
