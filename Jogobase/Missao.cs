
internal class Missao
{
    public string Descricao { get; set; }
    public EstadoMissao Estado { get; set; }
    public Local LocalAlvo { get; set; }
    public NPC NPCAlvo { get; set; }
    public Item ItemNecessario { get; set; }

    public Missao(string descricao, EstadoMissao estado, Local localAlvo, NPC npcAlvo, Item itemNecessario)
    {
        this.Descricao = descricao;
        this.Estado = estado;
        this.LocalAlvo = localAlvo;
        this.NPCAlvo = npcAlvo;
        this.ItemNecessario = itemNecessario;
    }

    public override string ToString()
    {
        return $"{Descricao}";
    }

    public void AlterarEstado()
    {
        this.Estado = EstadoMissao.Concluida;
    }

}

public enum EstadoMissao
{
    Ativa,
    Concluida
}