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
    public class AppointmentConsultationController : Controller
    {
        private readonly IAppointmentConsultationService _appointmentconsultationService;

        public AppointmentConsultationController(IAppointmentConsultationService appointmentconsultationService)
        {

            _appointmentconsultationService = appointmentconsultationService;

        }

        public ActionResult Index()
        {
            var appointmentconsultations = _appointmentconsultationService.GetAll();
            return View(appointmentconsultations);
        }

        public ActionResult Details(int id)
        {
            var appointmentconsultation = _appointmentconsultationService.GetbyId(id);
            return View(appointmentconsultation);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentConsultationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var appointmentconsultation = _appointmentconsultationService.Create(obj);
                if (!appointmentconsultation.IsValid)
                {
                    return View(appointmentconsultation);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Edit(int id)
        {
            var appointmentconsultation = _appointmentconsultationService.GetbyId(id);
            return View(appointmentconsultation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppointmentConsultationViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var appointmentconsultation = _appointmentconsultationService.Update(obj);
                if (!appointmentconsultation.IsValid)
                {
                    return View(appointmentconsultation);
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var appointmentconsultation = _appointmentconsultationService.GetbyId(id);
            return View(appointmentconsultation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AppointmentConsultationViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var appointmentconsultation = _appointmentconsultationService.Delete(obj.Id);
                if (!appointmentconsultation.IsValid)
                {
                    return View(appointmentconsultation);
                }
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
