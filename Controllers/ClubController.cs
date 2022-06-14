using Microsoft.AspNetCore.Mvc;
using ModelTrainWebApp.Data;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()    //Controller
        {
            List<Club> clubs = _context.Clubs.ToList();    //Model
            return View(clubs);     //View
        }
    }
}
