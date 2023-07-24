// See https://aka.ms/new-console-template for more information
using static System.Console;
using src.Entities;
public class Program
{
    public static void Main(string[] args)
    {
        Hero playerOne = new Hero("Bizonho ", 30);
        Hero Oponent = new Hero("Tenente ", 17);

        Wizard wizard = new Wizard(){
            Name = "Mago Supremo ",
            Level = 70
        };

        

        WriteLine(playerOne);
        WriteLine(playerOne.ToString());



        WriteLine(playerOne.Attack());
        WriteLine(Oponent.Attack());
        WriteLine(wizard.Attack());

    }
}
