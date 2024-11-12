using IFSPStore.Domain.Entities;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Sources;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestDomain
    {
        [TestMethod]
        public void TestCidade()
        {
            Cidade cidade = new Cidade(1, "Birigui", "SP");

            Debug.WriteLine(JsonSerializer.Serialize(cidade));

            Assert.AreEqual(cidade.Nome, "Birigui");
            Assert.AreEqual(cidade.Estado, "SP");
        }

        [TestMethod]
        public void TestCliente()
        {
            Cidade cidade = new Cidade(1, "Birigui", "SP");

            
            Cliente cliente = new Cliente(1, "NomeCliente", "EnderecoCliente", "DocumentoCliente", "BairroCliente", cidade);

            Debug.WriteLine(JsonSerializer.Serialize(cliente));

            Assert.AreEqual(cliente.Nome, "NomeCliente");
            Assert.AreEqual(cliente.Endereco, "EnderecoCliente");
            Assert.AreEqual(cliente.Documento, "DocumentoCliente");
            Assert.AreEqual(cliente.Bairro, "BairroCliente");
            Assert.AreEqual(cliente.Cidade, cidade);


        }

        [TestMethod]

        public void TestGrupo()
        {
            Grupo grupo = new Grupo(1, "NomeGrupo");

            Debug.WriteLine(JsonSerializer.Serialize(grupo));

            Assert.AreEqual(grupo.Nome, "NomeGrupo");
        }

        [TestMethod]
        public void TestProduto()
        {
            Grupo grupo = new Grupo(1, "NomeGrupo");

            Produto produto = new Produto(1, "NomeProduto", 99.99f, 99, DateTime.Parse("2024-10-26 11:40:00"), "UnidadeVendaProduto", grupo);

            Debug.WriteLine(JsonSerializer.Serialize(produto));

            Assert.AreEqual(produto.Nome, "NomeProduto");
            Assert.AreEqual(produto.Preco, 99.99f);
            Assert.AreEqual(produto.Quantidade, 99);
            Assert.AreEqual(produto.DataCompra, DateTime.Parse("2024-10-26 11:40:00"));
            Assert.AreEqual(produto.UnidadeVenda, "UnidadeVendaProduto");
            Assert.AreEqual(produto.Grupo, grupo);
        }

        [TestMethod]
        public void TestUsuario()
        {
            Usuario usuario = new Usuario(1, "NomeUsuario", "SenhaUsuario", "LoginUsuario",
            "EmailUsuario", DateTime.Parse("2024-10-22 10:00:00"), DateTime.Parse("2024-10-26 12:00:00"),
            true);

            Debug.WriteLine(JsonSerializer.Serialize(usuario));

            Assert.AreEqual(usuario.Nome, "NomeUsuario");
            Assert.AreEqual(usuario.Senha, "SenhaUsuario");
            Assert.AreEqual(usuario.Login, "LoginUsuario");
            Assert.AreEqual(usuario.Email, "EmailUsuario");
            Assert.AreEqual(usuario.DataCadastro, DateTime.Parse("2024-10-22 10:00:00"));
            Assert.AreEqual(usuario.DataLogin, DateTime.Parse("2024-10-26 12:00:00"));
            Assert.AreEqual(usuario.Ativo, true);
        }

        [TestMethod]
        public void TestVenda()
        {
            Usuario usuario = new Usuario(1, "NomeUsuario", "SenhaUsuario", "LoginUsuario",
            "EmailUsuario", DateTime.Parse("2024-10-22 10:00:00"), DateTime.Parse("2024-10-26 12:00:00"),
            true);

            Cidade cidade = new Cidade(1, "Birigui", "SP");


            Cliente cliente = new Cliente(1, "NomeCliente", "EnderecoCliente", "DocumentoCliente", "BairroCliente", cidade);

            Grupo grupo = new Grupo(1, "NomeGrupo");

            Produto produto = new Produto(1, "NomeProduto", 99.99f, 99, DateTime.Parse("2024-10-26 11:40:00"), "UnidadeVendaProduto", grupo);

            List<VendaItem> itens = new List<VendaItem>();

            Venda venda = new Venda(1, DateTime.Parse("2024-10-25 09:30:00"), 990.00f,
                usuario, cliente, itens);

            VendaItem vendaItem = new VendaItem(1, venda, produto, 5, 2.00f, 10.00f);

            itens.Add(vendaItem);

            Debug.WriteLine(JsonSerializer.Serialize(venda));

            Assert.AreEqual(venda.Data, DateTime.Parse("2024-10-25 09:30:00"));
            Assert.AreEqual(venda.ValorTotal, 990.00f);
            Assert.AreEqual(venda.Usuario, usuario);
            Assert.AreEqual(venda.Cliente, cliente);
            Assert.AreEqual(venda.Itens, itens);
            

        }

    }
}