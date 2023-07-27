

public class Program
{
    

    public static void Main(string[] args)
    {
        Matematica m = new Matematica(10,20);

        m.Somar();
    }
}


public class Calculadora
{
    public delegate void DelegateCalculadora();
    public static event DelegateCalculadora EventoCalculadora;

    public static void Somar(int a, int b)
    {
        if(EventoCalculadora != null)
        {
            Console.WriteLine($"Adição: {a+b}");
            EventoCalculadora();
        }
        else
        {
            Console.WriteLine($"Nenhum inscrito");
        }
       
    }

    public static void Subtrair(int a, int b)
    {
        Console.WriteLine($"Subtração: {a-b}");
    }
}

public class Matematica
{
    public int ValorX { get; set; }
    public int ValorY { get; set; }

    public Matematica(int x, int y)
    {
        ValorX = x;
        ValorY = y;

        Calculadora.EventoCalculadora += EventHandler;
    }


    public void Somar()
    {
        Calculadora.Somar(ValorX, ValorY);
    }


    public void EventHandler()
    {
        Console.WriteLine("Método executado");
    }



}