﻿using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Interfaces
{
    public interface IMeetupRepository
    {  
        Task<IEnumerable<Meetup>> GetAll();
        Task<Meetup> GetByIdAsync(int id);
        Task<Meetup> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Meetup>> GetAllMeetupsByCity(string city);

        // CRUD commands
        bool Add(Meetup meetup);
        bool Update(Meetup meetup);
        bool Delete(Meetup meetup);
        bool Save();
    }
}
