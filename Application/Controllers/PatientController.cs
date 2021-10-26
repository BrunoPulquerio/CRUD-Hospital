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
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) {

            _patientService = patientService;
        
        }

        public ActionResult Index()
        {
            var patients = _patientService.GetAll();
            return View(patients);
        }

        public ActionResult Details(int id)
        {
            var patient = _patientService.GetbyId(id);
            patient.IsValid = true;
            return View(patient);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var patient = _patientService.Create(obj);
                if (!patient.IsValid)
                {
                    return View(patient);
                }
                return RedirectToAction("Index");
            }
            obj.IsValid = true;
            return View(obj);
        }

        public ActionResult Edit(int id)
        {
            var patient = _patientService.GetbyId(id);
            patient.IsValid = true;
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var patient = _patientService.Update(obj);
                if (!patient.IsValid)
                {
                    return View(patient);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var patient = _patientService.GetbyId(id);
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PatientViewModel obj)
        {
                var patient = _patientService.Delete(obj.Id);
                if (!patient.IsValid)
                {
                    return View(patient);
                }
                return RedirectToAction("Index");
        }
    }
}
