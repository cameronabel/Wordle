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
  }
}