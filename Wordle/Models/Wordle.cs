using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
  public class Wordle
  {
    private static string[] _allValidWords = File.ReadAllLines(@"Assets/ValidWords.txt");
    private static HashSet<string> _setOfAllWords = new HashSet<string>(File.ReadAllLines(@"Assets/Words.txt"));
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
    public List<string> JudgeWord(string guess)
    {
      Dictionary<char, int> timesGuessed = new Dictionary<char, int>() { };
      int i = 0;
      List<string> colors = new List<string>() { };
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
        colors.Add(JudgeLetter(c, i, timesGuessed[c]));
        i++;
      }
      return colors;

    }
    public Wordle()
    {
      Random rand = new Random();
      Word = _allValidWords[rand.Next(_allValidWords.Length)].ToUpper();
    }
  }
}
