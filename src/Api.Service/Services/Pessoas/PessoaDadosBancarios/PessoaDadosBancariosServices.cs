using AutoMapper;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Interfaces;
using Domain.Interfaces.Services.Pessoas.PessoaDadosBancarios;

namespace Service.Services.Pessoas.Pessoa
{
    public class PessoaDadosBancariosServices : IPessoaDadosBancariosServices
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryGeneric<PessoaDadosBancariosEntity> _repository;
        public PessoaDadosBancariosServices(IRepositoryGeneric<PessoaDadosBancariosEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreatePessoaDadosBancarios(PessoaDadosBancariosEntity entity)
        {
            var result = await _repository.InsertGenericAsync(entity);
            if (result != null)
                return true;
            else
                return false;
        }
    }
}
