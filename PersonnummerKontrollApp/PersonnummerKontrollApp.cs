using System;

public class PersonnummerValidator
{
    public static void Main()
    {
        Console.WriteLine("Skriv in ett svenskt personnummer (ÅÅMMDD-XXXX):");
        string personnummerInput = Console.ReadLine();

        if (IsValidPersonnummer(personnummerInput))
        {
            Console.WriteLine("Personnumret är korrekt.");
        }
        else
        {
            Console.WriteLine("Personnumret är ogiltigt.");
        }

        Console.ReadLine();
    }

   public static bool IsValidPersonnummer(string personnummer)
    {
        // Kontrollera längden på personnumret
        if (personnummer.Length != 11)
        {
            return false;
        }

        // Kontrollera att de första nio tecknen är siffror
        for (int i = 0; i < 9; i++)
        {
            if (!char.IsDigit(personnummer[i]))
            {
                return false;
            }
        }

        // Kontrollera att tecken 10 är en bindestreck (-)
        if (personnummer[9] != '-')
        {
            return false;
        }

        // Kontrollera att tecken 11 är en siffra
        if (!char.IsDigit(personnummer[10]))
        {
            return false;
        }

        // Här kan du lägga till ytterligare logik för att verifiera personnumret, t.ex. kontrollera datum och checksumma.
        // I detta enkla exemplet kontrollerar vi bara formatet.

        return true;
    }

}
