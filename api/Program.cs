using apiCurso.Data;
using apiCurso.Domain;
using apiCurso.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api
{
    public class Program
    {
        protected readonly ApplicationContext _context;

        public static int Desconto { get; private set; }

        public static void Main(string[] args)
        {
            //InserirDados();
            //AlterarDados();
            //ExcluirDados();
            //ConsultarDado();
            //CadastroPedido();
            //ConsultarPedidoCarregamentoAdiantado();

        }

        private static void ConsultarPedidoCarregamentoAdiantado()
        {
            using var db = new apiCurso.Data.ApplicationContext();
            var pedidos = db.Pedidos.ToList();

            Console.WriteLine(pedidos.Count);
        }
        private static void CadastrarPedido()
        {
            using var db = new apiCurso.Data.ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciandoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido Teste",
                Status = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 10,

                    }
                }
            };

            db.Pedidos.Add(pedido);

            db.SaveChanges();
        }

        private static void ConsultarDados()
        {
            using var db = new apiCurso.Data.ApplicationContext();
            var consultaPorMetodo = db.Clientes.AsNoTracking().Where(p => p.Id > 0).ToList(); 
            foreach(var cliente in consultaPorMetodo)
            {
                Console.WriteLine($"Consultando Cliente: {cliente.Id}");
                db.Clientes.Find(cliente.Id);
            }
        }
        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "123456789",
                Valor = 10m ,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true,
            
            };

            using var db = new ApplicationContext();
            db.Add(produto);
            
            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registro(s): {registros}");
        }

        private static void AlterarDados()
        {
            using var db = new ApplicationContext();
            var produto = db.Produtos.Find(1);
            produto.Descricao = " Produto Alterado Passo 2";

            db.Produtos.Update(produto);
            db.SaveChanges();
        }

        private static void ExcluirDados()
        {
            using var db = new ApplicationContext();
            var produto = db.Produtos.Find(2);

            db.Entry(produto).State = EntityState.Deleted;
            db.SaveChanges();
        }

         private ApplicationContext ApplicationContext
        {
            get { return _context as ApplicationContext; }
        }
    }
}
