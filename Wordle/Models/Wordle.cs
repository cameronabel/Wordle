using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
  public class Wordle
  {
    private static string[] _allWords = File.ReadAllLines(@"Assets/Words.txt");
    private static HashSet<string> _setOfAllWords = new HashSet<string>(_allWords);
    public string Word { get; }
    public static bool IsValidWord(string word)
    {
      return _setOfAllWords.Contains(word);
    }
    public string JudgeLetter(char letter, int position, int timesGuessed)
    {
      if (!Word.Contains(letter.ToString()))
      {
        return "none";
      }
      char[] chars = Word.ToCharArray();
      if (chars[position] == letter)
      {
        return "green";
      }
      int occurences = chars.Count(c => c == letter);
      if (occurences >= timesGuessed)
      {
        return "yellow";
      }
      return "none";

    }
    public void JudgeWord(string guess)
    {
      Dictionary<char, int> timesGuessed = new Dictionary<char, int>() { };
      int i = 0;
      foreach (char c in guess)
      {
        int value;
        if (timesGuessed.TryGetValue(c, out value))
        {
          timesGuessed[c]++;
        }
        else
        {
          timesGuessed[c] = 1;
        }
        Console.ResetColor();
        string judgedColor = JudgeLetter(c, i, timesGuessed[c]);
        if (judgedColor == "green")
        {
          Console.BackgroundColor = ConsoleColor.Green;
          Console.ForegroundColor = ConsoleColor.Black;
        }
        else if (judgedColor == "yellow")
        {
          Console.BackgroundColor = ConsoleColor.DarkYellow;
          Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
          Console.ResetColor();
        }
        Console.Write($"\x1b[1m{c}");
        Console.ResetColor();
        Console.Write(" ");
        i++;
      }
      Console.WriteLine();

    }
    public Wordle()
    {
      Random rand = new Random();
      Word = _allWords[rand.Next(_allWords.Length)].ToUpper();
    }
  }
}
