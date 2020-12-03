using System;
using PCBuilderProject;
using System.Collections.Generic;
using System.Linq;


namespace PCBuilderBusinessLayer
{
    public class ReadBusinessLayer
    {
        public bool ReadUsernameAndPassword(string userName, string passWord)
        {
            using (var db = new PCBuilderContext())
            {

                var findUser = db.UserTables.Where(c => c.UserName == userName).FirstOrDefault();
                if (findUser != null) {
                    if (findUser.UserName.Equals(userName) && findUser.PassWord.Equals(passWord))
                    {
                        return true;
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect detail, please try again.");
                    }
                }
                else
                {
                    throw new ArgumentException("Incorrect detail, please try again.");
                }
            }
        }

        public void ReadCPU()
        {
            using (var db = new PCBuilderContext())
            {
                foreach (var item in db.ProcessorTables)
                {
                    Console.WriteLine($" Manufacturer: {item.Manufacturer}  CPU Family:{item.Cpufamily}  Core:{item.Core}  Price:{item.Price}");
                }
            }
        }
        
        public void ReadRAM()
        {
            using (var db = new PCBuilderContext())
            {
                foreach (var item in db.RamTables)
                {
                    Console.WriteLine($"Capacity: {item.Capacity}GB  Manufacturer: {item.Manufacturer}  Model: {item.Model}  Speed: {item.Speed}MHz");
                }
            }

        }

        public void ReadMotherBoard()
        {
            using (var db = new PCBuilderContext())
            {
                foreach (var item in db.MotherboardTables)
                {
                    Console.WriteLine($"Manufacturer:{item.Manufacturer}  Motherboard Name:{item.Mbname}  Price{item.Price}");
                }
            }
        }
        public void ReadGraphicsCard()
        {
            using (var db = new PCBuilderContext())
            {
                foreach (var item in db.GraphicsCardTables)
                {
                    Console.WriteLine($"VRAM: {item.Vram}  Manufacturer: {item.Manufacturer}  Model: {item.Model}");
                }
            }
        }
        
    }
}
