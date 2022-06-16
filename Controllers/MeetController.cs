using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelTrainWebApp.Data;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Controllers
{
    public class MeetController : Controller
    {
        private readonly IMeetRepository _meetRepository;
        public MeetController(IMeetRepository meetRepository    )
        {
            _meetRepository = meetRepository;
        }
        public async Task<IActionResult> Index()    //Controller
        {
            IEnumerable<Meet> meets = await _meetRepository.GetAll();    //Model
            return View(meets);     //View
        }

        public async Task<IActionResult> Detail(int id)
        {
            Meet meet = await _meetRepository.GetByIdAsync(id);
            return View(meet);
        }
    }
}

