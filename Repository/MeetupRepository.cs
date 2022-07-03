using Microsoft.EntityFrameworkCore;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;
using ModelTrainWebApp.Data;

namespace ModelTrainWebApp.Repository
{
    public class MeetupRepository : IMeetupRepository       //Implements IMeetupRepository Interface
    {
        private readonly ApplicationDbContext _context;
        public MeetupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Meetup meetup)
        {
            _context.Add(meetup);
            return Save();
        }

        public bool Delete(Meetup meetup)
        {
            _context.Remove(meetup);
            return Save();
        }

        public async Task<IEnumerable<Meetup>> GetAll()
        {
            return await _context.Meetups.ToListAsync();
        }

        public async Task<IEnumerable<Meetup>> GetAllMeetsByCity(string city)
        {
            return await _context.Meetups.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Meetup> GetByIdAsync(int id)
        {
            return await _context.Meetups.Include(i => i.Address).FirstOrDefaultAsync();
        }

        public async Task<Meetup> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Meetups.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        public bool Update(Meetup meetup)
        {
            _context.Update(meetup);
            return Save();
        }

        Task<IEnumerable<Meetup>> IMeetupRepository.GetAllMeetupsByCity(string city)
        {
            throw new NotImplementedException();
        }

    }
}
