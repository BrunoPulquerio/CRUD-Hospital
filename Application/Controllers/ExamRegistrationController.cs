using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ITypeOfExamService _typeOfExamService;
        
        public ExamRegistrationController(IExamRegistrationService examregistrationService, ITypeOfExamService typeOfExamService)
        {

            _examregistrationService = examregistrationService;
            _typeOfExamService = typeOfExamService;

        }

        public ActionResult Index()
        {
            var examregistrations = _examregistrationService.GetAll();
            return View(examregistrations);
        }

        public ActionResult Details(int id)
        {
            var examregistration = _examregistrationService.GetbyId(id);
            examregistration.IsValid = true;
            return View(examregistration);
        }

        public ActionResult Create()
        {
            FillTypeOfExam(0);
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
                    FillTypeOfExam(0);
                    return View(examregistration);
                }
                return RedirectToAction("Index");
            }
            FillTypeOfExam(obj.TypeOfExamId);
            return View(obj);
        }

        public ActionResult Edit(int id)
        {
            var examregistration = _examregistrationService.GetbyId(id);
            FillTypeOfExam(examregistration.TypeOfExamId);
            examregistration.IsValid = true;
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
                    FillTypeOfExam(examregistration.TypeOfExamId);
                    return View(examregistration);
                }
                return RedirectToAction("Index");
            }
            FillTypeOfExam(obj.TypeOfExamId);
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var examregistration = _examregistrationService.GetbyId(id);
            examregistration.IsValid = true;
            return View(examregistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ExamRegistrationViewModel obj)
        {
                var examregistration = _examregistrationService.Delete(obj.Id);
                if (!examregistration.IsValid)
                {
                    return View(examregistration);
                }
                return RedirectToAction("Index");
        }

        private void FillTypeOfExam(int id)
        {
            ViewBag.TypeOfExamId = new SelectList
              (
                  _typeOfExamService.GetAll(),
                  "Id",
                  "Name",
                  id
              );
        }
    }
}
