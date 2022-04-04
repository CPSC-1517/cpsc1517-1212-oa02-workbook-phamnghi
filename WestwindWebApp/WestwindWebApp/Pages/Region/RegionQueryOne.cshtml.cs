using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestwindSystem.BLL;
using WestwindSystem.Entities;

namespace WestwindWebApp.Pages.Region
{
    public class RegionQueryOneModel : PageModel
    {
        #region Inject an RegionSevices into the constructor of the 
        private RegionServices _regionServices;

        public RegionQueryOneModel(RegionServices regionServices)
        {
            _regionServices = regionServices;
        }
        #endregion

        #region Define properties required to search for a single Region by Region ID
        [TempData]
        public string FeedBackMessage { get; set; }

        [BindProperties(SupportsGet = true)] //Bind this property using a route
        public int RegionID { get; set; }

        public Region QuerySingleResult { get; set; }

        #endregion

        #region Define a page handler to perform the search by Region By RegionID
        public IActionResult OnPostSearch()
        {
            // see an error if a valid RegionID is not valid
            if(RegionID < 1)
            {
                FeedBackMessage = "RegionID is required and must be greater than 0";
            }
            // Redirect to the same page and pass the routeValue RegionID
            return RedirectToPage(new { RegionID = RegionID });
        }

        public IActionResult OnPostClear()
        {
            FeedBackMessage = "";
            ModelState.Clear();
            return RedirectToPage(new { RegionID = (int?)null });
        }
        #endregion
        public void OnGet()
        {
        }
    }
}
