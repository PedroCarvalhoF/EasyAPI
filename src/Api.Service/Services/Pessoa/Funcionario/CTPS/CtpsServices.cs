using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Pessoa.Funcionario.CTPS;
using Domain.Entities.Pessoa.Funcionario.CTPS;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Pessoa.Funcionario.CTPS;
using Domain.Interfaces.Services.Pessoa.Funcionario.CTPS;
using Domain.Models.Pessoa.Funcionario.CTPS;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Service.Services.Pessoa.Funcionario.CTPS
{
    public class CtpsServices : ICtpsServices
    {
        private readonly IMapper? _mapper;
        private readonly IBaseRepository<CtpsEntity>? _baseRepository;
        private readonly ICtpsRepository? _ctpsRepository;

        public CtpsServices(IMapper? mapper, IBaseRepository<CtpsEntity>? baseRepository, ICtpsRepository? ctpsRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _ctpsRepository = ctpsRepository;
        }

        public async Task<ResponseDto<List<CtpsDto>>> GetAll()
        {
            try
            {
                var entities = await _ctpsRepository.GetAll();
                if (entities == null || entities.Count() == 0)
                    return new ResponseDto<List<CtpsDto>>().EntitiesNull();

                var dtos = _mapper.Map<List<CtpsDto>>(entities);

                return new ResponseDto<List<CtpsDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<CtpsDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CtpsDto>>> GetByIdCtps(Guid ctpsId)
        {
            try
            {
                var entity = await _ctpsRepository.GetByIdCtps(ctpsId);
                if (entity == null)
                    return new ResponseDto<List<CtpsDto>>().EntitiesNull();

                var dto = _mapper.Map<CtpsDto>(entity);

                return new ResponseDto<List<CtpsDto>>().Retorno(new List<CtpsDto>() { dto });
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<CtpsDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CtpsDto>>> Create(CtpsDtoCreate create)
        {
            try
            {
                var model = _mapper.Map<CtpsModel>(create);
                var entity = _mapper.Map<CtpsEntity>(model);
                var result = await _baseRepository.InsertAsync(entity);
                if (result == null)
                    return new ResponseDto<List<CtpsDto>>().ErroCadastro();

                return new ResponseDto<List<CtpsDto>>().CadastroOk();
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<CtpsDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CtpsDto>>> Update(CtpsDtoUpdate update)
        {
            try
            {
                var model = _mapper.Map<CtpsModel>(update);
                var entity = _mapper.Map<CtpsEntity>(model);
                var result = await _baseRepository.UpdateAsync(entity);
                if (result == null)
                    return new ResponseDto<List<CtpsDto>>().ErroCadastro();

                return new ResponseDto<List<CtpsDto>>().CadastroOk();
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<CtpsDto>>().Erro(ex);
            }
        }
    }
}
