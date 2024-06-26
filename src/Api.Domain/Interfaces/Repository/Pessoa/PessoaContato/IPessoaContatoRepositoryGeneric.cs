﻿using Domain.Entities.Pessoa.PessoaContato;

namespace Domain.Interfaces.Repository.Pessoa.PessoaContato
{
    public interface IPessoaContatoRepositoryGeneric
    {
        Task<PessoaContatoEntity> GetPessoaContatoByPessoaId(Guid pessoaId);
    }
}
