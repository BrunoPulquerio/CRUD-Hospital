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

        // GET: PatientController
        public ActionResult Index()
        {
            var patients = _patientService.GetAll();
            return View(patients);
        }

        // GET: PatientController/Details/5
        public ActionResult Details(int id)
        {
            var patient = _patientService.GetbyId(id);
            return View(patient);
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var patient = _patientService.Create(obj);
                if (!patient.IsValid) {
                    return View(patient);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id)
        {
            var patient = _patientService.GetbyId(id);
            return View(patient);
        }

        // POST: PatientController/Edit/5
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

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id)
        {
            var patient = _patientService.GetbyId(id);
            return View(patient);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PatientViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var patient = _patientService.Delete(obj.Id);
                if (!patient.IsValid)
                {
                    return View(patient);
                }
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
