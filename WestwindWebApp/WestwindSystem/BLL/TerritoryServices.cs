using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestwindSystem.DAL; // for WestwindContext
using WestwindSystem.Entities; // for Territory

namespace WestwindSystem.BLL
{
    public class TerritoryServices
    {
        // Define a readonly data field for the DbContext
        private WestwindContext _context;

        // Define a greedy contructor for initializing the DbContext
        internal TerritoryServices(WestwindContext context)
        {
            _context = context;
        }

        public List<Territory> GetByRegion(int regionID)
        {
            IEnumerable<Territory> queryResult = _context
                .Territories
                .Where(currentItem => currentItem.RegionID == regionID)
                .OrderBy(currentItem => currentItem.TerritoryDescription);
            return queryResult.ToList();
        }
    }
}
