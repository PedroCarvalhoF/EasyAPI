﻿using Easy.Domain.Entities.UserMasterUser;

namespace Easy.Domain.Intefaces.Repository.UserMasterUser;

public interface IUserMasterUserRepository<T> where T : UserMasterUserEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(Guid userId);
    Task<T> Cadastrar(T create);
}
