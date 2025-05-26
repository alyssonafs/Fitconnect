using FitConnect.Dominio.Enumeradores;

namespace FitConnect.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }

        public TiposGenero Genero { get; set; }

        public TiposUsuario TipoUsuario { get; set; }

        public double Peso { get; set; }

        public double Altura { get; set; }

        public bool Ativo { get; set; }

        public List<TreinoCompartilhado> TreinosCompartilhados { get; set; }

        public List<Treino> Treinos { get; set; }

        public Usuario()
        {
            Ativo = true;
        }

        public void Deletar()
        {
            Ativo = false;
        }

        public void Restaurar()
        {
            Ativo = true;
        }

        public double IMC()
        {
            var imc = this.Peso / (this.Altura * this.Altura);
            return imc;
        }
    }
}