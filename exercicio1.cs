List<int> numeros = new List<int>();
int opcao = 0, soma = 0;

while (true)
{
    Console.Clear();
    for (int i = 0; i < 10; i++)
    {
        Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Red : ConsoleColor.Yellow; ;
        Console.SetCursorPosition(56, 1);
        Console.WriteLine("=== LISTA DE NÚMEROS ===");
        Thread.Sleep(50);
    }
    Console.ResetColor();
    Console.WriteLine("\n\n1 - INSERIR NA LISTA");
    Console.WriteLine("2 - EXIBIR A LISTA");
    Console.WriteLine("3 - CALCULAR A SOMA E A MÉDIA");
    Console.WriteLine("4 - REMOVER DA LISTA");
    Console.WriteLine("5 - ORDENAR A LISTA");
    Console.WriteLine("0 - SAIR");
    Console.Write("Entre com a opção desejada: ");
    if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("Opção inválida! Tente novamente...");
        Console.ReadKey();
        continue;
    }

    switch (opcao)
    {
        case 0:
            Console.WriteLine("Encerrando...");
            return; // Encerra o programa
        case 1:
            Console.WriteLine("\nDigite números inteiros (ou ENTER vazio para parar): ");
            while (true)
            {
                Console.Write("Número: ");
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Voltando ao menu principal");
                    Console.ReadKey();
                    break;
                }
                if (int.TryParse(entrada, out int valor))
                    numeros.Add(valor);
                else
                {
                    Console.WriteLine("Valor inválido, tente novamente!");
                    Console.ReadKey();
                }
            }
            break;
        case 2:
            if (numeros.Count == 0)
            {
                Console.WriteLine("LISTA VAZIA!");
                Console.ReadKey();
                break;
            }
            for (int i = 0; i < numeros.Count; i++)
            {
                /* Para todos os itens, imprime o número
                 * Entre os itens, imprime vírgula.
                 * No final da lista em vez de vírgula, imprime uma
                 * quebra de linha. */
                Console.Write(i == numeros.Count - 1 ? $"{numeros[i]}\n" : $"{numeros[i]},");
            }
            Console.WriteLine("LISTA COMPLETA IMPRESSA NA TELA");
            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
            case 3:
                soma = 0;
                foreach (int n in numeros) soma+= n;
                double media = numeros.Count > 0 ? (double)soma / numeros.Count : 0;
                Console.WriteLine($"Soma = {soma} | Média = {media:F2}");
            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
            case 4:
            Console.Write("\nDigite um número para remover da lista: ");
            if(int.TryParse(Console.ReadLine(), out int remover))
            {
                if (numeros.Remove(remover))
                {
                    Console.WriteLine($"\nNúmero {remover} removido com sucesso");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("\nEsse número não existe na lista");
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("\nLista atualizada");
            for(int i = 0;i < numeros.Count;i++)
               Console.Write(i==numeros.Count-1 ? $"{numeros[i]}\n" : $"{numeros[i]},");
            Console.Write("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
            case 5:
                numeros.Sort();
                Console.WriteLine("LISTA ORDENADA");
            for (int i = 0; i < numeros.Count; i++)
               Console.Write(i == numeros.Count - 1 ? $"{numeros[i]}\n" : $"{numeros[i]},");
            Console.WriteLine("\nPressione ENTER para sair");
            Console.ReadKey();
            break;

            default:
            Console.Write("\nTentativa inválida!");
            Console.Write("\nPressione qualquer tecla para continuar");
            Console.ReadKey();
            break;
    }
}