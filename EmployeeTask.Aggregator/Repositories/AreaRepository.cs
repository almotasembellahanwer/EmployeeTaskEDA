using EmployeeTask.Aggregator.Data;
using EmployeeTask.Aggregator.Entities;
using EmployeeTask.Aggregator.IRepositoryContracts;
using Microsoft.EntityFrameworkCore;
using SharedModels.DTO.AreaDTO;

namespace EmployeeTask.Aggregator.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AggregatorDbContext _context;

        public AreaRepository(AggregatorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AreaResponseGet>?> GetAllAreas()
        {
            IEnumerable<AreaResponseGet> response = await _context.Areas.Select(a=>new AreaResponseGet()
            {
                AreaID = a.AreaID,
                ArabicName = a.ArabicName,
                EnglishName = a.EnglishName,
                GovernorateArabicName = a.Governorate.ArabicName
            })
            .ToListAsync();
            if (response is null)
                return new List<AreaResponseGet>();
            return response;
        }

        public async Task<AreaResponseGet?> GetAreaByID(int areaID)
        {
            if (areaID == 0)
                throw new ArgumentException($"Invalid ID");

            var areaResponse = await (from area in _context.Areas
                                join gov in _context.Governorates
                                on area.GovernorateID equals gov.GovernorateID
                                where area.AreaID == areaID
                                select new AreaResponseGet
                                {
                                    AreaID = area.AreaID,
                                    ArabicName = area.ArabicName,
                                    EnglishName = area.EnglishName,
                                    GovernorateArabicName = gov.ArabicName
                                }).FirstOrDefaultAsync();
            if (areaResponse is null)
                return null;
            return areaResponse;
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
