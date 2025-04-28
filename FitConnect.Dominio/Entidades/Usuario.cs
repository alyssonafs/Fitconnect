using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public TiposUsuario TipoUsuario { get; set; }

        public bool Ativo { get; set; }

        public List<TreinoCompartilhado> TreinosCompartilhados { get; set; }

        public List<Treino> Treinos { get; set; }

        public Usuario()
        {
            Ativo = true;
        }
    }
}