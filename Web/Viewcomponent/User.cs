using Microsoft.AspNetCore.Mvc;

namespace Web.Viewcomponent
{
    public class User: ViewComponent
    {
        
            public async Task<IViewComponentResult> InvokeAsync()
            {
                if (User.Identity!.IsAuthenticated)
                {
                    return View("AuthenticatedNavbar");
                }
                else
                {
                    return View("GuestNavbar");
                }
            }
        }
    }

