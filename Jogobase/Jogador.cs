
using System.ComponentModel;

class Jogador : Personagem
{
    public List<Item> Inventario { get; set; }
    public List<Missao> Missoes { get; set; }
    int Pontuacao { get; set; }

    public Jogador(string nome, Local localAtual, int pontuacao) : base(nome, localAtual)
    {
        this.Pontuacao = pontuacao;
        this.Inventario = new List<Item>();
        this.Missoes = new List<Missao>();
    }

    public override string ToString()
    {
        return $"Jogador:{base.Nome}\tLocal Atual: {base.LocalAtual}";
    }


    public void AdicionarMissao(Missao missao)
    {
        this.Missoes.Add(missao);
    }

    public void AdicionarItem(Item item)
    {
        this.Inventario.Add(item);
    }

    public void MostrarMissoes()
    {
        int i = 1;
        foreach (Missao missao in Missoes)
        {
            Console.WriteLine($"{i}- {missao.Descricao}");
            i++;
        }
    }

    public void MostrarItens()
    {
        int i = 1;
        foreach (Item item in Inventario)
        {
            Console.WriteLine($"{i}- {item.Nome}");
            i++;
        }
        if (Inventario.Count == 0)
        {
            Console.WriteLine("Vazio, sem itens...");
        }
    }

    public void UsarItem(string nome)
    {
        Inventario.RemoveAll(item => item.Nome == nome);

    }

    public void MoverPara(Local destino)
    {
        this.LocalAtual = destino;
        Console.WriteLine($"O jogador foi movido para {destino.Nome}");
    }

    public void MostrarEstatistica()
    {
        int valor = 0;
        int numeroMissoes = Missoes.Count();
        foreach (Missao missao in Missoes)
        {
            if (missao.Estado == EstadoMissao.Concluida)
            {
                valor++;
            }
        }
        double percentagem = (valor * 100) / numeroMissoes;
        Console.ForegroundColor = ConsoleColor.DarkCyan; // Define azul
        Console.WriteLine($"Progresso {percentagem:F0}%\t({valor}/{numeroMissoes}) Missões concluídas");
        Console.ResetColor(); // Volta à cor padrão
    }

    public Missao ProcuarMissao(Item item)
    {

        foreach (Missao missao in Missoes)

        {
            if (missao.ItemNecessario == item)
                return missao;
        }
        return null;
    }

    public void VerificarFimJogo()
    {
        int conta = 0;
        foreach (Missao missao in Missoes)
        {
            if (missao.Estado == EstadoMissao.Concluida)
                conta++;
        }

        if (conta == 4)
        {
            string mensagem = "Fim jogo Parabéns";
            Console.WriteLine("*********************");
            Console.WriteLine("* " + mensagem + " *");
            Console.WriteLine("*********************");
            Console.ReadLine();

        }
    }

}