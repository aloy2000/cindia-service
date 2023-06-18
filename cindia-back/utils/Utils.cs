using System;
using System.Globalization;

namespace cindia_back.utils;

public static class Utils
{
    public static string ExtractAllCharacterAfterOccurence(string text, string keyword)
    {
        string[] words = text.Split(' ');
        int keywordIndex = Array.IndexOf(words, keyword);
        if (keywordIndex != -1 && keywordIndex < words.Length - 1)
        {
            string[] wordsAfterKeyword = new string[words.Length - keywordIndex - 1];
            Array.Copy(words, keywordIndex + 1, wordsAfterKeyword, 0, words.Length - keywordIndex - 1);
            
            string result = string.Join(" ", wordsAfterKeyword);
            return result;
        }
        return string.Empty;
    }

    public static object StringToDateTest(string input, string format)
    {
        string englishNameMonth;
        try
        {
            var inputToArray = input.Split(' ');
            if (inputToArray[1] == "FEVRIER" || inputToArray[1]== "fevrier")
            {
                englishNameMonth = "february";
            }
            else
            {
                englishNameMonth = GetEnglishMonthName(inputToArray[1].ToLower());
            }

            var inputToDate = inputToArray[0] + " " + englishNameMonth + " " + inputToArray[2];
            DateTime date = DateTime.Parse(inputToDate);
            return date.ToShortDateString();
        }
        catch (Exception e)
        {
            Console.WriteLine("error message:"+ e.Message);
            return false;
        }
    }
    
    private static string GetEnglishMonthName(string frenchMonthName)
    {
        CultureInfo frenchCulture = new CultureInfo("fr-FR");
        CultureInfo englishCulture = CultureInfo.InvariantCulture;

        DateTimeFormatInfo frenchFormatInfo = frenchCulture.DateTimeFormat;
        DateTimeFormatInfo englishFormatInfo = englishCulture.DateTimeFormat;

        int monthIndex = Array.IndexOf(frenchFormatInfo.MonthNames, frenchMonthName);
        if (monthIndex >= 0)
        {
            string englishMonthName = englishFormatInfo.MonthNames[monthIndex];
            return englishMonthName;
        }
        return string.Empty;
    }
}