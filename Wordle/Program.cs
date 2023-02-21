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
      while (true)
      {
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
            List<string> colors = newWordle.JudgeWord(word.ToUpper());
            WriteWord(word.ToUpper(), colors);
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
        Console.WriteLine("Play again? (Y/N)");
        string playAgain = Console.ReadLine();
        if (playAgain.ToUpper() == "Y")
        {
          continue;
        }
        else
        {
          Environment.Exit(0);
        }
      }
    }
    public static void WriteWord(string guess, List<string> colors)
    {
      for (int i = 0; i < 5; i++)
      {
        if (colors[i] == "green")
        {
          Console.BackgroundColor = ConsoleColor.Green;
          Console.ForegroundColor = ConsoleColor.Black;
        }
        else if (colors[i] == "yellow")
        {
          Console.BackgroundColor = ConsoleColor.DarkYellow;
          Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
          Console.ResetColor();
        }
        Console.Write($"\x1b[1m{guess[i]}");
        Console.ResetColor();
        Console.Write(" ");
      }
      Console.WriteLine();
    }
  }
}