using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PCBuilderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PCBuilderContext())
            {
                /*var newUser = new UserTable
                {
                    UserName = "Lenny",
                    FirstName = "Leonard",
                    LastName = "Atorough",
                    PassWord = "password2"
                };
                db.UserTables.Add(newUser);
                db.SaveChanges();*/
            }
        }
    }
}
