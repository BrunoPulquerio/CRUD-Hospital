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
    public class TypeOfExamController : Controller
    {
        private readonly ITypeOfExamService _typeofexamService;

        public TypeOfExamController(ITypeOfExamService typeofexamService)
        {

            _typeofexamService = typeofexamService;

        }

        public ActionResult Index()
        {
            var typeofexams = _typeofexamService.GetAll();
            return View(typeofexams);
        }

        public ActionResult Details(int id)
        {
            var typeofexam = _typeofexamService.GetbyId(id);
            typeofexam.IsValid = true;
            return View(typeofexam);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeOfExamViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var typeofexam = _typeofexamService.Create(obj);
                if (!typeofexam.IsValid)
                {
                    return View(typeofexam);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Edit(int id)
        {
            var typeofexam = _typeofexamService.GetbyId(id);
            typeofexam.IsValid = true;
            return View(typeofexam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeOfExamViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var typeofexam = _typeofexamService.Update(obj);
                if (!typeofexam.IsValid)
                {
                    return View(typeofexam);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var typeofexam = _typeofexamService.GetbyId(id);
            return View(typeofexam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TypeOfExamViewModel obj)
        {

                var typeofexam = _typeofexamService.Delete(obj.Id);
                if (!typeofexam.IsValid)
                {
                    return View(typeofexam);
                }
                return RedirectToAction("Index");
        }
    }
}
