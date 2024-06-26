﻿using Domain.Entities.ItensPedido;
using Domain.Entities.PontoVendaUser;
using Microsoft.AspNetCore.Identity;


namespace Domain.Identity.UserIdentity
{
    public class User : IdentityUser<Guid>
    {
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? ImagemURL { get; set; }

        public IEnumerable<UserRole>? UserRoles { get; set; }
        public IEnumerable<ItemPedidoEntity>? ItemPedidoEntitiesCreate { get; set; }
        //
        public UsuarioPontoVendaEntity? UsuarioPontoVendaEntity { get; set; }
    }
}