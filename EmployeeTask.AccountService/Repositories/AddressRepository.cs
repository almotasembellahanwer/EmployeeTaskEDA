using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.AccountService.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AccountDbContext _context;

        public AddressRepository(AccountDbContext context)
        {
            _context = context;
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

            Address? existingAddress = await _context.Addresses
                .FirstOrDefaultAsync(a => a.AddressID == entity.AddressID);
            if (existingAddress is null || existingAddress.AddressID != entity.AddressID)
                return null;
            existingAddress.AddressName = entity.AddressName;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAddress(int addressID)
        {
            var employees = await _context.Employees.Where(e => e.AddressID == addressID).ToListAsync();
            foreach (var employee in employees)
            {
                employee.AddressID = null; // Make addressID null when deleting address
            }
            await _context.SaveChangesAsync();
            Address? address = await _context.Addresses
                .FirstOrDefaultAsync(a => a.AddressID == addressID);
            if (address is null)
                return false;
            _context.Addresses.Remove(address);
            int rowsCountAffected = await _context.SaveChangesAsync();
            return rowsCountAffected > 0;
        }
    }
}
