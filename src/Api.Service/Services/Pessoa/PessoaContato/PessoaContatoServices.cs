using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Pessoas.PessoaContato;
using Domain.Entities.Pessoa.PessoaContato;
using Domain.Interfaces.Repository.Pessoa.PessoaContato;
using Domain.Interfaces.Services.Pessoas.PessoaContato;

namespace Service.Services.Pessoas.PessoaContato
{
    public class PessoaContatoServices : IPessoaContatoServices
    {
        private readonly IPessoaContatoRepositoryGeneric? _pessoaContatoImplementacao;
        private readonly IMapper? _mapper;
        public PessoaContatoServices(IPessoaContatoRepositoryGeneric? pessoaContatoImplementacao, IMapper? mapper)
        {
            _pessoaContatoImplementacao = pessoaContatoImplementacao;
            _mapper = mapper;
        }

        public Task<bool> CreateContatoEndereco(PessoaContatoEntity pessoaContatoEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<List<PessoaContatoDto>>> GetPessoaContatoByPessoaId(Guid pessoaId)
        {
            try
            {
                PessoaContatoEntity entity = await _pessoaContatoImplementacao.GetPessoaContatoByPessoaId(pessoaId);
                if (entity == null)
                    return new ResponseDto<List<PessoaContatoDto>>().EntitiesNull();

                var dto = _mapper.Map<PessoaContatoDto>(entity);

                return new ResponseDto<List<PessoaContatoDto>>().Retorno(new List<PessoaContatoDto>() { dto });
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<PessoaContatoDto>>().Erro(ex);
            }
        }
    }
}
