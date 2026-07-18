

class Menu : IUtilizavel
{
    public int Menuinicial()
    {
        int escolha;
        bool verifica;
        Console.ForegroundColor = ConsoleColor.Blue; // Define azul
        Console.WriteLine("MENU PRINCIPAL");
        Console.ResetColor(); // Volta à cor padrão
        Console.WriteLine("1- Iniciar Novo Jogo");
        Console.WriteLine("2- Carregar dados de ficheiro");
        Console.WriteLine("3- Ver instruções/ajuda");
        Console.WriteLine("4- Créditos");
        Console.WriteLine("5- Sair do Jogo");
        Console.Write("Escolha: ");
        //escolha = int.Parse(Console.ReadLine());
        verifica = int.TryParse(Console.ReadLine(), out escolha);
        /*if (!verifica)
        {
            Console.Clear();
            Console.WriteLine("Valor incorreto...");
            Console.ReadLine();      
        }*/
        return escolha;

    }

    public int MenuJogo()
    {
        int escolha;
        bool verifica;
        Console.ForegroundColor = ConsoleColor.Blue; // Define azul
        Console.WriteLine("MENU DE JOGO");
        Console.ResetColor(); // Volta à cor padrão
        Console.WriteLine("1- Mover para outro local");
        Console.WriteLine("2- Interagir com Personagem");
        Console.WriteLine("3- Apanhar Objeto");
        Console.WriteLine("4- Ver Missões Ativas");
        Console.WriteLine("5- Ver Missões Concluídas");
        Console.WriteLine("6- Mostrar mapa");
        Console.WriteLine("7- Voltar para Menu Principal");

        Console.Write("Escolha:");

        verifica = int.TryParse(Console.ReadLine(), out escolha);
        //escolha = int.Parse(Console.ReadLine());

        /*if (!verifica)
        {
            Console.Clear();
            Console.WriteLine("Valor incorreto...");
            Console.ReadLine();
        }*/
        return escolha;

    }
        public Local MenuLocais(List<Local> locais)
    {
        int escolha, i = 1;
        foreach (Local local in locais)
        {
            Console.WriteLine($"{i}- {local.Nome}");
            i++;
        }
        Console.WriteLine("Escolha:");
        bool verifica = int.TryParse(Console.ReadLine(), out escolha);
        if (escolha > locais.Count || escolha < 1 || !verifica)
        {
            Console.Clear();
            Console.WriteLine("Local não encontrado");
            return null;
        }
        return locais[escolha - 1];
    }

    public void MenuInteragir(List<Personagem> personagens)
    {


        Console.WriteLine("Qual o nome da personagem?");
        string escolhido = Console.ReadLine();
        foreach (Personagem personagem in personagens)
        {
            if (personagem is NPC npc && personagem.Nome == escolhido)
            {
                Interagir(npc);
                return;
            }
            else if (personagem.Nome == escolhido)
            {
                Console.Clear();
                Console.WriteLine("Não sou a personagem do item");
                return;
            }
        }
        Console.Clear();
        Console.WriteLine("Nome de personagem não existe");
        
    }

    public void Interagir(NPC npc)
    {
        Console.Clear();
        Console.WriteLine($"Eu sou {npc.Tipo} vou ajudar...");
        Console.WriteLine($"O meu nome é {npc.Nome}. Vou autorizar o {npc.ItemParaEntregar.Nome}.");
        npc.ItemParaEntregar.AutorizarItem();
        Console.WriteLine($"Estado: {(npc.ItemParaEntregar.PodeSerApanhado ? "Pode ser apanhado" : "Não pode ser apanhado")}.");

    }


    public void MenuApanharItens(Jogador jogador, List<Item> itensvisivel)
    {
        string escolhido;
        Console.WriteLine("Apanhar item:");
        escolhido = Console.ReadLine();
        Console.Clear();
        foreach (Item item in itensvisivel)
        {
            if (item.Nome == escolhido && item.PodeSerApanhado == true)
            {
                itensvisivel.Remove(item);
                Console.WriteLine("Item apanhado com sucesso");
                jogador.AdicionarItem(item);
                Missao missao = jogador.ProcuarMissao(item);
                missao.AlterarEstado();
                Console.WriteLine($"Missão Concluída: {missao.Descricao}");

                return;
            }
            else if (item.Nome == escolhido && item.PodeSerApanhado == false)
            {
                Console.WriteLine("Item não pode ser apanhado");
                return;
            }
        }
        Console.WriteLine("Item não existe...");
    }

    public void MostrarMiConcluidas(Jogador jogador)
    {

        int i = 0;
        foreach (Missao missao in jogador.Missoes)
        {
            if (missao.Estado == EstadoMissao.Concluida)
            {
                i++;
                Console.WriteLine($"{i}- {missao.Descricao}");

            }
        }
        if (i == 0)
        {
            Console.WriteLine("Não tem missões Concluídas.");
            
        }
    }

    public void MostrarMiAtivas(Jogador jogador)
    {
        int i = 1;
        foreach (Missao missao in jogador.Missoes)
        {
            if (missao.Estado == EstadoMissao.Ativa)
            {
                Console.WriteLine($"{i}- {missao.Descricao}");
                i++;
            }
        }
    }

    public void Instrucoes()
    {
        Console.WriteLine("Alguns tópicos sobre o jogo.");
        Console.WriteLine("O jogo é constituído por personagem e itens ligados à fantasia.");
        Console.WriteLine("É preciso interagir com cada personagem e só depois apanhar os itens.");
        Console.WriteLine("Existem 4 missões. Cada missão só é cumprida quando conseguir apanhar o item.");
        Console.WriteLine("Existe uma tecla especial F4 no menu do jogo que mostra o inventário, isto é, os itens que o jogador já juntou.");

    }

    public void Creditos()
    {
        Console.WriteLine("Créditos!");
        Console.WriteLine("a64258 Marco Monteiro");
    }
    
    public void MostrarMapa()
{
    Console.WriteLine("Mapa da Escola de Magia:");
    Console.WriteLine();
    Console.WriteLine("           [Quarto]");
    Console.WriteLine("              |");
    Console.WriteLine("[Biblioteca]-----[Sala Aula]");
    Console.WriteLine("     |                 |    ");
    Console.WriteLine(" [Sotão]     [Casa do Feiticeiro Velho]");
    Console.WriteLine();
}
}