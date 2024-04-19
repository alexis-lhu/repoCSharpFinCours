using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public class MediathequeService : IMediathequeService
    {

        private List<ObjetDePret> _fondDeCommerce = new List<ObjetDePret>();
        private INotationService _notationService;
        private IApplicationDbContext _applicationDbContext;


        public MediathequeService(IApplicationDbContext applicationDbContext)
        {
            // _notationService = notationService;
            _applicationDbContext = applicationDbContext;
        }

        public CD AddCd(string album, string groupe)
        {
            return _applicationDbContext.AddCd(album, groupe);
        }

        public void AddObjet(ObjetDePret objet)
        {
            _fondDeCommerce.Add(objet);
        }

        public void DeleteCD(int cdId)
        {
            throw new NotImplementedException();
        }

        public void EditCd(int cdId, string albumModified)
        {
            throw new NotImplementedException();
        }

        public CD GetCdById(int cdId)
        {
            throw new NotImplementedException();
        }

        public List<CD> GetCDs()
        {
            throw new NotImplementedException();
        }

        public List<CD> GetCdsByGroupe(string groupe)
        {
            return this._applicationDbContext.GetCDs().Where(cd => cd.Groupe == groupe).ToList();
            
        }

        public int GetNombreObjet()
        {
            return _fondDeCommerce.Count;
        }
        
    }
}
