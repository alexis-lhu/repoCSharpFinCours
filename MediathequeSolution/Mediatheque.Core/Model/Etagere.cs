using System.ComponentModel.DataAnnotations;

namespace Mediatheque.Core.Model
{
    public class Etagere
    {
        public int Id { set; get; }

        [MaxLength(50)]
        public string Emplacement { get; set; }

        public List<CD> CDs {get;set;}

    }
}
