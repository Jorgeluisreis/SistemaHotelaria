public static class ConsoleUI
{

    // Calcula a largura do console dinamicamente para se ajustar a redimensionamentos.
    private static int ConsoleWidth => Console.WindowWidth;

    // Desenha uma linha com um caractere específico na largura do console.
    public static void DrawLine(char character = '=')
    {
        Console.WriteLine(new string(character, ConsoleWidth));
    }

    // Exibe um cabeçalho centralizado com linhas acima e abaixo.
    public static void DisplayHeader(string header)
    {
        DrawLine();
        Console.WriteLine(CenterTextInLine(header));
        DrawLine();
    }

    // Centraliza o texto em uma linha, preenchendo com espaços se necessário.
    public static string CenterTextInLine(string text)
    {
        int spaces = ConsoleWidth - text.Length;
        int padLeft = spaces / 2 + text.Length;
        return text.PadLeft(padLeft).PadRight(ConsoleWidth);
    }

    // Exibe uma mensagem de erro centralizada e espera uma tecla.
    public static void ShowErrorMessage(string message)
    {
        Console.WriteLine(CenterTextInLine(message));
        Console.ReadKey();
    }
    public static void ShowErrorMessageWithLine(string message)
    {
        //ShowErrorMenssage, só que com linha embaixo
        Console.WriteLine(CenterTextInLine(message));
        DrawResponsiveLine();
        Console.ReadKey();
    }

    // Pede ao usuário uma entrada com uma mensagem centralizada.
    public static string Prompt(string message)
    {
        Console.WriteLine(CenterTextInLine(message));
        return Console.ReadLine();
    }

    public static string PromptWithLine(string message)
    {
        Console.WriteLine(CenterTextInLine(message));
        DrawResponsiveLine(); // Adiciona a linha "---" após receber a entrada.
        var input = Console.ReadLine();
        return input;
    }
    public static void Text(string message)
    {
        /// Apenas o texto centralizado
        Console.WriteLine(CenterTextInLine(message));
    }
    public static string PromptWithLineFull(string message)
    {
        // Adiciona o DrawLine tanto em cima quanto embaixo
        DrawResponsiveLine(); // Adiciona a linha "===" após receber a entrada.
        Console.WriteLine(CenterTextInLine(message));
        DrawResponsiveLine(); // Adiciona a linha "===" após receber a entrada.
        var input = Console.ReadLine();
        return input;
    }

    // Desenha uma linha responsiva que se ajusta à largura do console, com um símbolo nas extremidades.
    public static void DrawResponsiveLine(char endSymbol = '|')
    {
        Console.Write(endSymbol);
        Console.Write(new string('-', ConsoleWidth - 2));
        Console.WriteLine(endSymbol);
    }

    // Exibe texto centralizado entre linhas de borda responsivas.
    public static void DisplayBorderedText(string text)
    {
        DrawResponsiveLine();
        Console.WriteLine(CenterTextInLine(text));
        DrawResponsiveLine();
    }

    // Formata e escreve uma linha de texto na tela, garantindo que ela se ajuste à largura do console.
    public static void FormatAndWriteLine(string text)
    {
        string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var line = new System.Text.StringBuilder();

        foreach (var word in words)
        {
            if (CenterTextInLine(line + word).Length > ConsoleWidth)
            {
                // Se adicionar a palavra ultrapassar a largura, imprima a linha atual e comece uma nova linha
                Console.WriteLine(CenterTextInLine(line.ToString().TrimEnd()));
                line.Clear();
            }

            line.Append(word + " ");
        }

        // Imprime qualquer conteúdo restante que não tenha preenchido uma linha inteira
        if (line.Length > 0)
        {
            Console.WriteLine(CenterTextInLine(line.ToString().TrimEnd()));
        }
    }
}
