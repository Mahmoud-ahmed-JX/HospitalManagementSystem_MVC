using HospitalBLL.DTOs.DoctorDtos;
using HospitalBLL.Services.Classes;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        //Index, Create, Edit, Delete, Details
        #region Get All Doctors 
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return View(doctors);
        }

        #endregion

        #region Get Doctor By Id
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = "Id of Doctor can not be 0 or negative number";
                return RedirectToAction(nameof(Index));
            }
            var doctor=await _doctorService.GetDoctorByIdAsync(id);
            if(doctor is null)
            {
                TempData["ErrorMrssage"] = "Doctor Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);

        }

        #endregion

        #region Create 

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateDto doctorCreate)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And Missing Feilds");
                return View(nameof(Create), doctorCreate);
            }
            await _doctorService.CreateDoctorAsync(doctorCreate);
           return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = "Id of Doctor can not be 0 or negative number";
                return RedirectToAction(nameof(Index));
            }
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor is null)
            {
                TempData["ErrorMrssage"] = "Doctor Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DoctorUpdateDto doctorUpdate)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And Missing Feilds");
                return View(nameof(Create), doctorUpdate);
            }
            await _doctorService.UpdateDoctorAsync(doctorUpdate);
            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region Delete 

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = "Id of doctor can not be 0 or negative number";
                return RedirectToAction(nameof(Index));
            }
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor is null)
            {
                TempData["ErrorMrssage"] = "Patient Not Found";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.patientId = id;
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }



        #endregion

        #region Get Doctor By Department
       
        public async Task<IActionResult> GetByDepartment([FromForm] int departmentId)
        {
            if (departmentId <= 0)
            {
                TempData["ErrorMassage"] = "Id of Department can not be 0 or negative number";
                return RedirectToAction(nameof(Index));
            }
            var doctors = await _doctorService.GetByDepartmentAsync(departmentId);
            return View("Index", doctors);
        }
        #endregion

        #region Get By Specialization

        [HttpPost]
        public async Task<IActionResult> GetBySpecialization([FromForm] string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
            {
                TempData["ErrorMassage"] = "Specialization can not be null or empty";
                return RedirectToAction(nameof(Index));
            }
            var doctors = await _doctorService.GetBySpecializationAsync(specialization);
            return View("Index", doctors);
        }
        #endregion

    }
}
