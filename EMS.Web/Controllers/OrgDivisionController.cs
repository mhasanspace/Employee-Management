﻿using DocumentFormat.OpenXml.Office2010.Excel;
using EMS.Business.Services;
using EMS.Common.CommonHelper;
using EMS.Common.EnumUtility;
using EMS.Domain.DtoModels;
using EMS.Domain.ViewModels;
using EMS.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using static EMS.Common.EnumUtility.EnumCollection;

namespace EMS.Web.Controllers
{
    public class OrgDivisionController : Controller
    {

        private readonly OrgDivisionService _orgDivisionService;
        private readonly ILogger<OrgDivisionController> _logger;

        public OrgDivisionController(OrgDivisionService orgDivisionService, ILogger<OrgDivisionController> logger)
        {
            _orgDivisionService = orgDivisionService;
            _logger = logger;
        }


        [HttpGet("orgDivisionList")]
        public IActionResult Index(string searchTerm)
        {
            try
            {
                List<OrgDivisionView> orgDivisions = _orgDivisionService.GetOrgDivisionListByPage(searchTerm);
                return View(orgDivisions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(Index)}: {ex.Message}");
                return View("Error");
            }
        }

        [HttpGet("addOrgDivision")]
        public IActionResult AddOrgDivision()
        {
            return View();
        }

        [HttpPost("addOrgDivision")]
        public IActionResult AddOrgDivision(OrgDivisionDto orgDivisionDto)
        {
            if (ModelState.IsValid)
            {
                var appUserLogin = SessionHelper.GetAppUserLogin(HttpContext.Session);
                var result = _orgDivisionService.AddOrgDivision(orgDivisionDto, appUserLogin);

                if (result.OperationTypeInfoId == (int)EnumCollection.OperationTypeInfoEnum.DuplicatedData)
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(orgDivisionDto);
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
            return View(orgDivisionDto);
        }



        [HttpGet("updateOrgDivision")]
        public IActionResult UpdateOrgDivision(int id)
        {
            var division = _orgDivisionService.GetOrgDivisionById(id);
            if (division == null)
            {
                return NotFound();
            }
            return View(division);
        }


        [HttpPost("updateOrgDivision")]
        public IActionResult UpdateOrgDivision(OrgDivisionDto orgDivisionDto)
        {
            if (ModelState.IsValid)
            {
                var appUserLogin = SessionHelper.GetAppUserLogin(HttpContext.Session);
                var result = _orgDivisionService.UpdateOrgDivision(orgDivisionDto, appUserLogin);

                if (result.OperationTypeInfoId == (int)EnumCollection.OperationTypeInfoEnum.UpdateOperationError)
                {
                    TempData["ErrorMessage"] = result.Message;
                    return View(orgDivisionDto);
                }
                else if (result.OperationTypeInfoId == (int)OperationTypeInfoEnum.Updated)
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
            return View(orgDivisionDto);
        }


        [HttpPost("deleteOrgDivision")]
        public IActionResult DeleteOrgDivision(int orgDivId)
        {
            // Call the service method
            DotNetRunner result = _orgDivisionService.DeleteOrgDivision(orgDivId);

            // Check the result
            if (result.OperationTypeInfoId == (int)OperationTypeInfoEnum.Deleted)
            {
                // Handle success case
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                // Handle error case
                TempData["ErrorMessage"] = result.ErrorMessage ?? "An error occurred while processing your request.";
                return RedirectToAction("Index"); // or return some other IActionResult based on your application's needs
            }
        }




    }
}
