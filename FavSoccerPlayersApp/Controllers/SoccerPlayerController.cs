using FavSoccerPlayersApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FavSoccerPlayersApp.Controllers
{
    public class SoccerPlayerController : Controller
    {
        private readonly SoccerPlayersDbContext _context;

        public SoccerPlayerController(SoccerPlayersDbContext context)
        {
            _context = context;
        }

        // use to view all soccer player list 
        public async Task<IActionResult> Index()
        {
            var players = await _context.SoccerPlayers.OrderBy(p => p.Name).ToListAsync();
            return View(players);
        }

        //used to  View details of a individual player
        public async Task<IActionResult> Details(int id)
        {
            var player = await _context.SoccerPlayers.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // this is use to Add a new player
        public IActionResult Create()
        {
            return View();
        }

        // Add a new player 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SoccerPlayer player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                TempData["Message"] = "New player added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        //it Can Edit a player 
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _context.SoccerPlayers.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SoccerPlayer player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Player details updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoccerPlayerExists(player.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; 
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // it will check player exists or not 
        private bool SoccerPlayerExists(int id)
        {
            return _context.SoccerPlayers.Any(e => e.Id == id);
        }
    }
}
