using System;
using System.Collections.Generic;
using System.Text;
using PCBuilderProject;
using System.Linq;

namespace PCBuilderBusinessLayer
{
    public class UpdateBusinessLayer
    {
        public void UpdateUserPassword(string userName, string password)
        {
            using (var db = new PCBuilderContext())
            {
                var selectUser =
                    from u in db.UserTables
                    where u.UserName == userName
                    select u;
                foreach (var item in selectUser)
                {
                    item.PassWord = password;
                }
                db.SaveChanges();
            }
        }

    }
}
