using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class MotherboardTable
    {
        public MotherboardTable()
        {
            ComponentTables = new HashSet<ComponentTable>();
        }

        public int Mbid { get; set; }
        public string Manufacturer { get; set; }
        public string Mbname { get; set; }
        public int Price { get; set; }
        public int? UserId { get; set; }

        public virtual UserTable User { get; set; }
        public virtual ICollection<ComponentTable> ComponentTables { get; set; }
    }
}
