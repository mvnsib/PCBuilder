using System;
using System.Collections.Generic;
using System.Text;

namespace PCBuilderProject
{
    public partial class RamTable
    {
        public override string ToString()
        {
            return $"{Capacity}GB {Manufacturer} {Model} {Speed}MHz - {Price}";
        }
    }
}
