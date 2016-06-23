﻿using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio.Map;

namespace B2BTecnology.Financeiro.Negocio
{
    public class UsuarioService : Mapeamento
    {
        private static readonly UsuarioRepository UsuarioRepository = new UsuarioRepository();

        public static UsuarioDTO AcessoLogin(string login, string senha)
        {
            var usuario = UsuarioRepository.GetUsuario(login, senha);
            var usuarioDto = new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Login = usuario.Login,
                Senha = usuario.Senha
            };

            return usuarioDto;
        }
    }
}