using AutoMapper;
using Persistence;
using Shouldly;
using Store.Application.Customers.Queries.GetCustomerDetail;
using Store.Application.UnitTests.Common;
using Xunit;

namespace Store.Application.UnitTests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerDetailQueryHandlerTests
    { 
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }    

        [Fact]
        public async Task GetCustomerDetail()
        {
            var sut = new GetCustomerDetailQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomerDetailQuery { Id = "12345" }, CancellationToken.None);

            result.ShouldBeOfType<CustomerDetailVm>();
            result.Id.ShouldBe("12345");
        }
    }
}
