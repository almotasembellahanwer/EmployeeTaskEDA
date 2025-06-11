using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.AccountService.Repositories
{
    public class GovernorateRepository : IGovernorateRepository
    {
        private readonly AccountDbContext _context;

        public GovernorateRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<Governorate?> AddGovernorate(Governorate? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Governorate");
            _context.Governorates.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Governorate?> UpdateGovernorate(Governorate? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Governorate");

            Governorate? existingGovernorate = await _context.Governorates
                .FirstOrDefaultAsync(a => a.GovernorateID == entity.GovernorateID);
            if (existingGovernorate is null || existingGovernorate.GovernorateID != entity.GovernorateID)
                return null;
            existingGovernorate.ArabicName = entity.ArabicName;
            existingGovernorate.EnglishName = entity.EnglishName;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteGovernorate(int governorateID)
        {

            Governorate? governorate = await _context.Governorates
                .FirstOrDefaultAsync(a => a.GovernorateID == governorateID);
            if (governorate is null)
                return false;
            _context.Governorates.Remove(governorate);
            int rowsCountAffected = await _context.SaveChangesAsync();
            return rowsCountAffected > 0;
        }
    }
}
