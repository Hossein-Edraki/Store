using Application;
using AutoMapper;
using Domain.Entities;

namespace Store.Application.Customers.Queries.GetCustomerDetail
{
    public class CustomerDetailVm : IMapFrom<Customer>
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CustomerId));
        }

        /*
         * 
         * A good example of how AutoMapper can help.
         * 
        public static Expression<Func<Customer, CustomerDetailVm>> Projection
        {
            get
            {
                return customer => new CustomerDetailVm
                {
                    Id = customer.CustomerId,
                    Address = customer.Address,
                    City = customer.City,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Country = customer.Country,
                    Fax = customer.Fax,
                    Phone = customer.Phone,
                    PostalCode = customer.PostalCode,
                    Region = customer.Region
                };
            }
        }

        public static CustomerDetailVm Create(Customer customer)
        {
            return Projection.Compile().Invoke(customer);
        }
        */
    }
}
