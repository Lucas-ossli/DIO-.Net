
using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //CriarCsv();
            //LerCsv();
            //CsvDynamic();
            //LerCsvComClasse();
            LerCsvComOutroDelimitador();
            LerCsvComIndice();
            EscreverCsv();
        }

        public static void LerCsv()
        {
            var path = Path.Combine(Environment.CurrentDirectory,
           "Entrada",
           "usuario-exportacao.csv");
            using (var sr = new StreamReader(path))
            {
                var cabecalho = sr.ReadLine()?.Split(',');

                while (true)
                {
                    var registro = sr.ReadLine()?.Split(',');
                    if (registro == null) break;
                    for (int i = 0; i < registro.Length; i++)
                    {
                        Console.WriteLine($"{cabecalho?[i]}: {registro[i]}");
                    }

                    Console.WriteLine("------------------");
                }
            }
        }

        static void CriarCsv()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Saida");

            var Pessoas = new List<Pessoa>(){
                new Pessoa(){
                    Nome="José da Silva",
                    Email = "J@gmail.com",
                    Telefone=12345465,
                    Nascimento = new DateOnly(year:1970, month: 2, day:14).ToString()
                },

                new Pessoa(){
                    Nome="Fiódor Dostoiévski",
                    Email = "FiodorDostoiévski@gmail.com",
                    Telefone=12345465,
                    Nascimento = new DateOnly(year:1867, month: 02, day:09).ToString()
                },

                new Pessoa(){
                    Nome="Clive Staples Lewis",
                    Email = "CliveStaplesLewis@gmail.com",
                    Telefone=12345465,
                    Nascimento = new DateOnly(year:1956, month: 11, day:22).ToString()
                }
            };

            var dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
                path = Path.Combine(path, "usuario-exportacao.csv");
            }

            dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.WriteLine("Nome,Email,Telefone,Nascimento");
                    foreach (var pessoa in Pessoas)
                    {
                        var linha = $"{pessoa.Nome},{pessoa.Email},{pessoa.Telefone},{pessoa.Nascimento}";
                        sw.WriteLine(linha);
                    }
                }
            }


        }

        public static void CsvDynamic()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Produto", "Produtos.csv");

            var fi = new FileInfo(path);
            if (!fi.Exists)
                throw new FileNotFoundException($"O arquivo {path} Já Existe");

            using (var sr = new StreamReader(fi.FullName))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    var registros = csvReader.GetRecords<dynamic>();

                    foreach (var registro in registros)
                    {
                        Console.WriteLine($"Nome: {registro.produto}");
                        Console.WriteLine($"Marca: {registro.marca}");
                        Console.WriteLine($"Preço: {registro.preco}");
                        Console.WriteLine($"------------------------------");
                    }
                }
            }
        }

        public static void LerCsvComClasse()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "usuario-exportacao.csv");
            var fi = new FileInfo(path);
            if (!fi.Exists)
                throw new FileNotFoundException($"O arquivo {path} Não Existe");

            using (var sr = new StreamReader(fi.FullName))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    var registros = csvReader.GetRecords<Pessoa>();

                    foreach (var registro in registros)
                    {
                        Console.WriteLine($"Nome: {registro.Nome}");
                        Console.WriteLine($"Email: {registro.Email}");
                        Console.WriteLine($"Telefone: {registro.Telefone}");
                        Console.WriteLine($"------------------------------");
                    }
                }
            }

        }

        public static void LerCsvComOutroDelimitador()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "Livros-preco-com-virgula.csv");

            var fi = new FileInfo(path);
            if (!fi.Exists)
                throw new FileNotFoundException($"O arquivo {path} Não Existe");

            using (var sr = new StreamReader(fi.FullName))
            {

                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };

                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    csvReader.Context.RegisterClassMap<LivroMap>();
                    var registros = csvReader.GetRecords<Livro>().ToList();

                    foreach (var registro in registros)
                    {
                        Console.WriteLine($"Título: {registro.Titulo}");
                        Console.WriteLine($"Autor: {registro.Autor}");
                        Console.WriteLine($"Preço: {registro.Preco}");
                        Console.WriteLine($"Lancamento: {registro.Lancamento}");
                        Console.WriteLine($"------------------------------");
                    }
                }
            }
        }

        public static void LerCsvComIndice()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "Livros-preco-com-virgula.csv");

            var fi = new FileInfo(path);
            if (!fi.Exists)
                throw new FileNotFoundException($"O arquivo {path} Não Existe");

            using (var sr = new StreamReader(fi.FullName))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };

                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    csvReader.Context.RegisterClassMap<LivroMap>();
                    var registros = csvReader.GetRecords<Livro>().ToList();

                    foreach (var registro in registros)
                    {
                        Console.WriteLine($"Título: {registro.Titulo}");
                        Console.WriteLine($"Autor: {registro.Autor}");
                        Console.WriteLine($"Preço: {registro.Preco}");
                        Console.WriteLine($"Lancamento: {registro.Lancamento}");
                        Console.WriteLine($"------------------------------");
                    }
                }
            }
        }

        public static void EscreverCsv()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Saida");

            var dir = new DirectoryInfo(path);

            if (!dir.Exists)
                dir.Create();

            path = Path.Combine(path, "usuario.csv");

            var pessoas = new List<Pessoa>(){
                new Pessoa(){
                    Nome="José da Silva",
                    Email = "J@gmail.com",
                    Telefone=12345465,
                    Nascimento = new DateOnly(year:1970, month: 2, day:14).ToString()
                },

                new Pessoa(){
                    Nome="Fiódor Dostoiévski",
                    Email = "FiodorDostoiévski@gmail.com",
                    Telefone=12345465,
                    Nascimento = new DateOnly(year:1867, month: 02, day:09).ToString()
                },

                new Pessoa(){
                    Nome="Clive Staples Lewis",
                    Email = "CliveStaplesLewis@gmail.com",
                    Telefone=12345465,
                    Nascimento = new DateOnly(year:1956, month: 11, day:22).ToString()
                }
            };

            using (var sr = new StreamWriter(path))
            {
                using (var csvWriter = new CsvWriter(sr, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(pessoas);
                }
            }
        
        }

    }
}

public class Livro
{
    [Index(0)]
    public string Titulo { get; set; }
    [Index(1)]
    public decimal Preco { get; set; }
    [Index(2)]
    public string Autor { get; set; }
    [Index(3)]
    public string Lancamento { get; set; }
}

public class LivroMap : ClassMap<Livro>
{
    public LivroMap()
    {
        Map(x => x.Titulo).Name("Titulo")
        .Index(0);
        Map(x => x.Preco).Name("Preco")
        .Index(1);
        Map(x => x.Autor).Name("Autor")
        .Index(2);
        Map(x => x.Lancamento).Name("Lancamento")
        .Index(3);

    }
}
public class Pessoa
{
    public int Telefone { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string? Nascimento { get; set; }

}