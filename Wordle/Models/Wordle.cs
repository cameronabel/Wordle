using System;
using System.IO;

namespace Game.Models
{
  public class Wordle
  {
    private static string[] _allWords = File.ReadAllLines(@"Assets/Words.txt");
    public string Word { get; }

    public Wordle()
    {
      Random rand = new Random();
      Word = _allWords[rand.Next(_allWords.Length)];
    }
  }
}
