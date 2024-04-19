using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Core.Model
{
    public class Dvd: ObjetDePret
    {
        public Dvd(string titreDeLObjet) : base(titreDeLObjet)
        {
        }
        public Dvd()
        {

        }
        public string Poster { get; set; }
        

    }
}
