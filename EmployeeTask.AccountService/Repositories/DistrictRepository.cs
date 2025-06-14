using EmployeeTask.AccountService.Data;
using EmployeeTask.AccountService.Entities;
using EmployeeTask.AccountService.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.AccountService.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly AccountDbContext _context;

        public DistrictRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<District?> AddDistrict(District? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid District");
            _context.Districts.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<District?> UpdateDistrict(District? entity)
        {
            if (entity is null)
                throw new ArgumentException("Invalid District");

            District? existingDistrict = await _context.Districts
                .FirstOrDefaultAsync(a => a.DistrictID == entity.DistrictID);
            if (existingDistrict is null || existingDistrict.DistrictID != entity.DistrictID)
                return null;
            existingDistrict.ArabicName = entity.ArabicName;
            existingDistrict.EnglishName = entity.EnglishName;
            existingDistrict.AreaID = entity.AreaID;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteDistrict(int districtID)
        {

            District? district = await _context.Districts
                .FirstOrDefaultAsync(a => a.DistrictID == districtID);
            if (district is null)
                return false;
            _context.Districts.Remove(district);
            int rowsCountAffected = await _context.SaveChangesAsync();
            return rowsCountAffected > 0;
        }
    }
}
