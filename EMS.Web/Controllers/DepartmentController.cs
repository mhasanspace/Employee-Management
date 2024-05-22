using EMS.Business.Services;
using EMS.Common.EnumUtility;
using EMS.Domain.DtoModels;
using EMS.Domain.Models;
using EMS.Domain.ViewModels;
using EMS.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using static EMS.Common.EnumUtility.EnumCollection;

namespace EMS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly OrgDivisionService _orgDivisionService;
        private readonly ILogger<OrgDivisionController> _logger;

        public DepartmentController(DepartmentService departmentService, ILogger<OrgDivisionController> logger, OrgDivisionService orgDivisionService)
        {
            _departmentService = departmentService;
            _logger = logger;
            _orgDivisionService = orgDivisionService;
        }

        [HttpGet("DepartmentList")]
        public IActionResult Index(string searchTerm)
        {
            try
            {
                List<DepartmentView> departments = _departmentService.GetDepartmentListByPage(searchTerm);
                return View(departments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(Index)}: {ex.Message}");
                return View("Error");
            }
        }



        [HttpGet("AddDepartment")]
        public IActionResult AddDepartment()
        {
            try
            {
                var orgDivisions = _orgDivisionService.GetAllOrgDivision(); // Replace with your actual service call

                if (orgDivisions == null || !orgDivisions.Any())
                {
                    TempData["ErrorMessage"] = "No divisions available. Please add divisions first.";
                }
                else
                {
                    ViewBag.OrgDivisions = orgDivisions ?? new List<OrgDivisionView>();
                }

                return View(new DepartmentDto());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while loading Some Data: {ex.Message}";
                return View(new DepartmentDto());
            }
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(DepartmentDto departmentDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var appUserLogin = SessionHelper.GetAppUserLogin(HttpContext.Session);
                    var result = _departmentService.AddDepartment(departmentDto, appUserLogin);

                    if (result.OperationTypeInfoId == (int)EnumCollection.OperationTypeInfoEnum.DuplicatedData)
                    {
                        TempData["ErrorMessage"] = result.Message;
                    }
                    else if (result.OperationTypeInfoId == (int)OperationTypeInfoEnum.Saved)
                    {
                        TempData["SuccessMessage"] = result.Message;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "An error occurred while processing your request.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid input data.";
                }

                // Reload OrgDivisions in case of failure
                var orgDivisions = _orgDivisionService.GetAllOrgDivision(); // Replace with your actual service call
                ViewBag.OrgDivisions = orgDivisions ?? new List<OrgDivisionView>();

                return View(departmentDto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while processing your request: {ex.Message}";
                return View(departmentDto);
            }
        }






    }
}
