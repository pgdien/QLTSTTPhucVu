﻿@model $rootnamespace$.Controllers.GoogleAuthenticatorViewModel
@{
    ViewBag.Title = "Enable Google Authenticator";
}
<div class="row">
    <div class="col-md-8">
        <h3>1. Add Movie Manager to Google Authenticator</h3>
		
        <p>Open Google Authenticator and add Movie Manager
		   by scanning the QR Code to the right.</p>
		   
        <h3>2. Enter the 6 digit code that Google 
		    Authenticator generates</h3>
			
        <p>
            Verify that Movie Manager is added correctly in Google 
			Authenticator by entering the 6 digit code which
            Google Authenticator generates for Movie Manager below, 
			and then click Enable.
        </p>
        @using (Html.BeginForm(
			"EnableGoogleAuthenticator", 
			"Manage", 
			FormMethod.Post, 
			new { @class = "form-horizontal", role = "form" }))
        {
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(false)
            @Html.HiddenFor(m => m.SecretKey)
            @Html.HiddenFor(m => m.BarcodeUrl)
            <div class="form-group">
                @Html.LabelFor(m => m.Code, new { @class = "col-md-2 control-label" })
                <div class="col-md-10">
                    @Html.TextBoxFor(m => m.Code, new { @class = "form-control", autocomplete="off" })
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" class="btn btn-default" value="Enable" />
                </div>
            </div>
        }
    </div>
    <div class="col-md-4">
        <br /><br />
        <div id="qrcode" style="width: 200px"></div>
    </div>
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")

	<script src="~/Scripts/qrcode.js"></script>
	
    <script>

        var barcodeUrl = "@Html.Raw(Model.BarcodeUrl)";

        $(function () {
            var qrcode = new QRCode("qrcode", {
                text: barcodeUrl,
                width: 200,
                height: 200,
                colorDark: "#000000",
                colorLight: "#ffffff",
                correctLevel: QRCode.CorrectLevel.H
            });
            $("#Code").focus();
        });

    </script>
}