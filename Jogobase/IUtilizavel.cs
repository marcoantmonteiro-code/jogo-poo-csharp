
interface IUtilizavel
{

    int Menuinicial();
    int MenuJogo();
    Local MenuLocais(List<Local> locais);
    void MenuApanharItens(Jogador jogador, List<Item> itensvisivel);
    void MenuInteragir(List<Personagem> personagens);
    void Interagir(NPC npc);
    void MostrarMiConcluidas(Jogador jogador);
    void MostrarMiAtivas(Jogador jogador);
    void Instrucoes();
    void Creditos();



}
    

