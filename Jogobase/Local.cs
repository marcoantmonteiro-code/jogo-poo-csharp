

class Local
{
    public string Nome { get; set; }
    public List<Personagem> PersonagensPresentes { get; set; }
    public List<Item> ItensVisiveis { get; set; }
    public List<Local> localDestino { get; set; }

    public Local(string nome)
    {
        this.Nome = nome;
        this.PersonagensPresentes = new List<Personagem>();
        this.ItensVisiveis = new List<Item>();
        this.localDestino = new List<Local>();
    }

    public override string ToString()
    {
        return $"{Nome}";
    }

    public void AdicionarPersonagem(Personagem personagem)
    {
        this.PersonagensPresentes.Add(personagem);
    }

    public void RemoverPersonagem(Personagem personagem)
    {
        this.PersonagensPresentes.Remove(personagem);
    }

    public void AdicionarItem(Item item)
    {
        this.ItensVisiveis.Add(item);
    }

    public void RemoverItem(Item item)
    {
        this.ItensVisiveis.Remove(item);
    }

    public int MostrarPersonagens()
    {
        int conta = 0;
        int i = 1;
        foreach (Personagem personagem in PersonagensPresentes)
        {

            Console.WriteLine($"{i}- {personagem.Nome}");
            i++;
            conta++;
        }

        return conta;
    }

    public int MostrarItens()
    {
        int conta = 0;
        int i = 1;
        foreach (Item item in ItensVisiveis)
        {
            Console.WriteLine($"{i} - {item}");
            i++;
            conta++;
        }
        return conta;
    }

    public void AdicionarLlocal(Local local)
    {
        localDestino.Add(local);
    }

}