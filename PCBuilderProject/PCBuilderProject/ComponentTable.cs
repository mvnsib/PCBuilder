using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class ComponentTable
    {
        public int Compid { get; set; }
        public int? Cpuid { get; set; }
        public int? Mbid { get; set; }
        public int? Gpuid { get; set; }
        public int? Ramid { get; set; }
        public int? UserId { get; set; }
        public string Cpuname { get; set; }
        public string Mbname { get; set; }
        public string Gpuname { get; set; }
        public string Ramname { get; set; }
        public string UserName { get; set; }

        public virtual ProcessorTable Cpu { get; set; }
        public virtual GraphicsCardTable Gpu { get; set; }
        public virtual MotherboardTable Mb { get; set; }
        public virtual RamTable Ram { get; set; }
        public virtual UserTable User { get; set; }
    }
}
