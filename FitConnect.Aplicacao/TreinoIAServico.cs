using System.Text;
using System.Text.Json;
using FitConnect.Aplicacao.Interfaces;
using FitConnect.Aplicacao.Models.Requisicao.TreinoIaServico;
using FitConnect.Servicos.Interfaces;

namespace FitConnect.Aplicacao
{
    public class TreinoIAServico : ITreinoIAServico
    {
        private readonly IGeminiServico _geminiServico;

        public TreinoIAServico(IGeminiServico geminiServico)
        {
            _geminiServico = geminiServico;
        }
        public async Task<PlanoTreinoDto> GerarTreinoAsync(TreinoRequisicaoDto treinoRequisicaoDto)
        {
            var prompt = BuildPrompt(treinoRequisicaoDto);

            var iaTexto = await _geminiServico.GenerateAsync(prompt);

            var start = iaTexto.IndexOf('{');
            var end = iaTexto.LastIndexOf('}');
            string json;
            if (start >= 0 && end > start)
                json = iaTexto[start..(end + 1)];
            else
                json = iaTexto;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var plano = JsonSerializer.Deserialize<PlanoTreinoDto>(json, options)
                       ?? throw new ApplicationException("Resposta inválida da IA");

            return plano;
        }

        private string BuildPrompt(TreinoRequisicaoDto treinoRequisicaoDto)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Você é um personal trainer virtual experiente.");
            sb.AppendLine("Retorne **apenas** um JSON válido com este formato:");
            sb.AppendLine("{");
            sb.AppendLine("  \"nome\": string,");
            sb.AppendLine("  \"exercicios\": [");
            sb.AppendLine("    { \"exercicioId\": int, \"nome\": string, \"serie\": string }");
            sb.AppendLine("  ]");
            sb.AppendLine("}");
            sb.AppendLine();

            sb.AppendLine("Dados do usuário alvo:");
            sb.AppendLine($"- Altura: {treinoRequisicaoDto.UsuarioAlvoInfo.Altura} m");
            sb.AppendLine($"- Peso: {treinoRequisicaoDto.UsuarioAlvoInfo.Peso} kg");
            sb.AppendLine($"- Idade: {treinoRequisicaoDto.UsuarioAlvoInfo.Idade} anos");
            sb.AppendLine($"- IMC: {treinoRequisicaoDto.UsuarioAlvoInfo.IMC}");
            sb.AppendLine($"- Gênero: {treinoRequisicaoDto.UsuarioAlvoInfo.Genero}");
            sb.AppendLine();

            sb.AppendLine($"Objetivo: {treinoRequisicaoDto.Objetivo}");
            sb.AppendLine("Grupos musculares:");
            foreach (var gm in treinoRequisicaoDto.GruposMusculares)
                sb.AppendLine($"- {gm}");

            sb.AppendLine();

            sb.AppendLine("Exercícios disponíveis:");
            foreach (var ex in treinoRequisicaoDto.ExerciciosDisponiveis)
                sb.AppendLine($"- {ex.Id}: {ex.Nome} ({ex.GrupoMuscular})");

            sb.AppendLine();
            sb.AppendLine("Instruções:");
            sb.AppendLine("1. Use apenas esses exercícios.");
            sb.AppendLine("2. Gere para cada exercício uma série no formato “NxM” (ex: “4x15”).");

            return sb.ToString();
        }
    }
}