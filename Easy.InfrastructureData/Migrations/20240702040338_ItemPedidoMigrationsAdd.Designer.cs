﻿// <auto-generated />
using System;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Easy.InfrastructureData.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240702040338_ItemPedidoMigrationsAdd")]
    partial class ItemPedidoMigrationsAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Easy.Domain.Entities.PDV.CategoriaPreco.CategoriaPrecoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<string>("DescricaoCategoriaPreco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CategoriasPrecos", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.FormaPagamento.FormaPagamentoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<string>("DescricaFormaPagamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("FormasPagamentos", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.ItensPedido.ItemPedidoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Cancelado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<decimal>("DescontoItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("PedidoId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SubTotalItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedidos", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.PDV.PontoVendaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Aberto")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("PeriodoPdvId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsuarioGerentePdvId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsuarioPdvId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PeriodoPdvId");

                    b.HasIndex("UsuarioGerentePdvId");

                    b.HasIndex("UsuarioPdvId");

                    b.ToTable("PontosVendas", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.Pedido.PedidoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Cancelado")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("CategoriaPrecoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NumeroPedido")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("PontoVendaEntityId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaPrecoId");

                    b.HasIndex("PontoVendaEntityId");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.Periodo.PeriodoPdvEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DescricaoPeriodo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("PeriodosPdvs");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.PrecoProduto.PrecoProdutoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoriaPrecoEntityId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProdutoEntityId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaPrecoEntityId");

                    b.HasIndex("ProdutoEntityId");

                    b.ToTable("PrecosProdutos", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.UserPDV.UsuarioPdvEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserPdvId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserPdvId")
                        .IsUnique();

                    b.ToTable("UsuariosPdvs", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.Produto.CategoriaProduto.CategoriaProdutoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<string>("DescricaoCategoria")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CategoriasProdutos", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.Produto.ProdutoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoriaProdutoEntityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("MedidaProdutoEnum")
                        .HasColumnType("int");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoProdutoEnum")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterClienteIdentityId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProdutoEntityId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.User.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.User.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImagemURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.User.UserRoleEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.UserMasterCliente.UserMasterClienteEntity", b =>
                {
                    b.Property<Guid>("UserMasterId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserMasterId");

                    b.ToTable("UserMasterCliente");
                });

            modelBuilder.Entity("Easy.Domain.Entities.UserMasterUser.UserMasterUserEntity", b =>
                {
                    b.Property<Guid>("UserClienteId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserMasterUserId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserClienteId", "UserMasterUserId");

                    b.HasIndex("UserMasterUserId")
                        .IsUnique();

                    b.ToTable("UsersMastersUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.ItensPedido.ItemPedidoEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.PDV.Pedido.PedidoEntity", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Easy.Domain.Entities.Produto.ProdutoEntity", "Produto")
                        .WithMany("ItensPedido")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.PDV.PontoVendaEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.PDV.Periodo.PeriodoPdvEntity", "PeriodoPdv")
                        .WithMany("PontosVendas")
                        .HasForeignKey("PeriodoPdvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Easy.Domain.Entities.PDV.UserPDV.UsuarioPdvEntity", "UsuarioGerentePdv")
                        .WithMany("UsuariosGerentesPdvs")
                        .HasForeignKey("UsuarioGerentePdvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Easy.Domain.Entities.PDV.UserPDV.UsuarioPdvEntity", "UsuarioPdv")
                        .WithMany("UsuariosPdvs")
                        .HasForeignKey("UsuarioPdvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PeriodoPdv");

                    b.Navigation("UsuarioGerentePdv");

                    b.Navigation("UsuarioPdv");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.Pedido.PedidoEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.PDV.CategoriaPreco.CategoriaPrecoEntity", "CategoriaPreco")
                        .WithMany("Pedidos")
                        .HasForeignKey("CategoriaPrecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Easy.Domain.Entities.PDV.PDV.PontoVendaEntity", "PontoVendaEntity")
                        .WithMany("Pedidos")
                        .HasForeignKey("PontoVendaEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoriaPreco");

                    b.Navigation("PontoVendaEntity");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.PrecoProduto.PrecoProdutoEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.PDV.CategoriaPreco.CategoriaPrecoEntity", "CategoriaPreco")
                        .WithMany("PrecosProdutos")
                        .HasForeignKey("CategoriaPrecoEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Easy.Domain.Entities.Produto.ProdutoEntity", "Produto")
                        .WithMany("PrecosProdutos")
                        .HasForeignKey("ProdutoEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoriaPreco");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.UserPDV.UsuarioPdvEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.User.UserEntity", "UserPdv")
                        .WithOne("UsuarioPdv")
                        .HasForeignKey("Easy.Domain.Entities.PDV.UserPDV.UsuarioPdvEntity", "UserPdvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserPdv");
                });

            modelBuilder.Entity("Easy.Domain.Entities.Produto.ProdutoEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.Produto.CategoriaProduto.CategoriaProdutoEntity", "CategoriaProdutoEntity")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaProdutoEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoriaProdutoEntity");
                });

            modelBuilder.Entity("Easy.Domain.Entities.User.UserRoleEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.User.RoleEntity", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easy.Domain.Entities.User.UserEntity", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Easy.Domain.Entities.UserMasterCliente.UserMasterClienteEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.User.UserEntity", "UserMaster")
                        .WithOne("UserMasterCliente")
                        .HasForeignKey("Easy.Domain.Entities.UserMasterCliente.UserMasterClienteEntity", "UserMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserMaster");
                });

            modelBuilder.Entity("Easy.Domain.Entities.UserMasterUser.UserMasterUserEntity", b =>
                {
                    b.HasOne("Easy.Domain.Entities.UserMasterCliente.UserMasterClienteEntity", "UserCliente")
                        .WithMany("UsersMasterUsers")
                        .HasForeignKey("UserClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easy.Domain.Entities.User.UserEntity", "UserMasterUser")
                        .WithOne("UserMasterUser")
                        .HasForeignKey("Easy.Domain.Entities.UserMasterUser.UserMasterUserEntity", "UserMasterUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCliente");

                    b.Navigation("UserMasterUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Easy.Domain.Entities.User.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Easy.Domain.Entities.User.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Easy.Domain.Entities.User.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Easy.Domain.Entities.User.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.CategoriaPreco.CategoriaPrecoEntity", b =>
                {
                    b.Navigation("Pedidos");

                    b.Navigation("PrecosProdutos");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.PDV.PontoVendaEntity", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.Pedido.PedidoEntity", b =>
                {
                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.Periodo.PeriodoPdvEntity", b =>
                {
                    b.Navigation("PontosVendas");
                });

            modelBuilder.Entity("Easy.Domain.Entities.PDV.UserPDV.UsuarioPdvEntity", b =>
                {
                    b.Navigation("UsuariosGerentesPdvs");

                    b.Navigation("UsuariosPdvs");
                });

            modelBuilder.Entity("Easy.Domain.Entities.Produto.CategoriaProduto.CategoriaProdutoEntity", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Easy.Domain.Entities.Produto.ProdutoEntity", b =>
                {
                    b.Navigation("ItensPedido");

                    b.Navigation("PrecosProdutos");
                });

            modelBuilder.Entity("Easy.Domain.Entities.User.RoleEntity", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Easy.Domain.Entities.User.UserEntity", b =>
                {
                    b.Navigation("UserMasterCliente");

                    b.Navigation("UserMasterUser");

                    b.Navigation("UserRoles");

                    b.Navigation("UsuarioPdv");
                });

            modelBuilder.Entity("Easy.Domain.Entities.UserMasterCliente.UserMasterClienteEntity", b =>
                {
                    b.Navigation("UsersMasterUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
