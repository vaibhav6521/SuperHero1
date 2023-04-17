using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace SuperHero1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       
       
         

        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;        
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero1>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero1>>> Get(int id)
        {
            var hero=await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            
                return BadRequest("Here not found ");
            
            return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<List<SuperHero1>>> AddHero(SuperHero1 hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();  
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero1>>> UpdateHero(SuperHero1 request)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbhero == null)

                return BadRequest("Here not found ");

            dbhero.Name = request.Name;
            dbhero.FirstName = request.FirstName;
            dbhero.LastName = request.LastName;
            dbhero.Place= request.Place;

           await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero1>>> DeleteHero(int id)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(id);
            if (dbhero == null)

                return BadRequest("Here not found ");

            _context.SuperHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();  
            return Ok(await _context.SuperHeroes.ToListAsync());  
        }
    }
}
