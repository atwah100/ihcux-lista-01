using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> produtos = new Dictionary<int, string>()
        {
            {1, "Salgado"},
            {2, "Refrigerante"},
            {3, "Suco"},
            {4, "Água"},
            {5, "Sanduíche"},
            {6, "Pão de Queijo"},
            {7, "Café"},
            {8, "Bolo"},
            {9, "Chocolate"},
            {10, "Cookie"}
        };

        int codigoProduto = 0;
        int quantidade = 0;
        int etapa = 1;

        Console.WriteLine("=== Sistema de Pedidos da Cantina ===");
        Console.WriteLine("Digite 'voltar' para retornar uma etapa.");
        Console.WriteLine("Digite 'cancelar' para abortar o pedido.\n");

        while (true)
        {
            switch (etapa)
            {
                case 1:
                    Console.WriteLine("[Passo 1 de 3] Seleção de Item");
                    Console.WriteLine("Produtos disponíveis:");

                    foreach (var produto in produtos)
                    {
                        Console.WriteLine($"{produto.Key} - {produto.Value}");
                    }

                    Console.Write("\nDigite o código do produto: ");
                    string entradaCodigo = Console.ReadLine()!.Trim().ToLower();

                    if (entradaCodigo == "cancelar")
                    {
                        Console.WriteLine("\nPedido cancelado pelo usuário.");
                        return;
                    }

                    if (entradaCodigo == "voltar")
                    {
                        Console.WriteLine("\nVocê já está na primeira etapa.\n");
                        break;
                    }

                    if (!int.TryParse(entradaCodigo, out codigoProduto))
                    {
                        Console.WriteLine("\nErro: você deve digitar um número de 1 a 10.\n");
                        break;
                    }

                    if (!produtos.ContainsKey(codigoProduto))
                    {
                        Console.WriteLine($"\nCódigo {codigoProduto} não encontrado. Nossos códigos vão de 1 a 10. Tente novamente.\n");
                        break;
                    }

                    Console.WriteLine($"Produto selecionado: {produtos[codigoProduto]}\n");
                    etapa++;
                    break;

                case 2:
                    Console.WriteLine("[Passo 2 de 3] Quantidade");
                    Console.Write($"Digite a quantidade para {produtos[codigoProduto]}: ");
                    string entradaQuantidade = Console.ReadLine()!.Trim().ToLower();

                    if (entradaQuantidade == "cancelar")
                    {
                        Console.WriteLine("\nPedido cancelado pelo usuário.");
                        return;
                    }

                    if (entradaQuantidade == "voltar")
                    {
                        Console.WriteLine();
                        etapa--;
                        break;
                    }

                    if (!int.TryParse(entradaQuantidade, out quantidade))
                    {
                        Console.WriteLine("\nErro: digite apenas números inteiros para a quantidade.\n");
                        break;
                    }

                    if (quantidade <= 0)
                    {
                        Console.WriteLine("\nErro: a quantidade deve ser maior que zero.\n");
                        break;
                    }

                    Console.WriteLine($"Quantidade informada: {quantidade}\n");
                    etapa++;
                    break;

                case 3:
                    Console.WriteLine("[Passo 3 de 3] Confirmação do Pedido");
                    Console.WriteLine($"Produto: {produtos[codigoProduto]}");
                    Console.WriteLine($"Quantidade: {quantidade}");
                    Console.Write("\nDigite 'confirmar' para finalizar, 'voltar' para corrigir ou 'cancelar' para sair: ");
                    string confirmacao = Console.ReadLine()!.Trim().ToLower();

                    if (confirmacao == "cancelar")
                    {
                        Console.WriteLine("\nPedido cancelado pelo usuário.");
                        return;
                    }

                    if (confirmacao == "voltar")
                    {
                        Console.WriteLine();
                        etapa--;
                        break;
                    }

                    if (confirmacao == "confirmar")
                    {
                        Console.WriteLine("\nPedido realizado com sucesso!");
                        Console.WriteLine($"Resumo: {quantidade}x {produtos[codigoProduto]}");
                        return;
                    }

                    Console.WriteLine("\nOpção inválida. Digite 'confirmar', 'voltar' ou 'cancelar'.\n");
                    break;
            }
        }
    }
}