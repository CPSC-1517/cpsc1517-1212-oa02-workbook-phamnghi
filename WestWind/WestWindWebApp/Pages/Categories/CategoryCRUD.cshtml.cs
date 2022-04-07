using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages.Categories
{
    public class CategoryCRUDModel : PageModel
    {
        private readonly CategoryServices _categoryServices;

        public CategoryCRUDModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        //The Category to craete, update, or delete
        [BindProperty(SupportsGet = true)]
        public Category CurrentCategory { get; set; }

        [TempData]
        public string FeedbackMessage { get; set; }
        public void OnGet(int? CurrentCategoryID)
        {
            if(CurrentCategoryID == null)
            {
                CurrentCategory = new Category();
            }
            else
            {
                CurrentCategory = _categoryServices.Category_GetById((int)CurrentCategoryID);
            }
        }

        public IActionResult OnPostNew()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int categoryID = _categoryServices.Category_AddCategory(CurrentCategory);
                    FeedbackMessage = $"Successfully created category with ID if {categoryID}";
                }
                catch(Exception ex)
                {
                    FeedbackMessage = $"Error creating category with exception {ex.Message}";
                    return Page();
                }
            }
            return RedirectToPage("/Categories/Index");
        }
    }
}
