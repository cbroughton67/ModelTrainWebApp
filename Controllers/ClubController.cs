using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelTrainWebApp.Data;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()    //Controller
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();    //Model
            return View(clubs);     //View
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }
    }
}
