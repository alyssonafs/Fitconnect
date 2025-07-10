using Microsoft.EntityFrameworkCore;
using FitConnect.Dominio.Entidades;
using FitConnect.Dominio.Enumeradores;

public static class ExercicioSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercicio>().HasData(
            // Peito
            new Exercicio { Id = 1, Nome = "Supino Reto com Barra", GrupoMuscular = TiposGruposMusculares.Peito, Descricao = "Exercício clássico para trabalhar a parte central do peitoral.", VideoURL = "https://www.youtube.com/embed/rT7DgCr-3pg", Ativo = true },
            new Exercicio { Id = 2, Nome = "Supino Inclinado com Halteres", GrupoMuscular = TiposGruposMusculares.Peito, Descricao = "Foco no peitoral superior com maior amplitude.", VideoURL = "https://www.youtube.com/embed/8iPEnn-ltC8", Ativo = true },
            new Exercicio { Id = 3, Nome = "Crossover no Cabo", GrupoMuscular = TiposGruposMusculares.Peito, Descricao = "Exercício de isolamento para o peitoral.", VideoURL = "https://www.youtube.com/embed/taI4XduLpTk", Ativo = true },

            // Costas
            new Exercicio { Id = 4, Nome = "Puxada Frente na Polia Alta", GrupoMuscular = TiposGruposMusculares.Costas, Descricao = "Trabalha o latíssimo do dorso.", VideoURL = "https://www.youtube.com/embed/CAwf7n6Luuc", Ativo = true },
            new Exercicio { Id = 5, Nome = "Remada Curvada com Barra", GrupoMuscular = TiposGruposMusculares.Costas, Descricao = "Foco na parte média das costas.", VideoURL = "https://www.youtube.com/embed/vT2GjY_Umpw", Ativo = true },
            new Exercicio { Id = 6, Nome = "Remada Baixa com Triângulo", GrupoMuscular = TiposGruposMusculares.Costas, Descricao = "Trabalha espessura do dorso.", VideoURL = "https://www.youtube.com/embed/roCP6wCXPqo", Ativo = true },

            // Bíceps
            new Exercicio { Id = 7, Nome = "Rosca Direta com Barra", GrupoMuscular = TiposGruposMusculares.Bíceps, Descricao = "Exercício básico para bíceps.", VideoURL = "https://www.youtube.com/embed/kwG2ipFRgfo", Ativo = true },
            new Exercicio { Id = 8, Nome = "Rosca Alternada com Halteres", GrupoMuscular = TiposGruposMusculares.Bíceps, Descricao = "Movimento unilateral para foco e controle.", VideoURL = "https://www.youtube.com/embed/av7-8igSXTs", Ativo = true },
            new Exercicio { Id = 9, Nome = "Rosca Martelo", GrupoMuscular = TiposGruposMusculares.Bíceps, Descricao = "Trabalha braquiorradial e antebraço.", VideoURL = "https://www.youtube.com/embed/zC3nLlEvin4", Ativo = true },

            // Tríceps
            new Exercicio { Id = 10, Nome = "Tríceps Pulley", GrupoMuscular = TiposGruposMusculares.Tríceps, Descricao = "Isolamento do tríceps com polia.", VideoURL = "https://www.youtube.com/embed/I80Xx7pA8jQ", Ativo = true },
            new Exercicio { Id = 11, Nome = "Tríceps Testa com Barra", GrupoMuscular = TiposGruposMusculares.Tríceps, Descricao = "Trabalha todas as cabeças do tríceps.", VideoURL = "https://www.youtube.com/embed/d_KZxkY_0cM", Ativo = true },
            new Exercicio { Id = 12, Nome = "Mergulho entre Bancos", GrupoMuscular = TiposGruposMusculares.Tríceps, Descricao = "Tríceps com peso corporal.", VideoURL = "https://www.youtube.com/embed/6kALZikXxLc", Ativo = true },

            // Ombros
            new Exercicio { Id = 13, Nome = "Desenvolvimento com Halteres", GrupoMuscular = TiposGruposMusculares.Ombros, Descricao = "Foco no deltoide anterior e lateral.", VideoURL = "https://www.youtube.com/embed/qEwKCR5JCog", Ativo = true },
            new Exercicio { Id = 14, Nome = "Elevação Lateral", GrupoMuscular = TiposGruposMusculares.Ombros, Descricao = "Isolamento para deltoide lateral.", VideoURL = "https://www.youtube.com/embed/3VcKaXpzqRo", Ativo = true },
            new Exercicio { Id = 15, Nome = "Elevação Frontal com Halteres", GrupoMuscular = TiposGruposMusculares.Ombros, Descricao = "Foco no deltoide anterior.", VideoURL = "https://www.youtube.com/embed/-t7fuZ0KhDA", Ativo = true },

            // Pernas
            new Exercicio { Id = 16, Nome = "Agachamento Livre", GrupoMuscular = TiposGruposMusculares.Pernas, Descricao = "Exercício composto para pernas e glúteos.", VideoURL = "https://www.youtube.com/embed/UXJrBgI2RxA", Ativo = true },
            new Exercicio { Id = 17, Nome = "Leg Press 45°", GrupoMuscular = TiposGruposMusculares.Pernas, Descricao = "Trabalha quadríceps, glúteos e posterior.", VideoURL = "https://www.youtube.com/embed/IZxyjW7MPJQ", Ativo = true },
            new Exercicio { Id = 18, Nome = "Cadeira Extensora", GrupoMuscular = TiposGruposMusculares.Pernas, Descricao = "Isolamento para quadríceps.", VideoURL = "https://www.youtube.com/embed/YyvSfVjQeL0", Ativo = true },

            // Abdômen
            new Exercicio { Id = 19, Nome = "Abdominal Supra no Solo", GrupoMuscular = TiposGruposMusculares.Abdômen, Descricao = "Movimento básico para abdominal superior.", VideoURL = "https://www.youtube.com/embed/5ER5Of4MOPI", Ativo = true },
            new Exercicio { Id = 20, Nome = "Prancha Abdominal", GrupoMuscular = TiposGruposMusculares.Abdômen, Descricao = "Exercício isométrico para core.", VideoURL = "https://www.youtube.com/embed/pSHjTRCQxIw", Ativo = true },
            new Exercicio { Id = 21, Nome = "Elevação de Pernas na Barra Fixa", GrupoMuscular = TiposGruposMusculares.Abdômen, Descricao = "Trabalha principalmente o abdômen inferior.", VideoURL = "https://www.youtube.com/embed/l4kQd9eWclE", Ativo = true }
        );
    }
}
