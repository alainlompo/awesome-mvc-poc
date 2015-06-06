@If Request.IsAuthenticated Then
    @<text>
        Bonjour, @Html.ActionLink(User.Identity.Name, "Manage", "Account", routeValues:=Nothing, htmlAttributes:=New With {.class = "username", .title = "Gérer"})!
        @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm"})
            @Html.AntiForgeryToken()
            @<a href="javascript:document.getElementById('logoutForm').submit()">Se déconnecter</a>
        End Using
    </text>
Else
    @<ul>
        <li>@Html.ActionLink("S'inscrire", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink"})</li>
        <li>@Html.ActionLink("Se connecter", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
    </ul>
End If
