using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;
using Mediatheque.Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Mediatheque.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new Core.DAL.ApplicationDbContext();
            var service = new MediathequeService(db);

            var cd = service.AddCd("BLO", "13 Block");
            var cd2 = service.AddCd("Deux frere", "PNL");
            var cd3 = service.AddCd("Zoo", "Kaaris");
            var cd4 = service.AddCd("VII", "Koba la D");

            var cds = service.GetCDs();

            service.EditCd(cd2.Id, "L'affranchi");

            var cd2ID = service.GetCdById(cd2.Id);

            service.DeleteCD(cd2.Id);

            Etagere etagere = new Etagere();

            etagere.CDs.Add(cd);

            db.Etageres.Add(etagere);
            db.SaveChanges();




            Console.WriteLine(cd.ToString());

        }
    }
}