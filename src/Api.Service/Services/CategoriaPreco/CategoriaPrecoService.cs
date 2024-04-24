using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using Api.Domain.Models.CategoriaPreco;
using AutoMapper;
using Domain.Interfaces;
using Domain.Repository;

namespace Api.Service.Services.CategoriaPreco
{
    public class CategoriaPrecoService : ICategoriaPrecoService
    {
        private readonly IRepository<CategoriaPrecoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly ICategoriaPrecoRepository _categoriaPrecoRepository;

        public CategoriaPrecoService(IRepository<CategoriaPrecoEntity> repository, IMapper mapper, ICategoriaPrecoRepository categoriaPrecoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _categoriaPrecoRepository = categoriaPrecoRepository;
        }
        public async Task<CategoriaPrecoDtoCreateResult> Cadastrar(CategoriaPrecoDtoCreate categoriaPrecoDtoCreate)
        {
            try
            {
                CategoriaPrecoModels model = _mapper.Map<CategoriaPrecoModels>(categoriaPrecoDtoCreate);

                model.Habilitado = true;

                CategoriaPrecoEntity entity = _mapper.Map<CategoriaPrecoEntity>(model);
                CategoriaPrecoEntity result = await _repository.InsertAsync(entity);
                return _mapper.Map<CategoriaPrecoDtoCreateResult>(await _repository.SelectAsync(result.Id));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<CategoriaPrecoDto>> ConsultarTodos()
        {
            try
            {
                IEnumerable<CategoriaPrecoEntity> entities = await
                     _categoriaPrecoRepository.ConsultarTodasCategoriasPrecosIncludeProdutos();


                return _mapper.Map<IEnumerable<CategoriaPrecoDto>>(entities);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}