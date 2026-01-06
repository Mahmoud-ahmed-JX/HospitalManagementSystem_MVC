using HospitalBLL.DTOs.AppointmentDtos;
using HospitalBLL.Services.Classes;
using HospitalBLL.Services.Interfaces;
using HospitalDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace HospitalPL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;


        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        //Index, Book, Cancel, Details
        #region Get All Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return View(appointments);
        } 
        #endregion


        #region Book
        public IActionResult Book()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Book(AppointmentCreateDto appointmentCreate)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And Missing Feilds");
                return View(nameof(Book), appointmentCreate);
            }

            await _appointmentService.BookAppointmentAsync(appointmentCreate);
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Cancel
        public async Task<IActionResult> Cancel(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassage"] = "Id of patient can not be 0 or negative number";
                return RedirectToAction(nameof(Index));
            }
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment is null)
            {
                TempData["ErrorMrssage"] = "Appointment Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }
        [HttpPost]
        public async Task<IActionResult> CancelConfirm([FromForm] int id)
        {
            await _appointmentService.CancelAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion


        #region Details
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid Appointment Id";
                return RedirectToAction(nameof(Index));
            }
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment is null)
            {
                TempData["ErrorMessage"] = "Appointment Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }
        #endregion

        #region Get Appointment by Doctor id 


        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            if (doctorId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid Doctor Id";
                return RedirectToAction(nameof(Index));
            }
            var appointments = await _appointmentService.GetAppointmentsByDoctorAsync(doctorId);
            return View(appointments);
        }
        #endregion

        #region Get Appointment by Patient id

        public async Task<IActionResult> GetAppointmentsByPatient(int patientId)
        {
            if (patientId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid Patient Id";
                return RedirectToAction(nameof(Index));
            }
            var appointments = await _appointmentService.GetAppointmentsByPatientAsync(patientId);
            return View(appointments);
        }

        #endregion

        #region Get Today Appointments

        public async Task<IActionResult> GetTodayAppointments(int doctorId)
        {
            if (doctorId <= 0)
            {
                TempData["ErrorMessage"] = "Invalid Doctor Id";
                return RedirectToAction(nameof(Index));
            }
            var appointments = await _appointmentService.GetTodayAppointmentsAsync(doctorId);
            return View(appointments);

        }
        #endregion


    }
}
