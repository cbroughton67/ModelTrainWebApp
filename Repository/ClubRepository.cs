﻿using Microsoft.EntityFrameworkCore;
using ModelTrainWebApp.Data;
using ModelTrainWebApp.Interfaces;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Repository
{
    public class ClubRepository : IClubRepository  //Implements IClubRepository Interface
    {
        private readonly ApplicationDbContext _context;
        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }


        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()       //Returns multiple rows (a List)
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)        //Returns one row
        {
            return await _context.Clubs.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetAllClubsByCity(string city)
        {
            return await _context.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            _context.Remove(club);
            return Save();
        }
    }
}
