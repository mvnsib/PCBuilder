using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class GraphicsCardTable
    {
        public GraphicsCardTable()
        {
            ComponentTables = new HashSet<ComponentTable>();
        }

        public int Gcid { get; set; }
        public int Vram { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int? UserId { get; set; }

        public virtual UserTable User { get; set; }
        public virtual ICollection<ComponentTable> ComponentTables { get; set; }
    }
}
