using Merzigo.UserService.Domain.Common;

namespace Merzigo.UserService.Domain.Entities
{
    public class User : AuditableEntity<Guid>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
