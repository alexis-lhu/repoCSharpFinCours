namespace Mediatheque.Core.Model
{

    public class CD : ObjetDePret
    {
        public string Groupe { get; set; }

        public CD(string titreDeLObjet, string groupe) : base(titreDeLObjet)
        {
            this.Groupe = groupe;
        }
        public override string ToString()
        {
            return $"[{this.Id}] {this.TitreDeLObjet} du groupe {this.Groupe}";
        }
        public Etagere? Etagere { get; set; }

        public int? EtagereId { get; set; }
    }
}
