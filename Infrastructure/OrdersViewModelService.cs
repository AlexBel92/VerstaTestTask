using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerstaTestTask.Core.Models;
using VerstaTestTask.Models;

namespace VerstaTestTask.Infrastructure
{
    public class OrdersViewModelService
    {
        private readonly OrdersRepository _repository;
        private readonly IMapper _mapper;

        public OrdersViewModelService(OrdersRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<int> CountAsync() => await _repository.Orders.CountAsync();

        public async Task<int> AddAsync(OrderViewModel orderViewModel)
        {
            var dbOrder = _mapper.Map<Order>(orderViewModel);

            return await _repository.AddAsync(dbOrder);
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrdersForPage(PaginationViewModel pagination)
        {
            var dbOrder = await _repository.Orders
                .OrderBy(o => o.PickUpDate)
                .ThenBy(o => o.OrderId)
                .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Include(o => o.RecipientAddress)
                .Include(o => o.RecipientCity)
                .Include(o => o.SenderAddress)
                .Include(o => o.SenderCity)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderViewModel>>(dbOrder);
        }
    }
}
