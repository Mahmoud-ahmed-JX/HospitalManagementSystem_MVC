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
       
       

        #region Get All Medical Records

        public async Task<IActionResult> Index()
        {
            var medicalRecords = await _medicalRecordService.GetAllMedicalRecordsAsync();
            return View(medicalRecords);
        }


        #endregion

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

        #region Get Record Details by patient id


        public async Task<IActionResult> Details(int patientId)
        {
            var medicalRecord = await _medicalRecordService.GetMedicalRecordsByPatientIdAsync(patientId);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);
        }

        #endregion

        #region Get Medical Record by Appointment Id

        public async Task<IActionResult> GetByAppointmentId(int appointmentId)
        {
            var medicalRecord = await _medicalRecordService.GetMedicalRecordByAppointmentIdAsync(appointmentId);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);
        }
        #endregion

        #region Edit Medical Record

        public async Task<IActionResult> Edit(int id)
        {
            var medicalRecord = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MedicalRecordUpdateDto updateMedicalRecord)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And Missing Feilds");
                return View(nameof(Edit), updateMedicalRecord);
            }
            await _medicalRecordService.UpdateMedicalRecordAsync(updateMedicalRecord);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete Medical Record

        public async Task<IActionResult> Delete(int id)
        {
            var medicalRecord = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromForm]int id)
        {
            await _medicalRecordService.DeleteMedicalRecordAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion




    }
}
