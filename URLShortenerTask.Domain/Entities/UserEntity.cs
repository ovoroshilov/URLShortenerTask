using URLShortenerTask.Domain.Entities;

namespace URLShortenerTask.Domain.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; } 
        public string Login { get; set; } 
        public string Password { get; set; }
        public RoleEntity RoleId { get ; set; }
    }
}
