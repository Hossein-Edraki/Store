using System.Collections.Generic;

namespace Store.Application.Products.Queries.GetProductsList
{
    public class ProductsListVm
    {
        public IList<ProductDto> Products { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
