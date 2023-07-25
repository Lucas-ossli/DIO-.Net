using System;

namespace Colecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] arrayInteiros = new int[3];
            int[] copy = new int[3];
            arrayInteiros[0] = 10;
            arrayInteiros[1] = 20;
            arrayInteiros[2] = 30;

            Console.WriteLine("Array copy: " + string.Join(',', copy));
            Copiar(ref arrayInteiros,ref copy);
            Console.WriteLine("Array copy: " + string.Join(',', copy));



            for(var i=0; i<arrayInteiros.Length ; i++)
            {
                Console.WriteLine(arrayInteiros[i]);
                
            }

            if(Existe(arrayInteiros, 10))
            {
                int x = 10;
                Console.WriteLine($"O valor {x} existe dentro do arrayInteiros",x);
            }


            //Retorna true or false basedo na expressão(segundo parametro)
            Array.TrueForAll(arrayInteiros, x => x < 45);

            //irá retornar o valor que vc está procurando(caso o valor estejá dentro do array) caso contrario retorna 0;
            var numero = Array.Find(arrayInteiros, x => x == 50);

            var index = Array.FindIndex(arrayInteiros, x => x == 30);
            Array.IndexOf(arrayInteiros, 30);

            //Redimencionar um Array
            int novoTamanho = 10;
            Array.Resize(ref arrayInteiros, novoTamanho);
            //

            //Converter o tipo do array
            string[] arrayString = Array.ConvertAll(arrayInteiros, x => x.ToString());
            //

            //Coleções genéricas
            List<string> strings = new List<string>();

            strings.Add("RJ");
            strings.Add("MG");
            //INSERT AT INDEX 1
            strings.Insert(1,"SP");

            //Fila
            Queue<string> Nomes = new Queue<string>();

            Nomes.Enqueue("Leonardo");
            Nomes.Enqueue("Eduardo");
            Nomes.Enqueue("André");

            while(Nomes.Count > 0)
            {   
                //Peek() == pegar o próximo elemento da fila sem remove-lo
                Console.WriteLine($"Nome: {Nomes.Peek()}");
                
                //Dequeue() == Remover e retornar o próximo elemento da fila
                Console.WriteLine($"Nome: {Nomes.Dequeue()}");
                
                Console.WriteLine($"Quantidade na fila: {Nomes.Count}");
            }

            //Pilha

            Stack<string> Pilha = new Stack<string>();

            Pilha.Push("SP");
            Pilha.Push("RJ");
            while(Pilha.Count > 0 )
            {
                //Peek() == pegar o próximo elemento da pilha sem remove-lo
                Console.WriteLine($"Nome: { Pilha.Peek()}");
                
                //Pop() == Remover e retornar o próximo elemento da pilha
                Console.WriteLine($"Nome: {Pilha.Pop()}");
                
                Console.WriteLine($"Quantidade na Pilha: {Nomes.Count}");
           
            }
            
            //Dictionary
            //          Chave, Valor
            Dictionary<string,string> Estados = new Dictionary<string, string>();

            Estados.Add("SP","São Paulo");
            Estados.Add("RJ","Rio de Janeiro");
            Estados.Add("BA","Bahia");

            foreach(KeyValuePair<string,string> item in Estados)
            {
                Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
            }

            //Estados.Select(x => x.Key == "SP");
            string ChaveProcurada = "BA";
            Console.WriteLine($"Valor: {Estados[ChaveProcurada]}");

            //Mudar Valor
            Estados[ChaveProcurada] = "BA - TESTE ATUALIZAÇÃO";
            Console.WriteLine($"Valor: {Estados[ChaveProcurada]}");

            //Remover
            Estados.Remove(ChaveProcurada);

            //Acessar de maneira segura para evitar erros 
            string ChaveTeste = "SP";
            Estados.TryGetValue(ChaveTeste, out string valorX);

            if(Estados.TryGetValue(ChaveTeste, out string valorEncontrado))
            {
                Console.WriteLine($"Valor: {valorEncontrado}");
                //Console.WriteLine($"Valor: {Estados[ChaveProcurada]}");
            }
            else
            {
                Console.WriteLine($"Chave: {ChaveTeste} não encontrada no Dictionary");
            }


            //LinQ
            int[] numbers ={1,2,4,5,7,19,56,100,100};

            //Query
            List<int> pares = (from num in numbers
            where num%2 == 0
            orderby num
            select num).ToList();

            //Método
            var pares2 = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
        
            //
            var minimo = numbers.Min();
            var max = numbers.Max();
            var media = numbers.Average();

            //Distinct() cria uma copia do array/List sem valores repetidos
            var arrayUnico = numbers.Distinct().ToArray();

            //Somar
            var soma = numbers.Sum();


        }

        public static void Copiar(ref int[] array,ref int[] copia)
        {
            Array.Copy(array, copia, array.Length);
        }

        public static bool Existe(int[] array, int valor)
        {
            return Array.Exists(array, x => x == valor);
        }

        public void arrayBiDimencional()
        {
            int[,] matriz = new int[4,2]
            {
                {8,8},
                {1,1},
                {2,2},
                {3,3}
            };



            for(var i=0 ; i<matriz.GetLength(0) ; i++)
            {
                for(var j=0;j<matriz.GetLength(1);j++)
                {
                    Console.WriteLine(matriz[i,j]);
                }
            }

        }
    }
}