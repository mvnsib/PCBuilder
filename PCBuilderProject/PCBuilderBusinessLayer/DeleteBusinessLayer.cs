using System;
using System.Collections.Generic;
using System.Text;
using PCBuilderProject;
using System.Linq;

namespace PCBuilderBusinessLayer
{
    public class DeleteBusinessLayer
    {
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
    }
}
