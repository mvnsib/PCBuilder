using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PCBuilderProject;
using System.Collections;

namespace PCBuilderBusinessLayer
{
    public class CRUDManager
    {
        public UserTable SelectedUser { get; set; }
        
        public ProcessorTable SelectProcessor { get; set; }
        public RamTable SelectRAM { get; set; }
        public MotherboardTable SelectMotherboard { get; set; }
        public GraphicsCardTable SelectGraphicscard { get; set; }

        public List<ProcessorTable> RetrieveAllCPU()
        {
            using (var db = new PCBuilderContext())
            {
                return db.ProcessorTables.ToList();
            }
        }
        public List<GraphicsCardTable> RetrieveAllGPU()
        {
            using (var db = new PCBuilderContext())
            {
                return db.GraphicsCardTables.ToList();
            }
        }
        public void SetSelectedUser(string userName)
        {
            using (var db = new PCBuilderContext())
            {
                SelectedUser = db.UserTables.Where(u => u.UserName == userName).First();

            }
        }
        public List<RamTable> RetrieveAllRAM()
        {
            using (var db = new PCBuilderContext())
            {
                return db.RamTables.ToList();
            }
        }


        public List<MotherboardTable> RetrieveAllMB()
        {
            using (var db = new PCBuilderContext())
            {
                return db.MotherboardTables.ToList();
            }
        }

        public List<string> RetrieveAddedCPUComponents()
        {
            using (var db = new PCBuilderContext())
            {
                var myPC = (from p in db.ComponentTables
                            join c in db.ProcessorTables on p.Cpuid equals c.Cpuid
                            join g in db.GraphicsCardTables on p.Gpuid equals g.Gcid
                            join r in db.RamTables on p.Ramid equals r.Ramid
                            join m in db.MotherboardTables on p.Mbid equals m.Mbid
                            where p.UserName == SelectedUser.UserName
                            select new { p, c, g, r, m }
                            );
                List<string> pcList = new List<string>();
                foreach (var item in myPC)
                {
                    pcList.Add($"Processor: {item.c.Manufacturer} {item.c.Cpufamily}");
                    pcList.Add($"Graphics Card: {item.g.Vram} {item.g.Manufacturer} {item.g.Model}");
                    pcList.Add($"RAM: {item.r.Capacity}GB {item.r.Manufacturer} {item.r.Model} {item.r.Speed} MHz");
                    pcList.Add($"Motherboard: {item.m.Manufacturer} {item.m.Mbname}");
                }

                return pcList;
            }
        }
        public void AddPC(string cpuFamily, string ramModel, int ramSpeed, string gpuModel, string MbName)
        {
            //CPU Variables
            int cpuID;
            string cpuManufacturer;

            //RAM Variables
            int RAMID;
            string RAMModel;
            string RAMManufacturer;
            int RAMCapacity;

            //GPU Variables
            int GPUID;
            string GPUManufacturer;
            int GPUVram;

            //MOBO Variables
            int MBID;
            string MBManufacturer;

            using (var db = new PCBuilderContext())
            {
                cpuID = db.ProcessorTables.Where(c => c.Cpufamily == cpuFamily).FirstOrDefault().Cpuid;
                cpuManufacturer = db.ProcessorTables.Where(c => c.Cpufamily == cpuFamily).FirstOrDefault().Manufacturer;

                RAMID = db.RamTables.Where(r => r.Model == ramModel && r.Speed == ramSpeed).FirstOrDefault().Ramid;
                RAMModel = db.RamTables.Where(r => r.Model == ramModel && r.Speed == ramSpeed).FirstOrDefault().Model;
                RAMManufacturer = db.RamTables.Where(r => r.Model == ramModel && r.Speed == ramSpeed).FirstOrDefault().Manufacturer;
                RAMCapacity = db.RamTables.Where(r => r.Model == ramModel && r.Speed == ramSpeed).FirstOrDefault().Capacity;


                GPUID = db.GraphicsCardTables.Where(g => g.Model == gpuModel).FirstOrDefault().Gcid;
                GPUManufacturer = db.GraphicsCardTables.Where(g => g.Model == gpuModel).FirstOrDefault().Manufacturer;
                GPUVram = db.GraphicsCardTables.Where(g => g.Model == gpuModel).FirstOrDefault().Vram;

                MBID = db.MotherboardTables.Where(m => m.Mbname == MbName).FirstOrDefault().Mbid;
                MBManufacturer = db.MotherboardTables.Where(m => m.Mbname == MbName).FirstOrDefault().Manufacturer;

                var newPC = new ComponentTable()
                {
                    Cpuid = cpuID,
                    Mbid = MBID,
                    Gpuid = GPUID,
                    Ramid = RAMID,
                    UserId = SelectedUser.UserId,
                    Cpuname = $"{cpuManufacturer} {cpuFamily}",
                    Mbname = $"{MBManufacturer} {MbName}",
                    Gpuname = $"{GPUManufacturer} {gpuModel} {GPUVram}GB",
                    Ramname = $"{RAMCapacity}GB {RAMManufacturer} {RAMModel} {ramSpeed}MHz",
                    UserName = SelectedUser.UserName
                };
                db.ComponentTables.Add(newPC);
                db.SaveChanges();
            }
        }
        
