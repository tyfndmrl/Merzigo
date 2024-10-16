namespace Merzigo.UserService.Domain.Common.Auditing.Interfaces;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}
