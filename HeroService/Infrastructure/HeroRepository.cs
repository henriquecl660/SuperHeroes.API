using BussinessDomains;
using HeroService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HeroService.Infrastructure
{
    public class HeroRepository : IHeroRepository
    {
        private readonly ConnectionContext _context;

        public HeroRepository(ConnectionContext context) // DbContext injected here
        {
            _context = context;
        }

        public async Task<List<Herois>> Delete(int id)
        {

            var herois = await _context.Herois
             .Where(x => x.Id == id).AsNoTracking().ToListAsync();

             _context.Herois.Remove(herois.First());
            _context.SaveChanges();

            return await GetById(id);

        }

        public async Task<List<Herois>> GetAll()
        {


            var herois =
                await _context.Herois.AsNoTracking().ToListAsync();

            return herois;
        }

        public async Task<List<Herois>> GetById(int id)
        {
            var herois =
                await _context.Herois
                .Where(x => x.Id == id)
                .AsNoTracking()
                .ToListAsync();

            return herois;
        }

        public async Task<List<Herois>> Put(Herois heroi)
        {
   
                Herois newHeroi = new Herois(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento, heroi.Altura, heroi.Peso);


                _context.Herois.Update(newHeroi);
                _context.SaveChanges();
                return await GetById(heroi.Id);

        }


        public async Task<List<Herois>> Create(Herois heroi)
        {

            Herois newHeroi = new Herois(heroi.Id, heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento, heroi.Altura, heroi.Peso);


            _context.Herois.Add(newHeroi);
            _context.SaveChanges();
            return await GetById(heroi.Id);

        }

        public async Task<List<Superpoderes>> GetAllSuperpoderes()
        {
            var superpoderes =
            await _context.Superpoderes.AsNoTracking().ToListAsync();

            return superpoderes;
        }

        public async Task<List<HeroisSuperpoderes>> AssociarHeroiSuperpoder(int heroiId, [FromBody]List<int> SuperpoderIdList)
        {



            HeroisSuperpoderes newHeroiSuperpoder = new HeroisSuperpoderes();

            newHeroiSuperpoder.HeroiId = heroiId;
            newHeroiSuperpoder.SuperpoderId = SuperpoderIdList;

       
            _context.HeroisSuperpoderes.Add(newHeroiSuperpoder);
            _context.SaveChanges();

            var heroisSuperpoderes =
               await _context.HeroisSuperpoderes
               .Where(x => x.HeroiId == heroiId)
               .AsNoTracking()
               .ToListAsync();

            return heroisSuperpoderes;

       
        }
    }
}
