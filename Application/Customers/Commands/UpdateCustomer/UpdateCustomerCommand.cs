using Application;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Store.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CustomerName { get; set; }

        public class Handler : IRequestHandler<UpdateCustomerCommand>
        {
            private readonly IStoreDbContext _context;

            public Handler(IStoreDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Customers
                    .SingleOrDefaultAsync(c => c.CustomerId == request.Id, cancellationToken);

                if (entity == null)
                {
                    //throw new NotFoundException(nameof(Customer), request.Id);
                }

                entity.Address = request.Address;
                entity.Phone = request.Phone;
                entity.CustomerName = request.CustomerName;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
