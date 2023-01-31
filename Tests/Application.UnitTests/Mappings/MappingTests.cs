using AutoMapper;
using Domain.Entities;
using Shouldly;
using Store.Application.Customers.Queries.GetCustomersList;
using Store.Application.Products.Queries.GetProductDetail;
using Store.Application.Products.Queries.GetProductsList;
using Xunit;

namespace Store.Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapCustomerToCustomerLookupDto()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerLookupDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerLookupDto>();
        }

        [Fact]
        public void ShouldMapProductToProductDetailVm()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductDetailVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductDetailVm>();
        }

        [Fact]
        public void ShouldMapProductToProductDto()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductDto>();
        }
    }
}
