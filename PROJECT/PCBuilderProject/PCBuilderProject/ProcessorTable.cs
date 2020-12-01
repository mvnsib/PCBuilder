using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class ProcessorTable
    {
        public int Cpuid { get; set; }
        public string Manufacturer { get; set; }
        public string Cpufamily { get; set; }
        public int? Core { get; set; }
        public int? Price { get; set; }
    }
}
