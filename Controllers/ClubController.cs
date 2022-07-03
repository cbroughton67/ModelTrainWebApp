using Microsoft.AspNetCore.Mvc;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;
using ModelTrainWebApp.ViewModels;
using System.Text.RegularExpressions;

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
            bool emailIsValid = true;

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!regex.IsMatch(clubVM.Email))
            {
                emailIsValid = false;
                clubVM.Email = String.Empty;
            }

            if (ModelState.IsValid && emailIsValid)
            {

                // Test clubVM.Email format here

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
            else if (!emailIsValid)
            {
                ModelState.AddModelError("", "Email format is invalid");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(clubVM);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            if (club == null) return View("Error");

            var clubVM = new EditClubViewModel
            {
                Title = club.Title,
                Description = club.Description,
                Website = club.Website,
                Email = club.Email,
                ClubCategory = club.ClubCategory,
                AddressID = club.AddressID,
                Address = club.Address
                //Image = club.Image
            };

            return View(clubVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubViewModel clubVM)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", clubVM);
            }

            var userClub = await _clubRepository.GetByIdAsyncNoTracking(id);

            if (userClub != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userClub.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(clubVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(clubVM.Image);
                
                var club = new Club
                
                {
                    Id = id,
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressID = clubVM.AddressID,
                    Address = clubVM.Address,
                    Email = clubVM.Email
                };

                _clubRepository.Update(club);
                return RedirectToAction("Index");
            }
            else
            {
                return View(clubVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var clubDetails = await _clubRepository.GetByIdAsync(id);
            if (clubDetails == null) return View("Error");
            return View(clubDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var clubDetails = await _clubRepository.GetByIdAsync(id);

            if (clubDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(clubDetails.Image))
            {
                _ = _photoService.DeletePhotoAsync(clubDetails.Image);
            }

            _clubRepository.Delete(clubDetails);
            return RedirectToAction("Index");
        }
    }
}
