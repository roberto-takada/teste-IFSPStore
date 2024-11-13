using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace IFSPStore.Test
{
    [TestClass]
    public class UnityTestRepository
    {
        //public object JsonSerialLizer { get; private set; }

        public partial class MyDbContext : DbContext

        {
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Cidade> Cidades { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Grupo> Grupo { get; set; }
            public DbSet<Produto> Produtos { get; set; }
            public DbSet<Venda> Vendas { get; set; }
            public DbSet<VendaItem> Vendaitens { get; set; }
            public MyDbContext() //esse é o método construtor
            {
                //vai criar o banco de dados a partir dessas classes acima
                Database.EnsureCreated();


            }

            //o protect deixa que todos estão na mesma classe possam ver, apenas eles
            //override é referente a um polimorfismo
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //vamos conectar ao banco de dados
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "ifsp"; //senha do mysql workbench
                var strCon = $"Server={server};Port={port};Database={database};" +
                    $"Uid={username};Pwd={password}";

                if(!optionsBuilder.IsConfigured) 
                {
                    optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));
                }
            }

        }

        [TestMethod]
        public void TestInsertCidades()
        {
            using (var context = new MyDbContext())
            {
                var cidade = new Cidade
                {
                    Nome = "Birigui",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);

                cidade = new Cidade
                {
                    Nome = "Araçatuba",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestListCidades()
        {
            using(var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidades)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cidade));
                }
            }
        }


        [TestMethod]
        public void TestInsertClientes()
        {
            using( var context = new MyDbContext())
            {
                var cidade = context.Cidades.FirstOrDefault(c => c.Id == 1);
                cidade = context.Cidades.FirstOrDefault(c => c.Id == 2);
                var cliente = new Cliente
                {
                    Nome = "Alan",
                    Cidade = cidade,
                    Endereco = "Rua Padre Geraldo",
                    Documento = "49282918831",
                    Bairro = "Fátima"
                };
                context.Clientes.Add(cliente);

                cliente = new Cliente
                {
                    Nome = "Miguel",
                    Cidade = cidade,
                    Endereco = "Rua Pedro Cavalo",
                    Documento = "4924563872",
                    Bairro = "Portal da Pérola"
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestListClientes()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Clientes)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cliente));
                }
            }        
        }

        [TestMethod]
        public void TestInsertGrupos()
        {
            using (var context = new MyDbContext())
            {
                var grupo = new Grupo
                {
                    Nome = "Limpeza",
                };
                context.Grupo.Add(grupo);

                grupo = new Grupo
                {
                    Nome = "Alimentício",
                };
                context.Grupo.Add(grupo);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestListGrupos()
        {
            using (var context = new MyDbContext())
            {
                foreach (var grupo in context.Grupo)
                {
                    Console.WriteLine(JsonSerializer.Serialize(grupo));
                }
            }
        }


        [TestMethod]
        public void TestInsertProdutos()
        {
            using(var context = new MyDbContext())
            {
                var grupo = context.Grupo.FirstOrDefault(c => c.Id == 1);
                grupo = context.Grupo.FirstOrDefault(c => c.Id == 2);
                var produto = new Produto
                {
                    Nome = "Sabão em pó OMO",
                    Preco = 12.00f,
                    Quantidade = 5,
                    DataCompra = DateTime.Parse("2024-02-04 05:40:12"),
                    UnidadeVenda = "5",
                    Grupo = grupo
                };
                context.Produtos.Add(produto);

                produto = new Produto
                {
                    Nome = "Bolacha Maizea",
                    Preco = 6.00f,
                    Quantidade = 2,
                    DataCompra = DateTime.Parse("2024-02-04 07:20:12"),
                    UnidadeVenda = "2",
                    Grupo = grupo
                };
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestListProdutos()
        {
            using(var context = new MyDbContext())
            {
                foreach(var produto in context.Produtos)
                {
                    Console.WriteLine(JsonSerializer.Serialize(produto));
                }
            }
        }

        [TestMethod]
        public void TesteInsertUsuarios()
        {
            using(var context = new MyDbContext())
            {
                var usuario = new Usuario
                {
                    Nome = "Cardoso",
                    Senha = "1234",
                    Login = "cardoso356",
                    Email = "cardoso@gmail.com",
                    DataCadastro = DateTime.Parse("2023-02-05 15:30:20"),
                    DataLogin = DateTime.Parse("2023-02-06 08:20:12"),
                    Ativo = true
                };
                context.Usuarios.Add(usuario);

                usuario = new Usuario
                {
                    Nome = "Lucas",
                    Senha = "1234",
                    Login = "Lucas35",
                    Email = "lucas@gmail.com",
                    DataCadastro = DateTime.Parse("2024-02-05 16:30:20"),
                    DataLogin = DateTime.Parse("2024-02-06 09:20:12"),
                    Ativo = false
                };
                context.Usuarios.Add(usuario);

                context.SaveChanges();
            }
        }


        [TestMethod]
        public void TestListUsuarios()
        {
            using(var context = new MyDbContext())
            {
                foreach(var usuario in context.Usuarios)
                {
                    Console.WriteLine(JsonSerializer.Serialize(usuario));
                }
            }
        }


        [TestMethod]
        public void TestInsertVenda()
        {
            using (var context = new MyDbContext())
            {
                var usuario = context.Usuarios.FirstOrDefault(c => c.Id == 1); //chave estrangeira
                var cliente = context.Clientes.FirstOrDefault(c => c.Id == 1);
                var produto = context.Produtos.FirstOrDefault(c => c.Id == 1);

                var Venda = new Venda
                {
                    Data = DateTime.Parse("2022-05-12 08:40:06"),
                    ValorTotal = 112,
                    Usuario = usuario,
                    Cliente = cliente,
                    Itens = new List<VendaItem>()
                };

                var vendaItem = new VendaItem
                {
                    Venda = Venda,
                    Produto = produto,
                    Quantidade = 2,
                    ValorUnitario = 3,
                    ValorTotal = 6
                };
                Venda.Itens.Add(vendaItem);
                context.Vendas.Add(Venda);



                Venda = context.Vendas.FirstOrDefault(context => context.Id == 2);
                usuario = context.Usuarios.FirstOrDefault(c => c.Id == 2); //chave estrangeira
                cliente = context.Clientes.FirstOrDefault(c => c.Id == 2);
                Venda = new Venda
                {
                    Data = DateTime.Parse("2022-05-13 10:32:10"),
                    ValorTotal = 50,
                    Usuario = usuario,
                    Cliente = cliente,
                    Itens = new List<VendaItem>()
                };

                produto = context.Produtos.FirstOrDefault(c => c.Id == 1);
                vendaItem = new VendaItem
                {
                    Venda = Venda,
                    Produto = produto,
                    Quantidade = 3,
                    ValorUnitario = 4,
                    ValorTotal = 12
                };
                Venda.Itens.Add(vendaItem);
                context.Vendas.Add(Venda);

                context.SaveChanges();
            }
        }


        [TestMethod]
        public void TestListVenda()
        {
            using (var context = new MyDbContext())
            {
                foreach(var venda in context.Vendas)
                {
                    Console.WriteLine(JsonSerializer.Serialize(venda));
                }
            }
        }

    }
}
