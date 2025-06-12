using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.AccountService.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AccountDbContext _context;

        public AreaRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<Area?> AddArea(Area? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Area");
            _context.Areas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Area?> UpdateArea(Area? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid Area");

            Area? existingArea = await _context.Areas
                .FirstOrDefaultAsync(a => a.AreaID == entity.AreaID);
            if (existingArea is null || existingArea.AreaID != entity.AreaID)
                return null;
            existingArea.ArabicName = entity.ArabicName;
            existingArea.EnglishName = entity.EnglishName;
            existingArea.GovernorateID = entity.GovernorateID;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteArea(int areaID)
        {

            Area? area = await _context.Areas
                .FirstOrDefaultAsync(a => a.AreaID == areaID);
            if (area is null)
                return false;
            _context.Areas.Remove(area);
            int rowsCountAffected = await _context.SaveChangesAsync();
            return rowsCountAffected > 0;
        }
    }
}
