using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TRHDipComp_Project.Models
{
    public class MyFileStream : FileStream
    {
        [System.Runtime.InteropServices.ComVisible(false)]
        public override int ReadTimeout { get; set; } = 50_000;

        [System.Runtime.InteropServices.ComVisible(false)]
        public override int WriteTimeout { get; set; } = 50_000;

        public MyFileStream(string file, FileMode mode) : base(file, mode)
        {
        }
    }
}
