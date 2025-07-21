using FitConnect.Servicos.Interfaces;
using GenerativeAI;
using Microsoft.Extensions.Configuration;

namespace FitConnect.Servicos.GeminiServico
{
    public class GeminiServico : IGeminiServico
    {
        private readonly GenerativeModel _model;

        public GeminiServico(IConfiguration config)
        {
            var apiKey = config["Google:ApiKey"];
            var googleAI = new GoogleAi(apiKey);
            _model = googleAI.CreateGenerativeModel("gemini-2.5-flash");
        }
        public async Task<string> GenerateAsync(string prompt)
        {
            var response = await _model.GenerateContentAsync(prompt);
            return response.Text;
        }
    }
}