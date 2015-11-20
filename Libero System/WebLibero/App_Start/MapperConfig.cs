using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Libero;
using WebLibero.ViewModels.Veiculos;
using WebLibero.ViewModels.Clientes;
using WebLibero.ViewModels.Locacoes;

namespace WebLibero.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.CreateMap<Fabricante, Fabricante_vm>();
            Mapper.CreateMap<Fabricante_vm, Fabricante>();

            Mapper.CreateMap<Cliente, MostrarClientes_vm>();
            Mapper.CreateMap<MostrarClientes_vm, Cliente>();

            Mapper.CreateMap<Cliente, CadastroCliente_vm>();
            Mapper.CreateMap<CadastroCliente_vm, Cliente>();

            Mapper.CreateMap<Modelo, Modelo_vm>();
            Mapper.CreateMap<Modelo_vm, Modelo>();

            Mapper.CreateMap<Locacao, Locacao_vm>();
            Mapper.CreateMap<Locacao_vm, Locacao>();

            Mapper.CreateMap<Locacao, MostrarLocacoes_vm>();
            Mapper.CreateMap<MostrarLocacoes_vm, Locacao>();

            Mapper.CreateMap<Veiculo, Veiculo_vm>();
            Mapper.CreateMap<Veiculo_vm, Veiculo>();

            Mapper.CreateMap<Veiculo, CadastroVeiculo_vm>();
            Mapper.CreateMap<CadastroVeiculo_vm, Veiculo>();

        }
    }
}