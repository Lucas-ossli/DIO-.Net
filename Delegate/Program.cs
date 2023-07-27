

public class Program
{
    public delegate void Operacao(int a, int b);
    public static void Main(string[] args)
    {
        //Operacao op = Calculadora.Somar;
        Operacao operacao = new Operacao(Calculadora.Somar);

        Console.WriteLine("2 Invoke de Somar: ");
        operacao.Invoke(10,10);
        Console.Write(".");
        operacao(10,10);
        Console.WriteLine("-----------------------");


        
        Console.WriteLine("Invoke de Subtrair: ");
        //Trocar o ponteiro de função para outra
        operacao = Calculadora.Subtrair;
        operacao.Invoke(20,30);
        Console.WriteLine("-----------------------");
        
        //OU
        
        Console.WriteLine("Cast dos dois métodos:");
        //Tem como adicionar Ponteiros de diferentes funções: 
        //Isso faz com que as duas funcções sejam executadas no Invoke
        operacao += Calculadora.Somar;
        operacao.Invoke(50,30);
        Console.WriteLine("-----------------------");


    }
}


public class Calculadora
{

    public static void Somar(int a, int b)
    {
        Console.WriteLine($"Adição: {a+b}");
    }

    public static void Subtrair(int a, int b)
    {
        Console.WriteLine($"Subtração: {a-b}");
    }
}