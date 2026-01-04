using AutoMapper.Execution;
using HospitalBLL.DTOs.PatientDtos;
using HospitalBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPL.Controllers
{
    public class PatientController(IPatientService patientService) : Controller
    {
        private readonly IPatientService _patientService = patientService;
        //Index, Details, Edit, Delete, Create
        #region Get All Patients
        public async Task<IActionResult> Index()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return View(patients); // This must match @model in the view
        }
        #endregion

        #region Get Patient Data 
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = "Id of patient can not be 0 or negative number";
                return RedirectToAction(nameof(Index));
            }
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient is null)
            {
                TempData["ErrorMrssage"] = "Patient Not Found";
                return RedirectToAction(nameof(Index));
            }
            
            return View(patient);
        }

        #endregion

        #region Create Patient
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateDto patient)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And Missing Feilds");
                return View(nameof(Create), patient);
            }

            await _patientService.CreatePatientAsync(patient);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update Patient

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return View(patient);
        }


        //[HttpPost]
        //public async Task<IActionResult> Edit(PatientDto patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _patientService.UpdatePatientAsync(patient);
        //        return RedirectToAction("Index");
        //    }
        //    return View(patient);

        //} 
        #endregion

        #region Delete Patient 
        
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = "Id of patient can not be 0 or negative number";
                return RedirectToAction(nameof(Index));
            }
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient is null)
            {
                TempData["ErrorMrssage"] = "Patient Not Found";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.patientId = id;
            return View(patient);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Search
        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {
            var patients = await _patientService.SearchPatientsAsync(name);
            return View(nameof(Index), patients);
        }

        #endregion


    }
}
