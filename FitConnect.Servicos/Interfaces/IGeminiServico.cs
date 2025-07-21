namespace FitConnect.Servicos.Interfaces
{
    public interface IGeminiServico
    {
        Task<string> GenerateAsync(string prompt);
    }
}