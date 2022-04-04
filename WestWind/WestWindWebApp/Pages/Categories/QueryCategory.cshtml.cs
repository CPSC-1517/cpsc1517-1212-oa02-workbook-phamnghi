using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Add namespaces for access BLL and Entities
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WestWindWebApp.Pages
{
    public class QueryCategoryModel : PageModel
    {
        #region Declare constructor as dependency of CategoryServices
        private readonly CategoryServices _categoryServices;
        public QueryCategoryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        #endregion

        #region Define properties for data the web page needs to access
        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public List<Category> QueryResultList { get; set; } = new();

        #endregion

        #region Define handlers form submissions
        public IActionResult OnPostSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
            {
                FeedbackMessage = "A search value is required.";
            }
            return RedirectToPage(new {SearchValue = SearchValue});
        }

        public IActionResult OnPostClear() // The method gets executed when asp-page-handler="Clear"
        {
            FeedbackMessage = "";
            ModelState.Clear();
            ModelState.Clear();
            return RedirectToPage(new { SearchValue = (string?)null });
        }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(SearchValue))
            {
                QueryResultList = _categoryServices.Category_GetByPartialCategoryNameOrDescription(SearchValue);
                FeedbackMessage = $"Search returned {QueryResultList.Count} record.";
            }
        }

        #endregion
    }
}
