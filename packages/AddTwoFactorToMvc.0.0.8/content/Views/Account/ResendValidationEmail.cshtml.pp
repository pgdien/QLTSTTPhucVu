@model $rootnamespace$.Models.ResendValidationEmailViewModel
@{
    ViewBag.Title = "Email Validation";
    Layout = null;
}

<h2>@ViewBag.Title</h2>

<p>A validation email has been sent. Please check your inbox and/or your spam folder.</p>

@if (Model.CallbackUrl != null)
{
    <p>
        Or you could just use <a href="@Model.CallbackUrl">this link</a>.
    </p>
}