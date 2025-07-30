using Microsoft.EntityFrameworkCore;
using FitConnect.Dominio.Entidades;
using FitConnect.Dominio.Enumeradores;

public static class ExercicioSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercicio>().HasData(
            // Peito
            new Exercicio { Id = 1, Nome = "Supino Reto com Barra", GrupoMuscular = TiposGruposMusculares.Peito, Descricao = "Exercício clássico para trabalhar a parte central do peitoral.", VideoURL = "https://www.youtube.com/watch?v=Kr2erpSyu3M", Ativo = true },
            new Exercicio { Id = 2, Nome = "Supino Inclinado com Halteres", GrupoMuscular = TiposGruposMusculares.Peito, Descricao = "Foco no peitoral superior com maior amplitude.", VideoURL = "https://www.youtube.com/watch?v=F4Q1g2z8MWM", Ativo = true },
            new Exercicio { Id = 3, Nome = "Crossover no Cabo", GrupoMuscular = TiposGruposMusculares.Peito, Descricao = "Exercício de isolamento para o peitoral.", VideoURL = "https://www.youtube.com/watch?v=o90Pm6qTeNI", Ativo = true },

            // Costas
            new Exercicio { Id = 4, Nome = "Puxada Frente na Polia Alta", GrupoMuscular = TiposGruposMusculares.Costas, Descricao = "Trabalha o latíssimo do dorso.", VideoURL = "https://www.youtube.com/watch?v=d9IbXfH8xYg", Ativo = true },
            new Exercicio { Id = 5, Nome = "Remada Curvada com Barra", GrupoMuscular = TiposGruposMusculares.Costas, Descricao = "Foco na parte média das costas.", VideoURL = "https://www.youtube.com/watch?v=BrwUPSLC_hE", Ativo = true },
            new Exercicio { Id = 6, Nome = "Remada Baixa com Triângulo", GrupoMuscular = TiposGruposMusculares.Costas, Descricao = "Trabalha espessura do dorso.", VideoURL = "https://www.youtube.com/watch?v=8N17XZVngdc", Ativo = true },

            // Bíceps
            new Exercicio { Id = 7, Nome = "Rosca Direta com Barra", GrupoMuscular = TiposGruposMusculares.Bíceps, Descricao = "Exercício básico para bíceps.", VideoURL = "https://www.youtube.com/watch?v=s4B8UW3BMqk", Ativo = true },
            new Exercicio { Id = 8, Nome = "Rosca Alternada com Halteres", GrupoMuscular = TiposGruposMusculares.Bíceps, Descricao = "Movimento unilateral para foco e controle.", VideoURL = "https://www.youtube.com/watch?v=mUEDnCGrNP4", Ativo = true },
            new Exercicio { Id = 9, Nome = "Rosca Martelo", GrupoMuscular = TiposGruposMusculares.Bíceps, Descricao = "Trabalha braquiorradial e antebraço.", VideoURL = "https://www.youtube.com/watch?v=5vPGH1uTtbs", Ativo = true },

            // Tríceps
            new Exercicio { Id = 10, Nome = "Tríceps Pulley", GrupoMuscular = TiposGruposMusculares.Tríceps, Descricao = "Isolamento do tríceps com polia.", VideoURL = "https://www.youtube.com/watch?v=wQdCw93LkcI", Ativo = true },
            new Exercicio { Id = 11, Nome = "Tríceps Testa com Barra", GrupoMuscular = TiposGruposMusculares.Tríceps, Descricao = "Trabalha todas as cabeças do tríceps.", VideoURL = "https://www.youtube.com/watch?v=cAzPXrCBxWY", Ativo = true },
            new Exercicio { Id = 12, Nome = "Mergulho entre Bancos", GrupoMuscular = TiposGruposMusculares.Tríceps, Descricao = "Tríceps com peso corporal.", VideoURL = "https://www.youtube.com/watch?v=LdfpvZPnUSI", Ativo = true },

            // Ombros
            new Exercicio { Id = 13, Nome = "Desenvolvimento com Halteres", GrupoMuscular = TiposGruposMusculares.Ombros, Descricao = "Foco no deltoide anterior e lateral.", VideoURL = "https://www.youtube.com/watch?v=L-iQfHVeuVg", Ativo = true },
            new Exercicio { Id = 14, Nome = "Elevação Lateral", GrupoMuscular = TiposGruposMusculares.Ombros, Descricao = "Isolamento para deltoide lateral.", VideoURL = "https://www.youtube.com/watch?v=ORparUDksUk", Ativo = true },
            new Exercicio { Id = 15, Nome = "Elevação Frontal com Halteres", GrupoMuscular = TiposGruposMusculares.Ombros, Descricao = "Foco no deltoide anterior.", VideoURL = "https://www.youtube.com/watch?v=jhxLYSm_P-k", Ativo = true },

            // Pernas
            new Exercicio { Id = 16, Nome = "Agachamento Livre", GrupoMuscular = TiposGruposMusculares.Pernas, Descricao = "Exercício composto para pernas e glúteos.", VideoURL = "https://www.youtube.com/watch?v=cReY8bUTiCM", Ativo = true },
            new Exercicio { Id = 17, Nome = "Leg Press 45°", GrupoMuscular = TiposGruposMusculares.Pernas, Descricao = "Trabalha quadríceps, glúteos e posterior.", VideoURL = "https://www.youtube.com/watch?v=3KJKb1aN6HA", Ativo = true },
            new Exercicio { Id = 18, Nome = "Cadeira Extensora", GrupoMuscular = TiposGruposMusculares.Pernas, Descricao = "Isolamento para quadríceps.", VideoURL = "https://www.youtube.com/watch?v=sY-qK1MrBSc", Ativo = true },

            // Abdômen
            new Exercicio { Id = 19, Nome = "Abdominal Supra no Solo", GrupoMuscular = TiposGruposMusculares.Abdômen, Descricao = "Movimento básico para abdominal superior.", VideoURL = "https://www.youtube.com/watch?v=mfkfUkj24co", Ativo = true },
            new Exercicio { Id = 20, Nome = "Prancha Abdominal", GrupoMuscular = TiposGruposMusculares.Abdômen, Descricao = "Exercício isométrico para core.", VideoURL = "https://www.youtube.com/watch?v=qNRqGqESAWU", Ativo = true },
            new Exercicio { Id = 21, Nome = "Elevação de Pernas na Barra Fixa", GrupoMuscular = TiposGruposMusculares.Abdômen, Descricao = "Trabalha principalmente o abdômen inferior.", VideoURL = "https://www.youtube.com/watch?v=gJfeH6Ueco4", Ativo = true }
        );
    }
}
