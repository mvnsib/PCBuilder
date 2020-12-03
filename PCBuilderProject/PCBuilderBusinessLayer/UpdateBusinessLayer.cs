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
                /* var selectUser =
                     from u in db.UserTables
                     where u.UserName == userName
                     select u;
                 foreach (var item in selectUser)
                 {
                     item.PassWord = password;
                 }
                 db.SaveChanges();*/

                var selectUser = db.UserTables.Where(c => c.UserName == userName).FirstOrDefault();
                selectUser.PassWord = password;
                db.SaveChanges();

            }
        }
        public void UpdateUser(string userName, string firstName, string lastName, string passWord )
        {
            using (var db = new PCBuilderContext())
            {
                var selectUser = db.UserTables.Where(c => c.UserName == userName).FirstOrDefault();
                selectUser.UserName = userName;
                selectUser.FirstName = firstName;
                selectUser.LastName = lastName;
                selectUser.PassWord = passWord;
                db.SaveChanges();
            }
        }
        public void UpdateCPU(string Manufacturer, string CPUFamily, int Core)
        {
            using (var db = new PCBuilderContext())
            {
                var selectCPU = db.ProcessorTables.Where(c => c.Cpufamily == CPUFamily).FirstOrDefault();
                selectCPU.Manufacturer = Manufacturer;
                selectCPU.Cpufamily = CPUFamily;
                selectCPU.Core = Core;
                db.SaveChanges();
            }
        }

        public void UpdateRAM(int capacity, string manufacturer, string model, int speed)
        {
            using (var db = new PCBuilderContext())
            {
                var selectRAM = db.RamTables.Where(r => r.Model == model).FirstOrDefault();
                selectRAM.Capacity = capacity;
                selectRAM.Manufacturer = manufacturer;
                selectRAM.Model = model;
                selectRAM.Speed = speed;
                db.SaveChanges();
            }
        }
        public void UpdateMotherboard(string manufacturer, string MBname, int price)
        {
            using (var db = new PCBuilderContext())
            {
                var selectMB = db.MotherboardTables.Where(m => m.Mbname == MBname).FirstOrDefault();
                selectMB.Manufacturer = manufacturer;
                selectMB.Mbname = MBname;
                selectMB.Price = price;
            }
        }
        public void UpdateGraphicsCard(int vram, string manufacturer, string model)
        {
            using (var db = new PCBuilderContext())
            {
                var selectGC = db.GraphicsCardTables.Where(g => g.Model == model).FirstOrDefault();
                selectGC.Vram = vram;
                selectGC.Manufacturer = manufacturer;
                selectGC.Model = model;
            }
        }



    }
}
