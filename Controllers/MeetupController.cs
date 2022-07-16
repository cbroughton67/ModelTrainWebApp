using Microsoft.AspNetCore.Mvc;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;
using ModelTrainWebApp.ViewModels;
using System.Text.RegularExpressions;

namespace ModelTrainWebApp.Controllers
{
    //***************************************************************************************************
    // Required Feature: Create an additional class which inherits one or more properties from its parent
    //***************************************************************************************************
    public class MeetupController : Controller    //MeetController inherits from the Microsoft.AspNetCore.Mvc.Controller  class
    {
        private readonly IMeetupRepository _meetupRepository;
        private readonly IPhotoService _photoService;

        public MeetupController(IMeetupRepository meetupRepository, IPhotoService photoService)
        {        
            _meetupRepository = meetupRepository;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()    //Controller
        {
            IEnumerable<Meetup> meetups = await _meetupRepository.GetAll();    //Model
            return View(meetups);     //View
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            Meetup meetup = await _meetupRepository.GetByIdAsync(id);
            return View(meetup);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //**********************************************************************************************************************************************
        // Required Feature: Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application
        //**********************************************************************************************************************************************
        [HttpPost]
        public async Task<IActionResult>Create(CreateMeetupViewModel meetupVM)
        {
            //*********************************************************************************************************************************************
            // Required Feature: Implement a regular expression (regex) to ensure a field (email address) is always stored and displayed in the same format
            //*********************************************************************************************************************************************
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!regex.IsMatch(meetupVM.Email))
            {
                ModelState.AddModelError("", "Email format is invalid");
                ViewBag.InvalidEmailMessage = "Invalid Email Format. Please correct and try again.";
                return View(meetupVM);
            }


            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(meetupVM.Image);

                //***************************************************************************************************************************************************************
                // Required Feature: Create at least one class, create at least one object of that class, and populate it with data. Use or display the data in your application
                //***************************************************************************************************************************************************************
                var meetup = new Meetup
                {
                    Title = meetupVM.Title,
                    Description = meetupVM.Description,
                    Email = meetupVM.Email,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = meetupVM.Address.Street,
                        City = meetupVM.Address.City,
                        State = meetupVM.Address.State
                    }
                };

                _meetupRepository.Add(meetup);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
                ViewBag.PhotoFailed = "Photo failed to upload";
            }

            return View(meetupVM);
        }


        //**********************************************************************************************************************************************
        // Required Feature: Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application
        //**********************************************************************************************************************************************
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var meetup = await _meetupRepository.GetByIdAsync(id);
            if (meetup == null) return View("Error");

            var meetupVM = new EditMeetupViewModel
            {
                Title = meetup.Title,
                Description = meetup.Description,
                AddressID = meetup.AddressId,
                Address = meetup.Address,
                StartTime = meetup.StartTime,
                //Image = meetup.Image,
                Email = meetup.Email,
                MeetupCategory = meetup.MeetupCategory
            };

            return View(meetupVM);
        }

        //**********************************************************************************************************************************************
        // Required Feature: Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application
        //**********************************************************************************************************************************************
        [HttpPost]
        public async Task<IActionResult>Edit(int id, EditMeetupViewModel meetupVM)
        {
            //*********************************************************************************************************************************************
            // Required Feature: Implement a regular expression (regex) to ensure a field (email address) is always stored and displayed in the same format
            //*********************************************************************************************************************************************

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!regex.IsMatch(meetupVM.Email))
            {
                ModelState.AddModelError("", "Email format is invalid");
                ViewBag.InvalidEmailMessage = "Invalid Email Format. Please correct and try again.";
                return View(meetupVM);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit event");
                return View("Edit", meetupVM);
            }

            var userMeetup = await _meetupRepository.GetByIdAsyncNoTracking(id);

            if (userMeetup != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userMeetup.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(meetupVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(meetupVM.Image);

                //***************************************************************************************************************************************************************
                // Required Feature: Create at least one class, create at least one object of that class, and populate it with data. Use or display the data in your application
                //***************************************************************************************************************************************************************
                var meetup = new Meetup
                {
                    Id = id,
                    Title = meetupVM.Title,
                    Description = meetupVM.Description,
                    StartTime = meetupVM.StartTime,
                    Email = meetupVM.Email,
                    MeetupCategory = meetupVM.MeetupCategory,
                    AddressId = meetupVM.AddressID,
                    Address = meetupVM.Address,
                    Image = photoResult.Url.ToString()
                };

                _meetupRepository.Update(meetup);
                return RedirectToAction("Index");
            }
            else
            {
                return View(meetupVM);
            }
        }

        //**********************************************************************************************************************************************
        // Required Feature: Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application
        //**********************************************************************************************************************************************
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var meetupDetails = await _meetupRepository.GetByIdAsync(id);
            if (meetupDetails == null) return View("Error");
            return View(meetupDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>DeleteMeetup(int id)
        {
            var MeetupDetails = await _meetupRepository.GetByIdAsync(id);

            if (MeetupDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(MeetupDetails.Image))
            {
                _ = _photoService.DeletePhotoAsync(MeetupDetails.Image);
            }

            _meetupRepository.Delete(MeetupDetails);
            return RedirectToAction("Index");
        }

    }
}

