using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Interfaces
{
    public interface IMeetRepository
    {  
        Task<IEnumerable<Meet>> GetAll();
        Task<Meet> GetByIdAsync(int id);
        Task<IEnumerable<Meet>> GetAllMeetsByCity(string city);

        // CRUD commands
        bool Add(Meet meet);
        bool Update(Meet meet);
        bool Delete(Meet meet);
        bool Save();
    }
}
