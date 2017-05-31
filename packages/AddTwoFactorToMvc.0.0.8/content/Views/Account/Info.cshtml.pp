@{
    ViewBag.Title = "Thank you";
}

<h2>@ViewBag.Title.</h2>

<p>@ViewBag.Message</p><br />

@if (TempData["ViewBagLink"] != null) {
    <p>
        Or you could just use <a href="@TempData["ViewBagLink"]">this link</a>.
                
    </p>
            
}
