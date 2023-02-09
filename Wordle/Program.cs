using System;
using System.Collections.Generic;
using Game.Models;

namespace Game
{
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Welcome, I am a Wordle clone!");
      Wordle newWordle = new Wordle();
      int attempts = new int();
      List<string> guessedWords = new List<string>();
      Console.WriteLine("Start guessing below:");
      while (attempts < 6)
      {
        string guess = Console.ReadLine();
        if (!Wordle.IsValidWord(guess.ToLower()))
        {
          continue;
        }
        if (guessedWords.Contains(guess))
        {
          continue;
        }
        attempts++;
        guessedWords.Add(guess);
        foreach (string word in guessedWords)
        {
          newWordle.JudgeWord(word.ToUpper());
        }
        if (guess.ToUpper() == newWordle.Word)
        {
          Console.WriteLine("You Win!");
          break;
        }
        if (attempts == 6)
        {
          Console.WriteLine($"Better luck next time! Your word was {newWordle.Word}");
        }
      }
    }
  }
}