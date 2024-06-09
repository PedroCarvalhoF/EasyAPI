using Domain.Entities.Pessoa.Pessoas;
using Domain.Interfaces;
using Domain.Interfaces.Services.Pessoas.PessoaEndereco;

namespace Service.Services.Pessoas.PessoaEndereo
{
    public class PessoaEnderecoServices : IPessoaEnderecoServices
    {
        private readonly IRepositoryGeneric<PessoaEnderecoEntity>? _pessoaEnderecoRepositoryGeneric;
        public PessoaEnderecoServices(IRepositoryGeneric<PessoaEnderecoEntity>? pessoaEnderecoRepositoryGeneric)
        {
            _pessoaEnderecoRepositoryGeneric = pessoaEnderecoRepositoryGeneric;
        }
        public async Task<bool> CreatePessoaEndereco(PessoaEnderecoEntity pessoaEnderecoEntity)
        {
            try
            {
                var result = await _pessoaEnderecoRepositoryGeneric.InsertGenericAsync(pessoaEnderecoEntity);
                if (result != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
