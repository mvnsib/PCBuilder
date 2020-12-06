using System;
using System.Collections.Generic;
using System.Text;

namespace PCBuilderProject
{
    public partial class MotherboardTable
    {
        public override string ToString()
        {
            return $"{Manufacturer} {Mbname} - {Price}";
        }
    }
}
