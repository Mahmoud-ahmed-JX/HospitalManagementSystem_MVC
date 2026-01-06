using HospitalBLL.DTOs.DepartmentDtos;
using HospitalBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalPL.Controllers
{
    public class DepartmentController(IServiceManager _serviceManager) : Controller
    {
        public async Task<IActionResult> Index(string search)
        {
            var departments = string.IsNullOrWhiteSpace(search)
                ? await _serviceManager.DepartmentService.GetAllDepartmentsAsync()
                : await _serviceManager.DepartmentService.GetDepartmentsByNameAsync(search);

            return View(departments); // This must match @model in the view
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto dept)
        {
           
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataInValid", "Check Data And Missing Fields");
                return View(nameof(Create), dept);
            }
            await _serviceManager.DepartmentService.CreateDepartment(dept);
            return RedirectToAction(nameof(Index));

        }
        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id <= 0)
            {
                TempData["ErrorMassage"] = "Id of department can not be 0 or negative number";
                return RedirectToAction("Index");
            }
            var dept = await _serviceManager.DepartmentService.GetDepartmentByIdAsync(Id);
            if (dept is null)
            {
                TempData["ErrorMrssage"] = "Department Not Found";
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentDto dept)
        {
            await _serviceManager.DepartmentService.UpdateDepartment(dept);
            return RedirectToAction("Index");
        }

        #endregion

        #region Details

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var dept =await _serviceManager.DepartmentService.GetDepartmentWithDoctorsAsync(Id);
            return View(dept);
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
            {
                TempData["ErrorMassage"] = "Id of department can not be 0 or negative number";
                return RedirectToAction("Index");
            }
            var dept = await _serviceManager.DepartmentService.GetDepartmentByIdAsync(Id);
            if (dept is null)
            {
                TempData["ErrorMrssage"] = "Department Not Found";
                return RedirectToAction("Index");
            }
            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromForm]int Id)
        {
            await _serviceManager.DepartmentService.DeleteDepartment(Id);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
