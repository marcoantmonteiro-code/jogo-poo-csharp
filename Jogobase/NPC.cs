

class NPC : Personagem
{
    public TipoNPC Tipo { get; set; }
    public Item ItemParaEntregar { get; set; }

    public NPC(string nome, Local localAtual, TipoNPC tipo, Item itemParaEntregar) : base(nome, localAtual)
    {
        this.Tipo = tipo;
        this.ItemParaEntregar = itemParaEntregar;
    }

    public override string ToString()
    {
        return $"Personagem: {base.Nome}";
    }
}

public enum TipoNPC
{
    Professor,
    Colega,
    Funcionário,
    Feiticeiro
}