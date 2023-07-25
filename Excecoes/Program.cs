
using System.Net;

public class Program
{
    
    public static void Main(string[] args)
    {

        int a = 100;
        int b = 0;
         double resultado = 0;
        try
        {
            resultado = a/b;
        }
        catch(DivideByZeroException ex2) when(b == 0 || a < 0)
        {
            Console.WriteLine(ex2.Message);
        }
        catch (System.Exception  ex)
        {
            Console.WriteLine(ex.Message);
            //throw ex;
        }
        finally  
        {
            b=2;
            resultado = a/b;
        }
       
        Console.WriteLine("{0} dividido por {1} = {2}",a,b,resultado);

    }
}