using Microsoft.EntityFrameworkCore;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;
using ModelTrainWebApp.Data;

namespace ModelTrainWebApp.Repository
{
    public class MeetRepository : IMeetRepository       //Implements IMeetRepository
    {
        private readonly ApplicationDbContext _context;
        public MeetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Meet meet)
        {
            _context.Add(meet);
            return Save();
        }

        public bool Delete(Meet meet)
        {
            _context.Remove(meet);
            return Save();
        }

        public async Task<IEnumerable<Meet>> GetAll()
        {
            return await _context.Meets.ToListAsync();
        }

        public async Task<IEnumerable<Meet>> GetAllMeetsByCity(string city)
        {
            return await _context.Meets.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Meet> GetByIdAsync(int id)
        {
            return await _context.Meets.Include(i => i.Address).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        public bool Update(Meet meet)
        {
            _context.Update(meet);
            return Save();
        }
    }
}
