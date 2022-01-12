using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        //[TestMethod]
        //public void Gutter_game_score_should_be_zero_test()
        //{
        //    var game = new Game();
        //    Roll(game, 0, 20);
        //    Assert.AreEqual(0, game.GetScore());
        //}

        //private void Roll(Game game, int pins, int times)
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        game.Roll(pins);
        //    }
        //}
        [TestMethod]
        public void Game_score_should_be_One_Gutter_test()
        {

        }
        [TestMethod]
        public void Game_score_should_be_All_Gutter_test()
        {
            int[,] rolls = new int[10, 3] {
               {0,0,0 },
               {0,0,0 },
                {0,0 ,0},
                {0,0,0 },
                {0,0 ,0},
                {0,0,0 },
                {0,0 ,0},
                {0,0 ,0},
                {0,0 ,0},
                {0,0,0 }
            };
            IGame game = new Game();
            int transformed = game.Run(rolls);
            int expected = 0;
            Assert.AreEqual(expected, transformed);
        }
        [TestMethod]
        public void Game_score_Basic_test()
        {
            int[,] rolls = new int[10, 3] {
               {10,0,0 },
               {9,1,0 },
                {5,5 ,0},
                {7,2,0 },
                {10,0 ,0},
                {10,0,0 },
                {10,0 ,0},
                {9,0 ,0},
                {8,2 ,0},
                {9,1,10 }
            };
            IGame game = new Game();
            int transformed = game.Run(rolls);
            int expected = 187;
            Assert.AreEqual(expected, transformed);
        }
    }
}
