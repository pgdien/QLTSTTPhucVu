Adding Google's Two Factor Authentication to your MVC application 

Installation Steps:

1. If you don't have a SQL server DB, create one and add a connection string to your web.config:

<configuration>
  ...
  <connectionStrings>
    <add name="DefaultConnection" 
		 connectionString="Data Source=dbservername;initial catalog=MyAppDb;integrated security=true" 
		 providerName="System.Data.SqlClient" />
  </connectionStrings>

2. Run the TwoFactor\database-scripts\twofactor-database-tables.sql script into your DB

3. Edit the TwoFactor/classes/common/SendEmail.cs file to have the right SMTP details

4. Add the _LoginPartial.cshtml partial view your shared layout file located in Views\Shared\_Layout.cshtml like so:

	<div class="navbar-collapse collapse">
		<ul class="nav navbar-nav">	
			<li>@Html.ActionLink("Home", "Index", "Home")</li>
			<li>@Html.ActionLink("About", "About", "Home")</li>
			<li>@Html.ActionLink("Contact", "Contact", "Home")</li>
		</ul>
		@Html.Partial("_LoginPartial")
	</div>


Enjoy your two factor authentication!   

You probably now want to do the following:

	* Move the two controller classes located in TwoFactor\classes\controller to your \Controller folder
	* Add the following directories to your source control system:
		* \TwoFactor
		* \Views\Account
		* \Views\Manage
	* Add the following file to your source control system:
		* \Scripts\qrcode.js
		* \Views\Shared\_LoginPartial.cshtml
	* Delete this file :)

