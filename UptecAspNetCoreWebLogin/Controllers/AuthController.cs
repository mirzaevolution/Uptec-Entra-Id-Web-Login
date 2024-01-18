using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UptecAspNetCoreWebLogin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(string redirectUrl = "/")
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.IsLocalUrl(redirectUrl) ?
                    redirectUrl : Url.Action("Index", "Home", null, Request.Scheme)
            },
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [Authorize]
        public IActionResult Logout()
        {
            return SignOut(
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
