using Application;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Store.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListVm>
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsListVm> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.ProductName)
                .ToListAsync(cancellationToken);

            var vm = new ProductsListVm
            {
                Products = products,
                CreateEnabled = true // TODO: Set based on user permissions.
            };

            return vm;
        }
    }
}
