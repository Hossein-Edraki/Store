using MediatR;
using Moq;
using Store.Application.Customers.Commands.CreateCustomer;
using Store.Application.UnitTests.Common;
using Xunit;

namespace Store.Application.UnitTests.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseCustomerCreatedNotification()
        {
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreateCustomerCommand.Handler(_context);
            var newCustomerId = "678900";

            var result = sut.Handle(new CreateCustomerCommand { Id = newCustomerId }, CancellationToken.None);
        }
    }
}
