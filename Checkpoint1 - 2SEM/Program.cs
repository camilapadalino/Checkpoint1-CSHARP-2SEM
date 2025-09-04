using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== Processamento Assíncrono de Arquivos TXT ===\n");
        Console.Write("Digite o caminho do diretório que contém os arquivos .txt: ");
        string? pasta = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(pasta) || !Directory.Exists(pasta))
        {
            Console.WriteLine("❌ Diretório inválido!");
            return;
        }

        string[] arquivos = Directory.GetFiles(pasta, "*.txt");

        if (arquivos.Length == 0)
        {
            Console.WriteLine("⚠️ Nenhum arquivo .txt encontrado no diretório.");
            return;
        }

        Console.WriteLine("\nArquivos encontrados:");
        foreach (var arquivo in arquivos)
            Console.WriteLine($" - {Path.GetFileName(arquivo)}");

        Console.WriteLine("\nIniciando processamento...\n");

        // Executa todas as tarefas em paralelo
        var tarefas = arquivos.Select(ProcessarArquivo).ToList();
        var resultados = await Task.WhenAll(tarefas);

        // Cria a pasta export
        string pastaExport = Path.Combine(AppContext.BaseDirectory, "export");
        Directory.CreateDirectory(pastaExport);

        string relatorioPath = Path.Combine(pastaExport, "relatorio.txt");

        await File.WriteAllLinesAsync(relatorioPath, resultados);

        Console.WriteLine("\nProcessamento concluído com sucesso!");
        Console.WriteLine($"Relatório gerado em: {relatorioPath}");
    }

    static async Task<string> ProcessarArquivo(string caminho)
    {
        string nome = Path.GetFileName(caminho);
        Console.WriteLine($"Processando: {nome} ...");

        string[] linhas = await File.ReadAllLinesAsync(caminho);

        int totalLinhas = linhas.Length;
        int totalPalavras = linhas.Sum(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length);

        Console.WriteLine($"Concluído : {nome} - {totalLinhas} linha(s), {totalPalavras} palavra(s).");

        return $"{nome} - {totalLinhas} linhas - {totalPalavras} palavras";
    }
}
