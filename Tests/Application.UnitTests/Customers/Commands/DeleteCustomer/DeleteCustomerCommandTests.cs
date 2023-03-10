using Store.Application.Customers.Commands.DeleteCustomer;
using Store.Application.UnitTests.Common;
using Xunit;

namespace Store.Application.UnitTests.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTests : CommandTestBase
    {
        private readonly DeleteCustomerCommandHandler _sut;

        public DeleteCustomerCommandTests()
            : base()
        {
            _sut = new DeleteCustomerCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = "INVLD";

            var command = new DeleteCustomerCommand { Id = invalidId };

            await Assert.ThrowsAsync<Exception>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidIdAndZeroOrders_DeletesCustomer()
        {
            var validId = "12345";

            var command = new DeleteCustomerCommand { Id = validId };

            await _sut.Handle(command, CancellationToken.None);

            var customer = await _context.Customers.FindAsync(validId);

            Assert.Null(customer);
        }
    }
}
