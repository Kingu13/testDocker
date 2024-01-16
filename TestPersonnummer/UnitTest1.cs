using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

[TestFixture]
public class TestPersonnummer
{ 


    [TestCase("920101-1234")]
    [TestCase("850214-5678")]
    [TestCase("990630-9876")]
    public void IsValidPersonnummer_ValidFormat_ShouldReturnTrue(string personnummer)
    {
        // Arrange
        bool expectedResult = true;

        // Act
        bool actualResult = PersonnummerValidator.IsValidPersonnummer(personnummer);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestCase("920101-12")]
    [TestCase("8502145678")]
    [TestCase("abcde")]
    public void IsValidPersonnummer_InvalidFormat_ShouldReturnFalse(string personnummer)
    {
        // Arrange
        bool expectedResult = false;

        // Act
        bool actualResult = PersonnummerValidator.IsValidPersonnummer(personnummer);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestCase("920101-123A")]
    [TestCase("850214-56AB")]
    public void IsValidPersonnummer_InvalidCharacter_ShouldReturnFalse(string personnummer)
    {
        // Arrange
        bool expectedResult = false;

        // Act
        bool actualResult = PersonnummerValidator.IsValidPersonnummer(personnummer);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }
    [TestCase("920101-12")]
    [TestCase("8502145678")]
    [TestCase("abcde")]
    public void Main_InvalidPersonnummer_ShouldPrintCorrectMessage(string personnummer)
    {
        // Arrange
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);
        Console.SetIn(new System.IO.StringReader(personnummer));

        // Act
        PersonnummerValidator.Main();

        // Assert
        Assert.AreEqual($"Personnumret är ogiltigt.{Environment.NewLine}", consoleOutput.ToString());
    }
    [TestCase("920101-1234")]
    [TestCase("850214-5678")]
    [TestCase("990630-9876")]
    public void Main_ValidPersonnummer_ShouldPrintCorrectMessage(string personnummer)
    {
        // Arrange
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);
        Console.SetIn(new System.IO.StringReader(personnummer));

        // Act
        PersonnummerValidator.Main();

        // Assert
        Assert.AreEqual($"Personnumret är korrekt.{Environment.NewLine}", consoleOutput.ToString());
    }
    [TestCase("960229-1234", true)]
    [TestCase("000230-1234", false)] // Leap year, but invalid day (30th February).
    [TestCase("120229-1234", true)]
    public void IsValidPersonnummer_ShouldReturnCorrectResult(string personnummer, bool expectedResult)
    {
        // Act
        bool actualResult = PersonnummerValidator.IsValidPersonnummer(personnummer);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static bool IsValidPersonnummer(string personnummer)
    {
        // Extract the year, month, and day from the personnummer for testing.
        int birthYear = int.Parse(personnummer.Substring(0, 2));
        int birthMonth = int.Parse(personnummer.Substring(4, 2));
        int birthDay = int.Parse(personnummer.Substring(6, 2));

        bool isLeapYear = IsLeapYear(birthYear); // Check if it's a leap year

        if (birthMonth < 1 || birthMonth > 12)
        {
            return false; // Invalid month
        }
        if (birthDay < 1 || birthDay > 31)  // Check if the day is valid
        {
            return false; // Invalid day
        }
        if (birthMonth == 2 && birthDay > 29)
        {
            return false; // Invalid day if it is bigger then 29 days.
        }

        return true;
    }
    public static int DaysInMonth(int year, int month)
    {
        if (month == 2) // Checks if its febuary
        {
            // Leap year: 29 days, Non-leap year: 28 days
            return IsLeapYear(year) ? 29 : 28;
        }
        if (month >= 1 && month <= 7) // Odd months: 31 days, Even months: 30 days
        {
            return month % 2 == 1 ? 31 : 30;
        }
        else
        {
            return month % 2 == 0 ? 31 : 30;
        }
    }
    public static bool IsLeapYear(int year) // Checks if there is an leap year or not
    {
        // Leap year rules: divisible by 4, not divisible by 100 unless divisible by 400
        return (year == 00 || year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
