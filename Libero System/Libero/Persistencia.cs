using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Libero
{

    public class Persistencia : IPersistencia
    {
        //public static Persistencia p = new Persistencia();
        //public void PersistirAluguel(Locacao l)
        //{
        //    using (var ctx = new Context())
        //    {
        //        var alugueis = ctx.Locacoes;
        //        alugueis.Add(l);
        //    }
        //}
       
        //public List<Veiculo> LerVeiculo()
        //{
        //    List<Veiculo> listaVeic = new List<Veiculo>();
        //    using (var ctx = new Context())
        //    {
        //        var veic = ctx.Veiculos.Where(x => !x.Locacoes.Any(y => y.DataRetorno == null));
        //        foreach (var item in veic)
        //        {
        //            listaVeic.Add(item);
        //        }
        //        return listaVeic;
        //    }
        //}
        //public List<string> LerVeiculoLocado()
        //{
        //    List<string> listaPlacas = new List<string>();
        //    using (var ctx = new Context())
        //    {
        //        var veic = ctx.Veiculos.Where(x => x.Locacoes.Any(y => y.DataRetorno == null));
        //        foreach (var item in veic)
        //        {
        //            listaPlacas.Add(item.Placa);
        //        }
        //        return listaPlacas;
        //    }
        //}
        //public List<Cliente> LerCliente()
        //{
        //    List<Cliente> listaClientes = new List<Cliente>();
        //    using (var ctx = new Context())
        //    {
        //        var clientes = ctx.Clientes.Where(x => x.Cpf != null);
        //        foreach (var item in clientes)
        //        {
        //            listaClientes.Add(item);
        //        }
        //        return listaClientes;
        //    }
        //}
        //public List<Locacao> LerLocacao()
        //{
        //    List<Locacao> listaLocacoes = new List<Locacao>();
        //    using (var ctx = new Context())
        //    {
        //        var clientes = ctx.Locacoes.Where(x => x.LocacaoId != null);
        //        foreach (var item in clientes)
        //        {
        //            listaLocacoes.Add(item);
        //        }
        //        return listaLocacoes;
        //    }
        //}
        //public List<Modelo> LerModelo()
        //{
        //    List<Modelo> listaModelos = new List<Modelo>();


        //    using (var ctx = new Context())
        //    {
        //        var modelos = ctx.Modelos.Distinct().Where(x => x.ModeloId != null).Distinct();


        //        foreach (var item in modelos)
        //        {
        //            listaModelos.Add(item);
        //        }
                
        //        return listaModelos;
        //    }
        //}
        //public List<Fabricante> LerFabricante()
        //{
        //    List<Fabricante> listaFabricantes = new List<Fabricante>();
        //    using (var ctx = new Context())
        //    {
        //        var fabricantes = ctx.Fabricantes.Distinct().Where(x => x.FabricanteId != null).Distinct();
        //        foreach (var item in fabricantes)
        //        {
        //            listaFabricantes.Add(item);
        //        }
        //        return listaFabricantes;
        //    }
        //}
        //public void LocarVeiculo(string placa, string cliente)
        //{
        //    using (var ctx = new Context())
        //    {
        //        var veicLocado = ctx.Veiculos.First(x => x.Placa == placa);
        //        var clienteLocatario = ctx.Clientes.Single(x => x.Nome == cliente);

        //        var loc = ctx.Locacoes;

        //        Locacao l = new Locacao();

        //        l.Cliente = clienteLocatario;
        //        l.Veiculo = veicLocado;
        //        l.DataSaida = DateTime.Now;
        //        loc.Add(l);
        //        ctx.SaveChanges();
        //    }
        //}
        //public void DevolverVeiculo(string placa)
        //{
        //    using (var ctx = new Context())
        //    {
        //        var veic = ctx.Locacoes.Where(y=>y.DataRetorno == null).FirstOrDefault(x => x.Veiculo.Placa == placa);

        //        veic.DataRetorno = DateTime.Now;

        //        ctx.SaveChanges();
        //    }
        //}
        //public void CadastrarCliente(Cliente valor)
        //{

        //    using (var ctx = new Context())
        //    {

        //        var clientes = ctx.Clientes;
        //        clientes.Add(valor);
        //        ctx.SaveChanges();
        //    }

        //}
        //public void CadastrarVeiculo(Veiculo valor, string modelo)
        //{
        //    using (var ctx = new Context())
        //    {
        //        var mod = ctx.Modelos.Distinct().First(x => x.Nome == modelo);
        //        var veiculos = ctx.Veiculos;
        //        valor.Modelo = mod;
        //        veiculos.Add(valor);
        //        ctx.SaveChanges();
        //    }

        //}
        //public void CadastrarModelo(Modelo mod, string fabricante)
        //{
        //    using (var ctx = new Context())
        //    {
        //        var fab = ctx.Fabricantes.First(x => x.Nome == fabricante);
        //        var modelo = ctx.Modelos;
        //        mod.Fabricante = fab;
        //        modelo.Add(mod);

        //        ctx.SaveChanges();
        //    }
        //}
        //public void CadastrarFabricante(Fabricante f)
        //{
        //    using (var ctx = new Context())
        //    {
        //        var fab = ctx.Fabricantes;

        //        fab.Add(f);

        //        ctx.SaveChanges();
        //    }
        //}



    }
}


