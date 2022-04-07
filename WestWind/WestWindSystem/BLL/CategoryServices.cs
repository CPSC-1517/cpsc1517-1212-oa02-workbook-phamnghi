using WestWindSystem.Entities;  // for Category
using WestWindSystem.DAL;  // for WestWindContext

using Microsoft.EntityFrameworkCore;  // for extension methods

namespace WestWindSystem.BLL
{
    public class CategoryServices
    {
        //Step 1:Define a readonly data field for the custom DbContext class
        //and use constructor injection to set the value of the data field
        private readonly WestWindContext _dbContext;
        internal CategoryServices(WestWindContext context)
        {
            _dbContext = context;
        }

        public int Category_AddCategory(Category newCategory)
        {
            // Enforce business rule where CategoryName must be unique
            bool exists = _dbContext.Categories.Any(c => c.CategoryName == newCategory.CategoryName);
            if (exists)
            {
                throw new Exception($"The Category Name {newCategory.CategoryName} already exists!");
            }

            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return newCategory.CategoryID;
        }

        public int Category_UpdateCategory(Category existingCategory)
        {
            _dbContext.Categories.Attach(existingCategory).State = EntityState.Modified;
            int rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }

        public int Category_DeleteCategory(Category existingCategory)
        {
            // Enfore business rule where categories with products cannot be deleted
            int categoryProductCount = _dbContext.Categories
                .Where(c => c.CategoryID == existingCategory.CategoryID)
                .Include(c => c.Products)
                .FirstOrDefault()
                .Products
                .Count();
            if(categoryProductCount > 0)
            {
                throw new Exception("This category has products and cannot be deleted.");
            }

            _dbContext.Categories.Attach(existingCategory).State = EntityState.Deleted;
            int rowsDeleted = _dbContext.SaveChanges();
            return rowsDeleted;
        }

        // Step 2: Define query methods of the Category entity
        public List<Category> Category_List()
        {
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName);
            return query.ToList();

        }

        public Category Category_GetById(int categoryID)
        {
            IEnumerable<Category> singleResultQuery = _dbContext
                .Categories
                .Where(item => item.CategoryID == categoryID);
            return singleResultQuery.FirstOrDefault();
        }

        public List<Category> Category_GetByPartialCategoryNameOrDescription(string patialNameOrDescription)
        {
            IEnumerable<Category> resultListQuery = _dbContext
                .Categories
                .Where(item => item.CategoryName.Contains(patialNameOrDescription)
                || item.Description.Contains(patialNameOrDescription));
            return resultListQuery.ToList();
        }

    }
}
