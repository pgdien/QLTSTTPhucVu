@model $rootnamespace$.Models.VerifyCodeViewModel

@{
    ViewBag.Title = "Verify";
}

<div class="col-xs-6">

	<h2>@ViewBag.Title.</h2>

	@using (Html.BeginForm("VerifyCode", "Account", new { ReturnUrl = Model.ReturnUrl }, 
		FormMethod.Post, new { @class = "form-horizontal", role = "form" })) {
		
		@Html.AntiForgeryToken()
		@Html.Hidden("provider", @Model.Provider)
		@Html.Hidden("rememberMe", @Model.RememberMe)
		<h4>Enter verification code from your Authenticator app</h4>

		<br /><br /><br />
			
		@Html.ValidationSummary("", new { @class = "text-danger" })
		<div class="form-group">
			@Html.LabelFor(m => m.Code, new { @class = "col-md-2 control-label" })
			<div class="col-md-10">
				@Html.TextBoxFor(m => m.Code, new { @class = "form-control" })
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<div class="checkbox">
					@Html.CheckBoxFor(m => m.RememberBrowser)
					@Html.LabelFor(m => m.RememberBrowser)
				</div>
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<input type="submit" class="btn btn-default" value="Submit" />
			</div>
		</div>
	}

	</div>
	
	<div class="col-xs-6">
		<img src="~/content/authenticator-iphone-sample.png" class="img-responsive" style="margin-top: 20px" />
	</div>
	
	<br style="clear: both" />

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}
