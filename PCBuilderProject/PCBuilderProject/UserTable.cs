using System;
using System.Collections.Generic;

#nullable disable

namespace PCBuilderProject
{
    public partial class UserTable
    {
        public UserTable()
        {
            ComponentTables = new HashSet<ComponentTable>();
            GraphicsCardTables = new HashSet<GraphicsCardTable>();
            MotherboardTables = new HashSet<MotherboardTable>();
            ProcessorTables = new HashSet<ProcessorTable>();
            RamTables = new HashSet<RamTable>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }

        public virtual ICollection<ComponentTable> ComponentTables { get; set; }
        public virtual ICollection<GraphicsCardTable> GraphicsCardTables { get; set; }
        public virtual ICollection<MotherboardTable> MotherboardTables { get; set; }
        public virtual ICollection<ProcessorTable> ProcessorTables { get; set; }
        public virtual ICollection<RamTable> RamTables { get; set; }
    }
}
