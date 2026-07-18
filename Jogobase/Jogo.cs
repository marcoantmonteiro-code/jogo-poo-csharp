
class Jogo
{

    public static void IniciarJogo()
    {
        bool listarItens = false;
        List<Item> itensJogo = new List<Item>();
        int escolha;

        do
        {
            //public Item(string nome, string descricao, bool podeSerApanhado)

            itensJogo.Clear();

            if (!listarItens)
            {
                itensJogo = new List<Item>{
                    new Item("Chave", "Chave para abrir a porta", false),
                    new Item("Varinha", "Varinha para fazer feitiços", false),
                    new Item("Formula", "Folha com fórmula de feitiço", false),
                    new Item("Caixa", "Caixa Fechada", false)
                };
            }
            else
            {
                itensJogo = CarregarDados(Dados.CarregarItensDoCSV("Itens.csv"));
            }


            // public Local(string nome)
            Local local0 = new Local("Quarto");
            Local local1 = new Local("Sala Aula");
            Local local2 = new Local("Biblioteca");
            Local local3 = new Local("Sotão");
            Local local4 = new Local("Casa do Feiticeiro Velho");

            /*
            List<Local> locais = new List<Local>();
            locais.Add(local0);
            locais.Add(local1);
            locais.Add(local2);
            locais.Add(local3);
            locais.Add(local4);*/

            local0.AdicionarLlocal(local1);
            local0.AdicionarLlocal(local2);
            local1.AdicionarLlocal(local0);
            local1.AdicionarLlocal(local4);
            local2.AdicionarLlocal(local0);
            local2.AdicionarLlocal(local3);
            local3.AdicionarLlocal(local2);
            local4.AdicionarLlocal(local1);
            
            // public NPC(string nome, Local localAtual, string tipoNPC, Item itemParaEntregar): base(nome, localAtual)
            NPC personagemA1 = new NPC("Baltazar", local1, TipoNPC.Professor, itensJogo[0]);
            NPC personagemA2 = new NPC("Rui", local2, TipoNPC.Colega, itensJogo[1]);
            NPC personagemA3 = new NPC("Norberto", local3, TipoNPC.Funcionário, itensJogo[2]);
            NPC personagemA4 = new NPC("Orion", local4, TipoNPC.Feiticeiro, itensJogo[3]);

            Personagem figuranteA0 = new Personagem("Maria", local0);
            Personagem figuranteA1 = new Personagem("João", local1);
            Personagem figuranteA2 = new Personagem("Ana", local2);
            Personagem figuranteA3 = new Personagem("Nelson", local3);
            Personagem figuranteA4 = new Personagem("Luis", local4);
            // public Jogador(string nome, Local localAtual, int pontuacao):base(nome, localAtual)
            Jogador jogador1 = new Jogador("Jogador", local0, 0);

            //local0.AdicionarPersonagem(jogador1);
            local0.AdicionarPersonagem(figuranteA0);
            local1.AdicionarPersonagem(personagemA1);
            local1.AdicionarPersonagem(figuranteA1);
            local2.AdicionarPersonagem(personagemA2);
            local2.AdicionarPersonagem(figuranteA2);
            local3.AdicionarPersonagem(personagemA3);
            local3.AdicionarPersonagem(figuranteA3);
            local4.AdicionarPersonagem(personagemA4);
            local4.AdicionarPersonagem(figuranteA4);

            local1.AdicionarItem(itensJogo[0]);
            local2.AdicionarItem(itensJogo[1]);
            local3.AdicionarItem(itensJogo[2]);
            local4.AdicionarItem(itensJogo[3]);

            //public Missao(string descricao, bool estado, Local localAlvo, NPC npcAlvo, Item itemNecessario)
            Missao missao1 = new Missao("Apanhar item que o professor oferece", EstadoMissao.Ativa, local1, personagemA1, itensJogo[0]);
            Missao missao2 = new Missao("Estudar item com colega", EstadoMissao.Ativa, local2, personagemA2, itensJogo[1]);
            Missao missao3 = new Missao("Encontrar item no sotão", EstadoMissao.Ativa, local3, personagemA3, itensJogo[2]);
            Missao missao4 = new Missao("Pedir item ao Feiticeito Velho", EstadoMissao.Ativa, local4, personagemA4, itensJogo[3]);
            /*
                    List<Missao> missoes = new List<Missao>();
                    missoes.Add(missao1);
                    missoes.Add(missao2);
                    missoes.Add(missao3);
                    missoes.Add(missao4);
            */

            jogador1.AdicionarMissao(missao1);
            jogador1.AdicionarMissao(missao2);
            jogador1.AdicionarMissao(missao3);
            jogador1.AdicionarMissao(missao4);

            Menu menu = new Menu();



            do
            {
                Console.Clear();
                escolha = menu.Menuinicial();
                Console.Clear();
                int valor = 0;
                int conta;
                switch (escolha)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            jogador1.MostrarEstatistica();
                            Console.WriteLine(jogador1);
                            Console.WriteLine("Itens Visiveis:");
                            conta = jogador1.LocalAtual.MostrarItens();
                            if (conta == 0)
                                Console.WriteLine("Sem itens no local.");
                        
                            //Console.WriteLine("Pressione F4 para ver o inventário ou ENTER para continuar...");
                            var key = Console.ReadKey(true);
                            Console.Clear();

                            if (key.Key == ConsoleKey.F4)
                            {
                                Console.WriteLine("Inventário do Jogador:");
                                jogador1.MostrarItens();
                                //Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                                Console.ReadKey(true);
                                continue; // volta ao início do loop
                            }
                            jogador1.VerificarFimJogo();
                            valor = menu.MenuJogo();

                            Console.Clear();
                            switch (valor)
                            {
                                case 1:
                                    Local escolhido = menu.MenuLocais(jogador1.LocalAtual.localDestino);
                                    if (escolhido == null)
                                    {
                                        Console.ReadLine();
                                        break;
                                    }
                                    Console.Clear();
                                    jogador1.MoverPara(escolhido);
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    conta = jogador1.LocalAtual.MostrarPersonagens();
                                    if (conta == 0)
                                    {
                                        Console.WriteLine("Não há personagens no local");
                                        Console.ReadLine();
                                        break;
                                    }
                                    menu.MenuInteragir(jogador1.LocalAtual.PersonagensPresentes);
                                    Console.ReadLine();
                                    break;

                                case 3:
                                    conta = jogador1.LocalAtual.MostrarItens();
                                    if (conta == 0)
                                    {
                                        Console.WriteLine("Não há itens visíveis neste local.");
                                        Console.ReadLine();
                                        break;
                                    }
                                    menu.MenuApanharItens(jogador1, jogador1.LocalAtual.ItensVisiveis);
                                    Console.ReadLine();
                                    break;

                                case 4:
                                    Console.WriteLine("Missões Ativas");
                                    menu.MostrarMiAtivas(jogador1);
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Missões concluidas");
                                    menu.MostrarMiConcluidas(jogador1);
                                    Console.ReadLine();
                                    break;

                                case 6: menu.MostrarMapa();
                                    Console.ReadLine();
                                        break;
                                case 7: break;
                                default:
                                    Console.WriteLine("Menu não existe.");
                                    Console.ReadLine();
                                    break;
                            }

                        } while (valor != 7);
                        break;
                    case 2: //Console.WriteLine("Carregar dados do CSV");
                        listarItens = true;
                        Console.WriteLine("Autorizado...");
                        Console.ReadLine();
                        //Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Instruçoes:");
                        menu.Instrucoes();
                        Console.ReadLine();
                        break;

                    case 4:
                        menu.Creditos();
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Obrigado por jogar! Até à próxima.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Menu não existe.");
                        Console.ReadLine();
                        break;

                }
            } while (escolha != 5 && escolha != 2);
            //if (escolha == 5) break;
        } while (escolha !=5);

    }



    public static void MostrarMissoes(List<Missao> missoes)
    {
        int i = 1;
        foreach (Missao missao in missoes)
        {
            Console.WriteLine($"{i}-{missao}");
            i++;
        }
    }

    public static List<Item> CarregarDados(List<Item> itens)
    {
        List<Item> itensJogo = new List<Item>();
        foreach (Item item in itens)
        {
            itensJogo.Add(item);
        }
        return itensJogo;


    }

}