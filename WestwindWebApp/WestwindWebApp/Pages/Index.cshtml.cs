using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestwindSystem.BLL;       // for BuildVersionServices
using WestwindSystem.Entities;  // for BuildVersion

namespace WestwindWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildVersionServices;

        /*
         * Services that are registered using AddTransient<>()
         *      can be accessed on the constructor of the web page class (PageModel)
         * This is referred to as Dependency Injection
         * Each register service that is injected is listed on the constructor as a parameter
         * ILogger is a service from Microsoft Logging extensions
         * 
         * We need to add our required service(s) to this page
         * Our services will be know by the BLL class name
         * 
         * When you add a service to the page, you will save the service
         *      reference in a private readonly field
         * This variable will be available to all methods within this class
         */
        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices)
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
        }

        public BuildVersion? BuildVersionInfo { get; set; }

        public void OnGet()
        {
            BuildVersionInfo = _buildVersionServices.GetBuildVersion();

        }
    }
}