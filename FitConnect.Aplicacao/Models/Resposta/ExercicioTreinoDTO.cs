using FitConnect.Dominio.Enumeradores;

public class ExercicioTreinoDto
{
    public int Id { get; set; }
    public int ExercicioId { get; set; }
    public int TreinoId { get; set; }
    public string Nome { get; set; }
    public TiposGruposMusculares GrupoMuscular { get; set; }

    public string Descricao { get; set; }
    public string VideoURL { get; set; }
    public string Series { get; set; }
}