using BussinessDomains;
using Microsoft.AspNetCore.Mvc;

namespace HeroService.Repositories
{
    public interface IHeroRepository
    {

        Task<List<HeroisSuperpoderes>> AssociarHeroiSuperpoder(int heroiId, List<int> SuperpoderIdList);
        Task<List<Superpoderes>> GetAllSuperpoderes();

        Task<List<Herois>> Create(Herois heroi);
        Task<List<Herois>> GetAll();

        Task<List<Herois>> GetById(int id);
        Task<List<Herois>> Put(Herois heroi);

        Task<List<Herois>> Delete(int id);

    }
}
