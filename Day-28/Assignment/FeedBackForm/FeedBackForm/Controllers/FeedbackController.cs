﻿using Microsoft.AspNetCore.Mvc;
using FeedBackForm.Models;
using System.Collections.Generic;


namespace FeedBackForm.Controllers
{
    public class FeedbackController : Controller
    {
        private static  List<Feedback> feedbackList = new List<Feedback>();
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                return RedirectToAction("List");

            }
            return View(feedback);
        }


        public IActionResult List()
        {
            return View(feedbackList);
        }
    }
}
