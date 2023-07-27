namespace Colecoes
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = @"c:\temp\globo";

            using(var fsw = new FileSystemWatcher(path))
            {
                fsw.Created += OnCreated;
                fsw.Deleted += OnDelete;
                fsw.Renamed += OnRanamed;
            }

        }

        private static void OnRanamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"O arquivo: [{e.OldName}] foi Renomeado para [{e.Name}]");
        }

        private static void OnDelete(object sender, FileSystemEventArgs e)
        {
            
            Console.WriteLine($"O arquivo: [{e.Name}] foi Deletado");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Um arquivo foi Criado: [{e.Name}]");
        }
    }
}