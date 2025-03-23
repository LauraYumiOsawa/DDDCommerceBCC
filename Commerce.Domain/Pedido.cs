namespace Commerce.Domain;

public class Pedido
{
    public int Id { get; set; }
    public string Comprador { get; set; }
    public string Descricao { get; set; }
    public int Preco {get; set;}
}