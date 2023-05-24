using MinhaAPI.Entities;
namespace MinhaAPI.Persistence
{
    public class ApiDbContext
    {
        public List<User> Users { get; set; }

        public ApiDbContext()
        {
            Users = new List<User>();
        }
    }
}