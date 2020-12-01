using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class GraphicsCardTable
    {
        public int Gcid { get; set; }
        public int Vram { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
}
