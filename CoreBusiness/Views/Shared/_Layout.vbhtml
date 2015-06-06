<!DOCTYPE html>
<html lang="fr">
    <head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta charset="utf-8" />
        <title>@ViewData("Title") - Mon application ASP.NET MVC</title>
        <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <meta name="viewport" content="width=device-width" />

        <link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
    
    <link href="@Url.Content("~/Content/themes/bui/AwesomeMvc.css")" rel="stylesheet" type="text/css"/>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css"/>    

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.js"></script>

    <script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>
    @* jquery-migrate needed for ie8 when using jquery.validate.unobtrusive with jquery 1.9 and higher *@

         <script type="text/javascript" src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    <script src="@Url.Content("~/Scripts/AwesomeMvc.js")" type="text/javascript"></script>




        @*@Styles.Render("~/Content/css")
        @Scripts.Render("~/bundles/modernizr")*@
    </head>
    <body>
        <header>
            <div class="content-wrapper">
                <div class="float-left">
                    <p class="site-title">@Html.ActionLink("votre logo ici", "Index", "Home")</p>
                </div>
                <div class="float-right">
                    <section id="login">
                        @Html.Partial("_LoginPartial")
                    </section>
                    <nav>
                        <ul id="menu">
                            <li>@Html.ActionLink("Accueil", "Index", "Home")</li>
                            <li>@Html.ActionLink("À propos de", "About", "Home")</li>
                            <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                            <li>@Html.ActionLink("Projets", "Index","Projets")</li>
                            <li>@Html.ActionLink("Etapes", "Index", "Etapes")</li>
                            <li>@Html.ActionLink("Entites", "Index", "Entites")</li>
                            <li>@Html.ActionLink("Taches","Index","Taches")</li>
                          
                            <li>@Html.ActionLink("Utilisateurs", "Index", "Utilisateurs")</li>


                        </ul>
                    </nav>
                </div>
            </div>
        </header>
        <div id="body">
            @RenderSection("featured", required:=false)
            <section class="content-wrapper main-content clear-fix">
                @RenderBody()
            </section>
        </div>
        <footer>
            <div class="content-wrapper">
                <div class="float-left">
                    <p>&copy; @DateTime.Now.Year - Mon application ASP.NET MVC</p>
                </div>
            </div>
        </footer>

        @Scripts.Render("~/bundles/jquery")
        @RenderSection("scripts", required:=False)
    </body>
</html>
