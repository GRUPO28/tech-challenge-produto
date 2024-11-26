using CadastroPedidos.Produto.Application.Abstractions;
using ControlePedidos.Common.Exceptions;
using ControlePedidos.Produto.Domain.Abstractions;

namespace CadastroPedidos.Produto.Application.UseCases.DeletarProduto;

public class DeletarProdutoUseCase : IUseCase<DeletarProdutoRequest>
{
    private readonly IProdutoRepository _produtoRepository;

    public DeletarProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public async Task ExecuteAsync(DeletarProdutoRequest request)
    {
        var produto = await _produtoRepository.ObterProdutoAsync(request.Id);

        if (produto is null)
        {
            throw new ApplicationNotificationException("Produto não encontrado");
        }

        await _produtoRepository.RemoverProdutoAsync(produto);
    }
}
