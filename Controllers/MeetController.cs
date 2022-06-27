using Microsoft.AspNetCore.Mvc;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;
using ModelTrainWebApp.ViewModels;

namespace ModelTrainWebApp.Controllers
{
    // Project requirement: Create an additional class which inherits one or more properties from its parent
    public class MeetController : Controller    //MeetController inherits from Controller
    {
        private readonly IMeetRepository _meetRepository;
        private readonly IPhotoService _photoService;
        
        public MeetController(IMeetRepository meetRepository, IPhotoService photoService)
        {
            _meetRepository = meetRepository;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()    //Controller
        {
            IEnumerable<Meet> meets = await _meetRepository.GetAll();    //Model
            return View(meets);     //View
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            Meet meet = await _meetRepository.GetByIdAsync(id);
            return View(meet);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetViewModel meetVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(meetVM.Image);

                var meet = new Meet
                {
                    Title = meetVM.Title,
                    Description = meetVM.Description,
                    Email = meetVM.Email,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = meetVM.Address.Street,
                        City = meetVM.Address.City,
                        State = meetVM.Address.State
                    }
                };

                _meetRepository.Add(meet);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(meetVM);
        }
    }
}

