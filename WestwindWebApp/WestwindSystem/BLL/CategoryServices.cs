using WestwindSystem.DAL; // for WestwindContext
using WestwindSystem.Entities;  // for Category

namespace WestwindSystem.BLL
{
    public class CategoryServices
    {
        #region Setup a dbcontext using dependency injection
        // Define a readonly field for the database context that will be assign a value in the contructor
        private readonly WestwindContext _context;

        internal CategoryServices(WestwindContext context)
        {
            _context = context;
        }
        #endregion

        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
