$(document).ready(function () {
    if (TempData["SuccessMessage"] != null) {
        <text>toastr.success('@TempData["SuccessMessage"]');</text>
    }
    else if (TempData["ErrorMessage"] != null) {
        <text>toastr.error('@TempData["ErrorMessage"]');</text>
    }
});