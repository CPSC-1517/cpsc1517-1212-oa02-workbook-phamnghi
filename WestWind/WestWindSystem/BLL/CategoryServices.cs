using WestWindSystem.Entities;  // for Category
using WestWindSystem.DAL;  // for WestWindContext

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

        // Step 2: Define query methods of the Category entity
        public List<Category> Category_List()
        {
            //IEnumerable<Category> resultListQuery = _dbContext
            //    .Categories
            //    .OrderBy(item => item.CategoryName);
            //return resultListQuery.ToList();

            return _dbContext
                .Categories
                .OrderBy(item => item.CategoryName)
                .ToList();
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
