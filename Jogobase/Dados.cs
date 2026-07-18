

class Dados
{
    public static List<Item> CarregarItensDoCSV(string caminho)
    {
        var itens = new List<Item>();
        try
        {
            foreach (var linha in File.ReadAllLines(caminho))
            {
                if (string.IsNullOrWhiteSpace(linha) || linha.StartsWith("Nome")) continue;
                var partes = linha.Split(',');
                // Nome,Descricao,PodeSerApanhado
                string nome = partes[0];
                string descricao = partes[1];
                bool podeSerApanhado = bool.Parse(partes[2]);
                itens.Add(new Item(nome, descricao, podeSerApanhado));
            }
            Console.WriteLine("Carregamento com sucesso.");

        }
        catch
        {
            Console.WriteLine("Erro de carregamento.");
        }
        return itens;
    }
}