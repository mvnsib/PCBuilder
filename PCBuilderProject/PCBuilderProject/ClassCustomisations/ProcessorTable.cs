using System;
using System.Collections.Generic;
using System.Text;

namespace PCBuilderProject
{
    public partial class ProcessorTable
    {
        public override string ToString()
        {
            return $"{Manufacturer} {Cpufamily} {Core} - {Price}";
        }
    }
}
