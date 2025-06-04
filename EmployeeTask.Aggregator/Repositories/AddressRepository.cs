using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Aggregator.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AggregatorDbContext _context;

        public AddressRepository(AggregatorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>?> GetAllAddresses()
        {
            IEnumerable<Address> addresses = await _context.Addresses
                .ToListAsync();
            if (addresses is null)
                return new List<Address>();
            return addresses;
        }

        public async Task<Address?> GetAddressByID(int addressID)
        {
            if (addressID == 0)
                throw new ArgumentException($"Invalid ID");
            Address? address = await _context.Addresses
        .FirstOrDefaultAsync(temp => temp.AddressID == addressID);
            if (address is null)
                return null;
            return address;
        }

        public async Task<Address?> AddAddress(Address? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Address");
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Address?> UpdateAddress(Address? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Address");

            Address? existingAddress = await GetAddressByID(entity.AddressID);
            if (existingAddress is null)
                return null;
            existingAddress.AddressID = entity.AddressID;
            existingAddress.AddressName = entity.AddressName;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAddress(int addressID)
        {
            Address? address = await GetAddressByID(addressID);
            if (address is null)
                return false;
            _context.Addresses.Remove(address);
            int rowsCountAffected = await _context.SaveChangesAsync();
            return rowsCountAffected > 0;
        }
    }
}
