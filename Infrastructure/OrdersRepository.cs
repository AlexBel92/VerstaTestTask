using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VerstaTestTask.Core.Models;

namespace VerstaTestTask.Infrastructure
{
    public class OrdersRepository
    {
        private readonly OrdersDbContext _dbContext;

        public OrdersRepository(OrdersDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IQueryable<Order> Orders => _dbContext.Orders;

        public async Task<int> AddAsync(Order order)
        {
            var dbRecipientCity = await MakeTrackable(order.RecipientCity);
            var dbSenderCity = order.RecipientCity.Name == order.SenderCity.Name ? dbRecipientCity : await MakeTrackable(order.SenderCity);

            order.RecipientAddress.City = dbRecipientCity;
            order.RecipientCity = dbRecipientCity;
            order.SenderAddress.City = dbSenderCity;
            order.SenderCity = dbSenderCity;

            var dbRecipientAddress = await MakeTrackable(order.RecipientAddress);
            var dbSenderAddress = await MakeTrackable(order.SenderAddress);

            order.RecipientAddress = dbRecipientAddress;
            order.SenderAddress = dbSenderAddress;            
            

            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();

            return order.OrderId;
        }        
        
        public async Task<City> MakeTrackable(City city)
        {
            var dbCity = await _dbContext.Cities.Include(c => c.Addresses).FirstOrDefaultAsync(c => c.Name == city.Name);

            if (dbCity is null)
            {
                dbCity = city;
                await _dbContext.Set<City>().AddAsync(dbCity);
            }

            return dbCity;
        }

        public async Task<Address> MakeTrackable(Address address)
        {
            var dbAddress = address.City.Addresses.FirstOrDefault(a =>
                 a.City.Name == address.City.Name &&
                 a.ZipCode == address.ZipCode &&
                 a.Street == address.Street &&
                 a.House == address.House &&
                 a.Apartment == address.Apartment);

            if (dbAddress is null)
            {
                dbAddress = address;
                address.City.Addresses.Add(dbAddress);
            }

            return dbAddress;
        }
    }
}