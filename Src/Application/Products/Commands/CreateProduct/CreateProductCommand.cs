using MediatR;

namespace Store.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

    }
}
