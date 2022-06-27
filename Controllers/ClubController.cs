using Microsoft.AspNetCore.Mvc;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;
using ModelTrainWebApp.ViewModels;

namespace ModelTrainWebApp.Controllers
{
    // Project requirement: Create an additional class which inherits one or more properties from its parent
    public class ClubController : Controller    //ClubController inherits from Controller 
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;

        public ClubController(IClubRepository clubRepository, IPhotoService photoService)
        {
            _clubRepository = clubRepository;
            _photoService = photoService;
        }

        [HttpGet]        
        public async Task<IActionResult> Index()    //Controller
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();    //Model
            return View(clubs);     //View
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel clubVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(clubVM.Image);

                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Email = clubVM.Email,
                    Image = result.Url.ToString(),
                    Address = new Address
                    { 
                        Street = clubVM.Address.Street,
                        City = clubVM.Address.City,
                        State = clubVM.Address.State
                    }
                };
                _clubRepository.Add(club);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(clubVM);

        }
    }
}
