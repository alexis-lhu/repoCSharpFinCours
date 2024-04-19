using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public interface IMediathequeService
    {
        CD AddCd(string album, string groupe);
        void AddObjet(ObjetDePret objet);
        void DeleteCD(int cdId);
        void EditCd(int cdId, string albumModified);
        CD GetCdById(int cdId);
        List<CD> GetCDs();
        List<CD> GetCdsByGroupe(string groupe);
        int GetNombreObjet();
    }
}