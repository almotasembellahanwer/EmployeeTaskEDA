using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Aggregator.Repositories
{
    public class GovernorateRepository : IGovernorateRepository
    {
        private readonly AggregatorDbContext _context;

        public GovernorateRepository(AggregatorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Governorate>?> GetAllGovernorates()
        {
            IEnumerable<Governorate> governorates = await _context.Governorates
                .ToListAsync();
            if (governorates is null)
                return new List<Governorate>();
            return governorates;
        }

        public async Task<Governorate?> GetGovernorateByID(int governorateID)
        {
            if (governorateID == 0)
                throw new ArgumentException($"Invalid ID");
            Governorate? governorate = await _context.Governorates
        .FirstOrDefaultAsync(temp => temp.GovernorateID == governorateID);
            if (governorate is null)
                return null;
            return governorate;
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
