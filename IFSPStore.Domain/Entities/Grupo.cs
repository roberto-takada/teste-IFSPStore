using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    public class Grupo : BaseEntity<int>
    {
        public Grupo()
        {

        }

        public Grupo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public string? Nome { get; set; }
    }
}
