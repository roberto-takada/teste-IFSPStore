using IFSPStore.Domain.Base;
using System.Text.Json.Serialization;

namespace IFSPStore.Domain.Entities
{
    public class Venda : BaseEntity<int>
    {
        public Venda()
        {
            Itens = new List<VendaItem>();
        }

        public Venda(int id, DateTime data, float valorTotal, Usuario? usuario, Cliente? cliente, List<VendaItem> itens)
        {
            Id = id;
            Data = data;
            ValorTotal = valorTotal;
            Usuario = usuario;
            Cliente = cliente;
            Itens = itens;
        }
        public DateTime? Data { get; set; }
        public float? ValorTotal { get; set; }
        public Usuario? Usuario { get; set; }
        public Cliente? Cliente { get; set; }
        public List<VendaItem> Itens { get; set; }


    }

    public class VendaItem : BaseEntity<int>
    {
        public VendaItem()
        {

        }

        public VendaItem(int id, Venda venda, Produto produto, int quantidade, float valorUnitario, float valorTotal)
        {
            Id = id;
            Venda = venda;
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
        }
        [JsonIgnore]
        public Venda? Venda { get; set; }
        public Produto? Produto { get; set; }
        public int? Quantidade { get; set; }
        public float? ValorUnitario { get; set; }
        public float? ValorTotal { get; set; }

    }
}
