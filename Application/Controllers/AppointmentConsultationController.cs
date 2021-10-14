using Domain.Models;
using Microsoft.AspNetCore.Http;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;

namespace Application.Controllers
{
    public class AppointmentConsultationController : Controller
    {
        private readonly IAppointmentConsultationService _appointmentconsultationService;
        private readonly IPatientService _patientService;
        private readonly ITypeOfExamService _typeOfExamService;
        private readonly IExamRegistrationService _examRegistrationService;


        public AppointmentConsultationController(IAppointmentConsultationService appointmentconsultationService,
            IPatientService patientService, ITypeOfExamService typeOfExamService, IExamRegistrationService examRegistrationService)
        {

            _appointmentconsultationService = appointmentconsultationService;
            _patientService = patientService;
            _typeOfExamService = typeOfExamService;
            _examRegistrationService = examRegistrationService;

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
            FillTypeOfExam(0);
            FillExamRegistration(0);
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
                    FillTypeOfExam(obj.TypeOfExamId);
                    FillExamRegistration(obj.ExamRegistrationId);
                    return View(appointmentconsultation);
                }
                return RedirectToAction("Index");
            }
            obj.IsValid = true;
            FillTypeOfExam(obj.TypeOfExamId);
            FillExamRegistration(obj.ExamRegistrationId);
            return View(obj);
        }

        public ActionResult Edit(int id)
        {
            var appointmentconsultation = _appointmentconsultationService.GetbyId(id);
            FillTypeOfExam(appointmentconsultation.ExameRegistration.TypeOfExamId);
            FillExamRegistration(appointmentconsultation.ExamRegistrationId);
            appointmentconsultation.IsValid = true;
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
                    FillTypeOfExam(obj.TypeOfExamId);
                    FillExamRegistration(obj.ExamRegistrationId);
                    return View(appointmentconsultation);
                }
                return RedirectToAction("Index");
            }
            FillTypeOfExam(obj.TypeOfExamId);
            FillExamRegistration(obj.ExamRegistrationId);
            obj.IsValid = true;
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

        private void FillTypeOfExam(int id)
        {
            var typeList = new List<TypeOfExamViewModel>();
            if(id == 0)
            {
                typeList.Add(new TypeOfExamViewModel() { Id = 0, Name = "Selecione um tipo do Exame" });
            }
            var typeListDb = _typeOfExamService.GetAll();
            foreach(var alt in typeListDb)
            {
                typeList.Add(alt);
            }
            ViewBag.TypeOfExamId = new SelectList(typeList, "Id", "Name");

        }
        private void FillExamRegistration(int id)
        {
            if(id == 0)
            {
                var examsList = new List<ExamRegistrationViewModel>();
                examsList.Add(new ExamRegistrationViewModel());
                ViewBag.ExamRegistrationId = new SelectList(examsList, "Id", "Name");
            }
            else
            {
                ViewBag.ExamRegistrationId = new SelectList
                   (
                       _examRegistrationService.GetByTypeOfExam(id),
                       "Id",
                       "Name",
                       id
                   );
            }
     
        }



        public ActionResult FillPatient(string nameOrCpf)
        {
            var patient = _patientService.GetByNameOrCpf(nameOrCpf);
            return Json(patient);
        }

        public ActionResult FillExamRegistrationByIdType(int id)
        {
            IEnumerable<ExamRegistrationViewModel> list = _examRegistrationService.GetByTypeOfExam(id);
            return Json(list.Select(a => new { a.Id, a.Name }).ToList());
        }
    }
}
