using AutoMapper;
using Persistence;
using Shouldly;
using Store.Application.Customers.Queries.GetCustomersList;
using Store.Application.UnitTests.Common;
using Xunit;

namespace Store.Application.UnitTests.Infrastructure
{
    [Collection("QueryCollection")]
    public class GetCustomersListQueryHandlerTests
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCustomersTest()
        {
            var sut = new GetCustomersListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomersListQuery(), CancellationToken.None);

            result.ShouldBeOfType<CustomersListVm>();

            result.Customers.Count.ShouldBe(2);
        }
    }
}