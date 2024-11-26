using ControlePedidos.Produto.Domain.Enums;

namespace CadastroPedidos.Produto.Application.UseCases.GravarProduto;

public class GravarProdutosRequest
{
    public required string Nome { get; set; }
    public required List<KeyValuePair<string, decimal>> TamanhoPreco { get; set; }
    public TipoProduto TipoProduto { get; set; }
    public required string Descricao { get; set; }
}
