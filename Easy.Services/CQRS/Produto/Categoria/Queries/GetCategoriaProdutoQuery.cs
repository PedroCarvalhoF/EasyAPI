﻿using AutoMapper;
using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Queries;

public class GetCategoriaProdutoQuery : BaseCommands<IEnumerable<CategoriaProdutoDtoView>>
{
    public class GetCategoriaQueryHandler : IRequestHandler<GetCategoriaProdutoQuery, RequestResult<IEnumerable<CategoriaProdutoDtoView>>>
    {
        //FUTURAMENTE UTILIZAR DAPPER
        private readonly ICategoriaProdutoDapperRepository<FiltroBase> _repository;
        private readonly IMapper _mapper;

        public GetCategoriaQueryHandler(ICategoriaProdutoDapperRepository<FiltroBase> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<CategoriaProdutoDtoView>>> Handle(GetCategoriaProdutoQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetCategoriaProdutoEnity(request.GetFiltro());
            var dtos = _mapper.Map<ICollection<CategoriaProdutoDtoView>>(entities);
            return RequestResult<IEnumerable<CategoriaProdutoDtoView>>.Ok(dtos, "Consulta realizada com sucesso.");
        }
    }
}