using System;

namespace Colecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\Users";//:)
            LerDiretorio(path);
            LerArquivos(path);
        }


        public static void LerDiretorio(string path)
        {
            var diretorio = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            foreach (var dir in diretorio)
            {
                var dirInfo = new DirectoryInfo(dir);
                Console.WriteLine($"[Nome]:{dirInfo.Name}");
                Console.WriteLine($"[Nome]:{dirInfo.Root}");
                if (dirInfo.Parent != null)
                {
                    Console.WriteLine($"[Nome]:{dirInfo.Parent.Name}");
                }
                Console.WriteLine("//--//--//--//--//--//--//--//--//--//--//--//");
            }
        }

        public static void LerArquivos(string path)
        {
            //                                 PATH, Tipo de Arquivo E.g: * == todos, *.docx == arquivos word, *.txt  
            var arquivos = Directory.GetFiles(path,"*",SearchOption.AllDirectories);
            foreach(var arquivo in arquivos)
            {
                var fileInfo = new FileInfo(arquivo);
                Console.WriteLine($"Nome: {fileInfo.Name}");
                Console.WriteLine($"Tamanho: {fileInfo.Length}");
                Console.WriteLine($"Ultimo Acesso: {fileInfo.LastAccessTime}");
                Console.WriteLine($"Pasta: {fileInfo.DirectoryName}");
            }

        }

    }
}
