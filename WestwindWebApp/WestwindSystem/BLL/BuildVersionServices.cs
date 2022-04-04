using WestwindSystem.DAL; // for WestwindContext
using WestwindSystem.Entities; // for BuildVersion

namespace WestwindSystem.BLL
{
    public class BuildVersionServices
    {
        private readonly WestwindContext _context;

        internal BuildVersionServices(WestwindContext context)
        {
            _context = context;
        }

        public BuildVersion? GetBuildVersion()
        {
            return _context.BuildVersions.FirstOrDefault();
        }
    }
}
