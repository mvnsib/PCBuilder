using System;
using System.Collections.Generic;
using System.Text;

namespace PCBuilderProject
{
    public partial class GraphicsCardTable
    {
        public override string ToString()
        {
            return $"{Vram}GB {Manufacturer} {Model} - {Price}";
        }
    }
}
