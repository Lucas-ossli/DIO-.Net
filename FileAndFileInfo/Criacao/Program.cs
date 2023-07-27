using System.IO;

namespace Colecoes
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PrimeiraAula();
            //SegundaAula();
            Diretorios();
        }


        public static void PrimeiraAula()
        {
            //Criar Arquivo
            var path = Environment.CurrentDirectory + "\\teste.txt";
            //File.Create(path);

            var sw = File.CreateText(path);
            sw.WriteLine("Está é a linha 1 do arquivo");
            sw.WriteLine("Está é a linha 2 do arquivo");
            sw.WriteLine("Está é a linha 3 do arquivo");
            //Descarregar os arquivos em memória no arquivo 
            sw.Flush();

            /*
            //Sem a necessidade do Flush // IDisposable Function
            using (var sw = File.CreateText(path))
            {
                sw.WriteLine("Está é a linha 1 do arquivo");
                sw.WriteLine("Está é a linha 2 do arquivo");
                sw.WriteLine("Está é a linha 3 do arquivo");
            }
            */
        }

        public static void SegundaAula()
        {
            Console.WriteLine("Digite o nome do arquivo: ");
            var nome = Console.ReadLine();
            nome = LimparNome(nome);

            var path = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt");

            try
            {
                using (var sw = File.CreateText(path))
                {
                    sw.WriteLine("Está é a linha 1 do arquivo");
                    sw.WriteLine("Está é a linha 2 do arquivo");
                    sw.WriteLine("Está é a linha 3 do arquivo");
                }
            }
            catch
            {

                Console.WriteLine("O nome do arquivo está inválido");
            }
        }

        public static string LimparNome(string nome)
        {
            foreach (var @char in Path.GetInvalidFileNameChars())
            {
                nome = nome.Replace(@char, '-');
            }

            return nome;
        }



        public static void Diretorios()
        {

            var path = Path.Combine(Environment.CurrentDirectory, "globo");

            if (!Directory.Exists(path))
            {
                var dirGlobo = Directory.CreateDirectory(path);

                var dirAmNorte = dirGlobo.CreateSubdirectory("AmericaDoNorte");
                var dirAmCentral = dirGlobo.CreateSubdirectory("AmericaCentral");
                var dirAmSul = dirGlobo.CreateSubdirectory("AmericaDoSul");

                dirAmNorte.CreateSubdirectory("USA");
                dirAmNorte.CreateSubdirectory("Mexico");
                dirAmNorte.CreateSubdirectory("Canada");

                dirAmCentral.CreateSubdirectory("CostaRica");
                dirAmCentral.CreateSubdirectory("ElSalvador");
                dirAmCentral.CreateSubdirectory("Panama");

                dirAmSul.CreateSubdirectory("Brasil");
                dirAmSul.CreateSubdirectory("Argentina");
                dirAmSul.CreateSubdirectory("Paraguai");

                CriarArquivos();
                var origem = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
                var destino = Path.Combine(Environment.CurrentDirectory,"globo", "AmericaDoSul", "Brasil", "Brasil.txt");
                MoverArquivo(origem,destino);
            }
        }

        public static void CriarArquivos()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Brasil.txt");
            using (var sw = File.CreateText(path))
            {
                sw.WriteLine("População: 213MM");
                sw.WriteLine("IDH: 0,901");
                sw.WriteLine("Dados atualizados em: 20/04/2018");
            }
        }

        public static void MoverArquivo(string pathOrigem, string pathDestino)
        {
            if(!File.Exists(pathOrigem))
            {
                Console.WriteLine("Arquivo de origem não existe !");
                return;
            }

            if(!File.Exists(pathDestino))
            {
                Console.WriteLine("Arquivo já existe na pasta de destino !");
                return;
            }

            File.Move(pathOrigem, pathDestino);
        }

        public static void Copiar(string pathOrigem, string pathDestino)
        {
            File.Copy(pathOrigem, pathDestino);
        }






        

    }
}



