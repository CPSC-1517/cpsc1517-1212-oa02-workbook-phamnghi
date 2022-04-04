using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageWebAppDemo.Pages
{
    public class FormFieldControlUsingTagHelpersModel : PageModel
    {
        // Define an auto-implemented property for feedback messages
        public string Message { get; set; }

        // Define an auto-implemented property for username
        [BindProperty]  // Bind a HTML form field to this property
        public string Username { get; set; }

        // Define an auto-implemented property for password
        [BindProperty]
        public string Password { get; set; }

        // Deine an auto-implemented property for confirm password
        [BindProperty]
        public string ConfirmPassword { get; set; }

        // Create a methos to handle a HTTP post request.
        // The methos must start with On follow by the HTTP method(Get,Post, Put, Delete)to handle
        public void OnPost()
        {
            // Check if the Password matches the COnfirmPassword
            if (Password == ConfirmPassword)
            {
                Message = $"You submitted the following: {Username}, {Password}";
            }
            else
            {
                Message = $"The password and confirm password does not match.";
            }
        }
        public void OnGet()
        {
        }
    }
}
