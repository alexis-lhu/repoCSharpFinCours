using Mediatheque.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Core.DAL
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<CD> CDs { get; set; }
        public DbSet<JeuxDeSociete> Jeux { get; set; }

        public DbSet<Etagere> Etageres { get; set; }

        public DbSet<Dvd> Dvd { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=cSharp;Uid=root;Pwd=;";
            var serverVersion = new MySqlServerVersion(new Version(10, 4, 32));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public List<CD> GetCDs()
        {
            return this.CDs.ToList();
        }

        public CD AddCd(string album, string groupe)
        {
            CD cd = new CD(album, groupe);
            this.CDs.Add(cd);
            this.SaveChanges();
            return cd;
        }

        public CD GetCdById(int cdId)
        {
            return this.CDs.Find(cdId);
        }

        public List<CD> GetCdsByGroupe(string groupe)
        {
            //Ici aucune requête n'est encore faite
            IQueryable<CD> query = this.CDs
                .Where(cd => cd.Groupe == groupe);

            //C'est ici que l'accès à la base est réalisée
            var cds = query.ToList();
            return query.ToList();
        }

        public void DeleteCD(int cdId)
        {
            var CdToDelete = this.GetCdById(cdId);
            this.CDs.Remove(CdToDelete);
            this.SaveChanges();
        }

        public void EditCd(int cdId, string albumModified)
        {
            var cd = this.GetCdById(cdId);
            cd.TitreDeLObjet = albumModified;
            this.SaveChanges();
        }
    }
}
