1

class Item
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool PodeSerApanhado { get; set; }

    public Item(string nome, string descricao, bool podeSerApanhado)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.PodeSerApanhado = podeSerApanhado;
    }

    public override string ToString()
    {
        return $"Item: {Nome}\tResumo: {Descricao}\tEstado: {(PodeSerApanhado ? "Pode ser apanhado" : "Não pode ser apanhado")}";
    }

    public void AutorizarItem()
    {
        this.PodeSerApanhado = true;
    }

}