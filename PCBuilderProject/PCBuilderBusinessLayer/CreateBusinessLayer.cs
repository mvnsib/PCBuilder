using System;
using PCBuilderProject;
using System.Collections.Generic;
using System.Linq;

namespace PCBuilderBusinessLayer
{
    public class CreateBusinessLayer
    {
        public UserTable SelectedUser { get; set; }
        public List<UserTable> RetrieveAll()
        {
            using (var db = new PCBuilderContext())
            {
                return db.UserTables.ToList();
            }
        }
        static void Main(string[] args)
        {
            
        }
        public void CreateUser(string userName, string firstName, string lastName, string passWord)
        {
            using (var db = new PCBuilderContext())
            {
                if (!(db.UserTables.Contains(db.UserTables.Where(x => x.UserName == userName).FirstOrDefault())))
                {
                    var newUser = new UserTable
                    {
                        UserName = userName,
                        FirstName = firstName,
                        LastName = lastName,
                        PassWord = passWord
                    };
                    db.UserTables.Add(newUser);

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Username exists");
                }
            }
        }

        public void CreateProcessor(string manufacturers, string cpuFamily, int core, int price)
        {
            using (var db = new PCBuilderContext())
            {
                var newProcessor = new ProcessorTable
                {
                    Manufacturer = manufacturers,
                    Cpufamily = cpuFamily,
                    Core = core,
                    Price = price
                };
                db.ProcessorTables.Add(newProcessor);

                db.SaveChanges();
            }
        }

        public void CreateUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void CreateRAM(int capacity, string manufacturers, string model, int speed)
        {
            using (var db = new PCBuilderContext())
            {
                var newRAM = new RamTable
                {
                    Capacity = capacity,
                    Manufacturer = manufacturers,
                    Model = model,
                    Speed = speed
                };
                db.RamTables.Add(newRAM);

                db.SaveChanges();
            }
        }

        public void CreateMotherBoard(string manufacturers, string mbName, int price)
        {
            using (var db = new PCBuilderContext())
            {
                var newMotherBoard = new MotherboardTable
                {
                    Manufacturer = manufacturers,
                    Mbname = mbName,
                    Price = price
                };
                db.MotherboardTables.Add(newMotherBoard);

                db.SaveChanges();
            }
        }

        public void CreateGraphicsCard(int vram, string manufacturers, string model)
        {
            using (var db = new PCBuilderContext())
            {
                var newGraphicsCard = new GraphicsCardTable
                {
                    Vram = vram,
                    Manufacturer = manufacturers,
                    Model = model
                };
                db.GraphicsCardTables.Add(newGraphicsCard);

                db.SaveChanges();
            }
        }
    }
}
