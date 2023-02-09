using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game.Models;

namespace Game.Tests
{
  [TestClass]
  public class GameTests
  {
    [TestMethod]
    public void WordleConstructor_CreatesInstanceOfWordle_Wordle()
    {
      Wordle newWordle = new Wordle();
      Assert.AreEqual(typeof(Wordle), newWordle.GetType());
    }
    [TestMethod]
    public void WordleConstructor_SetsTargetWord_StringOfLengthFive()
    {
      Wordle newWordle = new Wordle();
      Assert.AreEqual(5, newWordle.Word.Length);
    }
  }
}