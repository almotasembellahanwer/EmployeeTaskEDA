using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using Microsoft.EntityFrameworkCore;
using SharedModels.DTO.DistrictDTO;

namespace EmployeeTask.Aggregator.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly AggregatorDbContext _context;

        public DistrictRepository(AggregatorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DistrictResponseGet>?> GetAllDistricts()
        {
            IEnumerable<DistrictResponseGet> response = await _context.Districts.Select(a=>new DistrictResponseGet()
            {
                DistrictID = a.DistrictID,
                ArabicName = a.ArabicName,
                EnglishName = a.EnglishName,
                AreaArabicName = a.Area.ArabicName,
                GovernorateArabicName = a.Area.Governorate.ArabicName
            })
            .ToListAsync();
            if (response is null)
                return new List<DistrictResponseGet>();
            return response;
        }

        public async Task<DistrictResponseGet?> GetDistrictByID(int districtID)
        {
            if (districtID == 0)
                throw new ArgumentException($"Invalid ID");

            var districtResponse = await (from district in _context.Districts
                                join area in _context.Areas
                                on district.AreaID equals area.AreaID
                                join gov in _context.Governorates
                                on area.GovernorateID equals gov.GovernorateID
                                where district.DistrictID == districtID
                                select new DistrictResponseGet
                                {
                                    DistrictID = district.DistrictID,
                                    ArabicName = district.ArabicName,
                                    EnglishName = district.EnglishName,
                                    GovernorateArabicName = gov.ArabicName
                                }).FirstOrDefaultAsync();
            if (districtResponse is null)
                return null;
            return districtResponse;
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
