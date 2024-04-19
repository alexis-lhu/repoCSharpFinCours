using Mediatheque.Core.Model;

namespace Mediatheque.Core.DAL
{
    public interface IApplicationDbContext
    {
        CD AddCd(string album, string groupe);
        void DeleteCD(int cdId);
        void EditCd(int cdId, string albumModified);
        CD GetCdById(int cdId);
        List<CD> GetCDs();
        List<CD> GetCdsByGroupe(string groupe);
    }
}