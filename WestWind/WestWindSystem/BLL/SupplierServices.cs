using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class SupplierServices
    {
        private readonly WestWindContext _dbContext;

        internal SupplierServices(WestWindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Supplier> Supplier_List()
        {
            var query = _dbContext
                .Suppliers
                .OrderBy(s => s.CompanyName);
            return query.ToList();
        }

        public Supplier? Supplier_GetByID(int supplierID)
        {
            var query = _dbContext
                .Suppliers
                .Where(s => s.SupplierID == supplierID);

            return query.FirstOrDefault();
        }
    }
}
