using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.UserMasterCliente;

public class UserMasterClienteRepository : IUserMasterClienteRepository
{
    protected readonly MyContext db;

    public UserMasterClienteRepository(MyContext db)
    {
        this.db = db;
    }

    public async Task<UserMasterClienteEntity> GetMemberByIdAsync(Guid id)
    {
        var member = await db.UserMasterCliente.FindAsync(id);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        return member;
    }

    public async Task<IEnumerable<UserMasterClienteEntity>> GetMembersAsync()
    {
        var memberlist = await db.UserMasterCliente.ToArrayAsync();
        return memberlist ?? Enumerable.Empty<UserMasterClienteEntity>();
    }

    public async Task<UserMasterClienteEntity> AddMemberAsync(UserMasterClienteEntity member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        await db.UserMasterCliente.AddAsync(member);
        return member;
    }

    public void UpdateMember(UserMasterClienteEntity member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        db.UserMasterCliente.Update(member);
    }

    public async Task<UserMasterClienteEntity> DeleteMember(Guid memberId)
    {
        var member = await GetMemberByIdAsync(memberId);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        db.UserMasterCliente.Remove(member);
        return member;
    }
}
