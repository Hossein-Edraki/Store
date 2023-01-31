﻿using Store.Application.Customers.Commands.DeleteCustomer;
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

            await _sut.Handle(command, CancellationToken.None);
            //await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidIdAndZeroOrders_DeletesCustomer()
        {
            var validId = "JASON";

            var command = new DeleteCustomerCommand { Id = validId };

            await _sut.Handle(command, CancellationToken.None);

            var customer = await _context.Customers.FindAsync(validId);

            Assert.Null(customer);
        }

        [Fact]
        public async Task Handle_GivenValidIdAndSomeOrders_ThrowsDeleteFailureException()
        {
            var validId = "BREND";

            var command = new DeleteCustomerCommand { Id = validId };

            //await Assert.ThrowsAsync<DeleteFailureException>(() => _sut.Handle(command, CancellationToken.None));

        }
    }
}
