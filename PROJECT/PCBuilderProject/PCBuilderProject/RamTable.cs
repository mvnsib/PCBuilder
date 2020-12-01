using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class RamTable
    {
        public int Ramid { get; set; }
        public int? Capacity { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int? Speed { get; set; }
    }
}
