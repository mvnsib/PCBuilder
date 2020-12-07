using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class RamTable
    {
        public RamTable()
        {
            ComponentTables = new HashSet<ComponentTable>();
        }

        public int Ramid { get; set; }
        public int Capacity { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Price { get; set; }
        public int? UserId { get; set; }

        public virtual UserTable User { get; set; }
        public virtual ICollection<ComponentTable> ComponentTables { get; set; }
    }
}
