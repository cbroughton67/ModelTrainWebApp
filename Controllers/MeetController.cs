﻿using Microsoft.AspNetCore.Mvc;
using ModelTrainWebApp.Data;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Controllers
{
    public class MeetController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MeetController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()    //Controller
        {
            List<Meet> meets = _context.Meets.ToList();     //Model
            return View(meets);     //View
        }
    }
}
