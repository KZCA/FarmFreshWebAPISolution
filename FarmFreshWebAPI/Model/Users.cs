using System.ComponentModel.DataAnnotations;

namespace FarmFreshWebAPI.Model
{
    public class Users
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
   
}
