using Api.Domain.Dtos.PessoasDtos.PessoaTipoDtos;
using Api.Domain.Entities.Pessoa.PessoaTipo;
using Api.Domain.Interfaces.Services.Pessoas.PessoaTipo;
using AutoMapper;
using Domain.Interfaces;

namespace Api.Service.Services.Pessoas.PessoasTipo
{
    public class PessoaTipoServices : IPessoaTipoServices
    {
        private readonly IRepository<PessoaTipoEntity> _repository;
        private readonly IMapper _mapper;

        public PessoaTipoServices(IRepository<PessoaTipoEntity> repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PessoaTipoDto>> GetAll()
        {
            IEnumerable<PessoaTipoEntity> entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PessoaTipoDto>>(entities);
        }
    }
}