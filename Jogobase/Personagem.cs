
class Personagem
{
    public string Nome { get; set; }
    public Local LocalAtual { get; set; }


    public Personagem(string nome, Local localAtual)
    {
        this.Nome = nome;
        this.LocalAtual = localAtual;
    }


}