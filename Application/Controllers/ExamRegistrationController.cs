using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class ExamRegistrationController : Controller
    {
        private readonly IExamRegistrationService _examregistrationService;
        
        public ExamRegistrationController(IExamRegistrationService examregistrationService)
        {

            _examregistrationService = examregistrationService;

        }

        public ActionResult Index()
        {
            var examregistrations = _examregistrationService.GetAll();
            return View(examregistrations);
        }

        public ActionResult Details(int id)
        {
            var examregistration = _examregistrationService.GetbyId(id);
            return View(examregistration);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamRegistrationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var examregistration = _examregistrationService.Create(obj);
                if (!examregistration.IsValid)
                {
                    return View(examregistration);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Edit(int id)
        {
            var examregistration = _examregistrationService.GetbyId(id);
            return View(examregistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamRegistrationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var examregistration = _examregistrationService.Update(obj);
                if (!examregistration.IsValid)
                {
                    return View(examregistration);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var examregistration = _examregistrationService.GetbyId(id);
            return View(examregistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ExamRegistrationViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var examregistration = _examregistrationService.Delete(obj.Id);
                if (!examregistration.IsValid)
                {
                    return View(examregistration);
                }
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
