using BussinessDomains;
using HeroService.Infrastructure;
using HeroService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HeroService.Endpoints
{
    public class HeroEndpoints
    {


        public static void Map(WebApplication endpoints)
        {

           
            endpoints.MapPost("/heroes/obterpoder", async (int heroiId, List<int> SuperpoderIdList, IHeroRepository _heroRepository) =>
            {



                return Results.Ok(await _heroRepository.AssociarHeroiSuperpoder(heroiId, SuperpoderIdList));


            })
            .WithName("ObterPoderHeroes")
            .WithOpenApi();



            endpoints.MapPost("/heroes", async (Herois herois, IHeroRepository _heroRepository) =>
            {

             

                return Results.Ok(await _heroRepository.Create(herois));


            })
            .WithName("CreateHeroes")
            .WithOpenApi();


            endpoints.MapPut("/heroes", async (Herois herois,IHeroRepository _heroRepository) =>
            {
                List<Herois> heroes = await _heroRepository.GetById(herois.Id);


                if (heroes.Count() == 0)
                {
                    return Results.NotFound();
                }

                else
                {
                     await _heroRepository.Put(herois);


                    List<Herois> heroesAfter = await _heroRepository.GetById(herois.Id);

                    return Results.Ok(heroesAfter);

                }

            })
            .WithName("PutHeroes")
            .WithOpenApi();

            endpoints.MapGet("/heroes", async (IHeroRepository _heroRepository) =>
            {
                List<Herois> heroes = await _heroRepository.GetAll();


                if (heroes.Count() == 0)
                {
                    return Results.NotFound();
                }

                else
                {
                    return Results.Ok(heroes);

                }

            })
            .WithName("GetAllHeroes")
            .WithOpenApi();


            endpoints.MapGet("/heroes/superpoderes", async (IHeroRepository _heroRepository) =>
            {
                List<Superpoderes> superpoderes = await _heroRepository.GetAllSuperpoderes();


                if (superpoderes.Count() == 0)
                {
                    return Results.NotFound();
                }

                else
                {
                    return Results.Ok(superpoderes);

                }

            })
            .WithName("GetAllSuperpoderes")
            .WithOpenApi();

            endpoints.MapGet("/heroes/{id:int}", async (int id, IHeroRepository _heroRepository) =>
            {
                List<Herois> heroes = await _heroRepository.GetById(id);


                if (heroes.Count() == 0)
                {
                    return Results.NotFound();
                }

                else
                {
                    return Results.Ok(heroes);

                }



            })
            .WithName("GetHeroes")
            .WithOpenApi();


            endpoints.MapDelete("/heroes/{id:int}", async (int id, IHeroRepository _heroRepository) =>
            {
                List<Herois> heroes = await _heroRepository.GetById(id);


                if (heroes.Count() == 0)
                {
                    return Results.NotFound();
                }

                else
                {
                    await _heroRepository.Delete(id);

                    List<Herois> heroesVerification = await _heroRepository.GetById(id);

                    if (heroesVerification.Count() == 0)
                    {
                        return Results.Ok();
                    }

                    else
                    {
                        return Results.InternalServerError();
                    }

                }



            })
            .WithName("DeleteHeroes")
            .WithOpenApi();





        }
    }

}
