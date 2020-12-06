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
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }

        public virtual ICollection<ComponentTable> ComponentTables { get; set; }
    }
}
