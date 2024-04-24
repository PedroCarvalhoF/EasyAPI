using AutoMapper;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.Entities.FormaPagamento;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces;
using Domain.Interfaces.Services.FormaPagamento;
using Domain.Models.FormaPagamentoModels;
using Domain.Repository;

namespace Service.Services.FormaPagamento
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IMapper _mapper;
        private readonly IFormaPagamentoRepository _repository;
        private readonly IRepository<FormaPagamentoEntity> _repositoryBase;

        public FormaPagamentoService(IMapper mapper, IFormaPagamentoRepository repository, IRepository<FormaPagamentoEntity> repositoryBase)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryBase = repositoryBase;
        }

        public async Task<FormaPagamentoDto> CadastrarFormaPg(FormaPagamentoDtoCreate formaPagamentoDtoCreate)
        {
            try
            {
                FormaPagamentoModels models = _mapper.Map<FormaPagamentoModels>(formaPagamentoDtoCreate);

                models.CadastrarFormaPagamento(formaPagamentoDtoCreate.DescricaoFormaPg);

                FormaPagamentoEntity entity = _mapper.Map<FormaPagamentoEntity>(models);
                FormaPagamentoEntity result = await _repositoryBase.InsertAsync(entity);

                IEnumerable<FormaPagamentoEntity> fpgCreate = await _repository.SelectAsync(fpg => fpg.Id.Equals(result.Id));

                FormaPagamentoDto formaDto = _mapper.Map<FormaPagamentoDto>(fpgCreate.FirstOrDefault());

                return formaDto;

            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<FormaPagamentoDto> AlterarFormaPg(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate)
        {
            try
            {
                FormaPagamentoModels models = _mapper.Map<FormaPagamentoModels>(formaPagamentoDtoUpdate);

                models.Alterar(formaPagamentoDtoUpdate);

                FormaPagamentoEntity entity = _mapper.Map<FormaPagamentoEntity>(models);
                FormaPagamentoEntity result = await _repositoryBase.UpdateAsync(entity);

                IEnumerable<FormaPagamentoEntity> fpgUpdate = await _repository.SelectAsync(fpg => fpg.Id.Equals(result.Id));

                FormaPagamentoDto formaDto = _mapper.Map<FormaPagamentoDto>(fpgUpdate.FirstOrDefault());

                return formaDto;

            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<IEnumerable<FormaPagamentoDto>> GetAll()
        {
            try
            {
                IEnumerable<FormaPagamentoEntity> entities = await _repository.SelectAsync(x => true);

                entities = entities.OrderBy(fpg => fpg.DescricaoFormaPg);

                IEnumerable<FormaPagamentoDto> dtos = _mapper.Map<IEnumerable<FormaPagamentoDto>>(entities);

                return dtos;
            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