        public void SetSelectedProcessor(object selectCPU)
        {
            SelectProcessor = (ProcessorTable)selectCPU;
            
        }
        public void SetSelectedRAM(object selectRAM)
        {
            SelectRAM = (RamTable)selectRAM;
        }
        public void SetSelectedMotherboard(object selectMotherboard)
        {
            SelectMotherboard = (MotherboardTable)selectMotherboard;
        }
        public void SetSelectedGraphicsCard(object selectGraphicsCard)
        {
            SelectGraphicscard = (GraphicsCardTable)selectGraphicsCard;
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

        public void CreateProcessor(string manufacturers, string cpuFamily, int core, int price, int userId)
        {
            using (var db = new PCBuilderContext())
            {
                if (!(db.ProcessorTables.Contains(db.ProcessorTables.Where(x => x.Cpufamily == cpuFamily).FirstOrDefault()))) {
                    var newProcessor = new ProcessorTable
                    {
                        Manufacturer = manufacturers,
                        Cpufamily = cpuFamily,
                        Core = core,
                        Price = price,
                        UserId = userId
                    };
                    db.ProcessorTables.Add(newProcessor);

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Processor exists");
                }
            }
        }

        public void CreateRAM(int capacity, string manufacturers, string model, int speed, int price)
        {
            using (var db = new PCBuilderContext())
            {
                if (!(db.RamTables.Contains(db.RamTables.Where(x => x.Model == model && x.Speed == speed).FirstOrDefault())))
                {
                    var newRAM = new RamTable
                    {
                        Capacity = capacity,
                        Manufacturer = manufacturers,
                        Model = model,
                        Speed = speed,
                        Price = price
                    };
                    db.RamTables.Add(newRAM);

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("RAM exists");
                }
            }
        }

        public void CreateMotherBoard(string manufacturers, string mbName, int price)
        {
            using (var db = new PCBuilderContext())
            {
                if (!(db.MotherboardTables.Contains(db.MotherboardTables.Where(x => x.Mbname == mbName).FirstOrDefault())))
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
                else
                {
                    throw new ArgumentException("Motherboard exists");
                }
            }
        }

        public void CreateGraphicsCard(int vram, string manufacturers, string model, int price)
        {
            using (var db = new PCBuilderContext())
            {
                if (!(db.GraphicsCardTables.Contains(db.GraphicsCardTables.Where(x => x.Model == model).FirstOrDefault())))
                {
                    var newGraphicsCard = new GraphicsCardTable
                    {
                        Vram = vram,
                        Manufacturer = manufacturers,
                        Model = model,
                        Price = price
                    };
                    db.GraphicsCardTables.Add(newGraphicsCard);
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Graphics card exists");
                }
            }
        }

        public bool ReadUsernameAndPassword(string userName, string passWord)
        {
            using (var db = new PCBuilderContext())
            {

                var findUser = db.UserTables.Where(c => c.UserName == userName).FirstOrDefault();
                if (findUser != null)
                {
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
                    Console.WriteLine($"Capacity: {item.Capacity}GB  Manufacturer: {item.Manufacturer}  Model: {item.Model}  Speed: {item.Speed}MHz   Price{item.Price}");
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
                    Console.WriteLine($"VRAM: {item.Vram}  Manufacturer: {item.Manufacturer}  Model: {item.Model}  Price{item.Price}");
                }
            }
        }


        public void UpdateUserPassword(string userName, string password)
        {
            using (var db = new PCBuilderContext())
            {
                var selectUser = db.UserTables.Where(c => c.UserName == userName).FirstOrDefault();
                selectUser.PassWord = password;
                db.SaveChanges();
            }
        }
        public void UpdateUser(string userName, string firstName, string lastName, string passWord)
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
        public void UpdateCPU(string Manufacturer, string CPUFamily, int Core, int price)
        {
            using (var db = new PCBuilderContext())
            {
                var selectCPU = db.ProcessorTables.Where(c => c.Cpufamily == CPUFamily).FirstOrDefault();
                selectCPU.Manufacturer = Manufacturer;
                selectCPU.Cpufamily = CPUFamily;
                selectCPU.Core = Core;
                selectCPU.Price = price;
                db.SaveChanges();
            }
        }

        public void UpdateRAM(int capacity, string manufacturer, string model, int speed, int price)
        {
            using (var db = new PCBuilderContext())
            {
                var selectRAM = db.RamTables.Where(r => r.Model == model).FirstOrDefault();
                selectRAM.Capacity = capacity;
                selectRAM.Manufacturer = manufacturer;
                selectRAM.Model = model;
                selectRAM.Speed = speed;
                selectRAM.Price = price;
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
                db.SaveChanges();
            }
        }
        public void UpdateGraphicsCard(int vram, string manufacturer, string model, int price)
        {
            using (var db = new PCBuilderContext())
            {
                var selectGC = db.GraphicsCardTables.Where(g => g.Model == model).FirstOrDefault();
                selectGC.Vram = vram;
                selectGC.Manufacturer = manufacturer;
                selectGC.Model = model;
                selectGC.Price = price;
                db.SaveChanges();
            }
        }

        public void DeleteUser(string userName)
        {
            using (var db = new PCBuilderContext())
            {
                var selectUser =
                    from u in db.UserTables
                    where u.UserName == userName
                    select u;
                db.UserTables.RemoveRange(selectUser);
                db.SaveChanges();

            }
        }
        public void DeleteRam(int Ramid)
        {
            using (var db = new PCBuilderContext())
            {
                var selectRam =
                    from r in db.RamTables
                    where r.Ramid == Ramid
                    select r;
                db.RamTables.RemoveRange(selectRam);
                db.SaveChanges();
            }
        }

        public void DeleteProcessor(int cpuId)
        {
            using (var db = new PCBuilderContext())
            {
                var selectCPU =
                    from c in db.ProcessorTables
                    where c.Cpuid == cpuId
                    select c;
                db.ProcessorTables.RemoveRange(selectCPU);
                db.SaveChanges();

            }
        }

        public void DeleteMotherboard(int mbId)
        {
            using (var db = new PCBuilderContext())
            {
                var selectMB =
                    from m in db.MotherboardTables
                    where m.Mbid == mbId
                    select m;
                db.MotherboardTables.RemoveRange(selectMB);
                db.SaveChanges();

            }
        }
        public void DeleteGraphicsCard(int gcId)
        {
            using (var db = new PCBuilderContext())
            {
                var selectGC =
                    from g in db.GraphicsCardTables
                    where g.Gcid == gcId
                    select g;
                db.GraphicsCardTables.RemoveRange(selectGC);
                db.SaveChanges();
            }
        }

        public int findUserID(string userName)
        {
            int userID;
            using (var db = new PCBuilderContext())
            {
                userID = db.UserTables.Where(u => u.UserName == userName).FirstOrDefault().UserId;

                return userID;
            }
            
        }

        public int getCPUPrice(int cpuID)
        {
            int cpuCost;
            using (var db = new PCBuilderContext())
            {
                cpuCost = (int) db.ProcessorTables.Where(c => c.Cpuid == cpuID).FirstOrDefault().Price;
            }
            return cpuCost;
        }

    }
}
