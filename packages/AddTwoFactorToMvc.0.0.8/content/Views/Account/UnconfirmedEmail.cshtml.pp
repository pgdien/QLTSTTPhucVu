@model $rootnamespace$.Models.ResendValidationEmailViewModel
@{
    ViewBag.Title = "Unconfirmed Email";
    Layout = null;
}

<h2>@ViewBag.Title</h2>

<p>Your email address has not been confirmed. Please check your inbox and/or your spam folder for a validation email.</p>

@if (Model.UserId != null) 
{
    using (Html.BeginForm("ResendValidationEmail", "Account", FormMethod.Post, new { id = "resendValidationForm", @class = "navbar-right" }))
    {
        @Html.AntiForgeryToken()
        @Html.HiddenFor(x => x.UserId)
    }

    <a href="javascript:document.getElementById('resendValidationForm').submit()">Re-send validation email</a>

}