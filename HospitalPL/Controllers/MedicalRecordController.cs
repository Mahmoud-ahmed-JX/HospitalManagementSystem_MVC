using HospitalBLL.DTOs.MedicalRecordDtos;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPL.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }
        //Index, Create, Details

        //????????
        public async Task<IActionResult> Index(int patientId)
        {
            var medicalRecords = await _medicalRecordService.GetMedicalRecordsByPatientIdAsync(patientId);
            return View(medicalRecords);
        }
        #region Create Record model
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMedicalRecordDto createMedicalRecord)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And Missing Feilds");
                return View(nameof(Create), createMedicalRecord);
            }
            await _medicalRecordService.CreateMedicalRecordAsync(createMedicalRecord);
            return RedirectToAction(nameof(Index));

        }
        #endregion

       


    }
}
