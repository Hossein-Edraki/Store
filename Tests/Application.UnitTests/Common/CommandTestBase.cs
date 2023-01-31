using Persistence;

namespace Store.Application.UnitTests.Common
{
    public class CommandTestBase
    {
        protected readonly StoreDbContext _context;

        public CommandTestBase()
        {
            _context = StoreContextFactory.Create();
        }
    }
}