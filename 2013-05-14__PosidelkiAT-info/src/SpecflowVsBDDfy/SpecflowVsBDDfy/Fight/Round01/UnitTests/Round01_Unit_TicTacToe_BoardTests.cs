using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

using TicTacToeEngine;

namespace SpecflowVsBDDfy.Fight.Round01.UnitTests
{
/*
        Tic-Tac-Toe Rules
        =================
        http://web.cecs.pdx.edu/~bart/cs541-fall2001/homework/tictactoe-rules.html
        The object of Tic Tac Toe is to get three in a row. You play on a three by three game board. 
        The first player is known as X and the second is O. Players alternate placing Xs and Os on 
        the game board until either oppent has three in a row or all nine squares are filled. 
        X always goes first, and in the event that no one has three in a row, the stalemate is 
        called a cat game.
*/

    
    [TestFixture]
    public class Round01_Unit_TicTacToe_BoardTests
    {
        [Test]
        public void When_Player_X_puts_three_in_a_row_it_should_win()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" }; 
            var row2 = new[] { "X", "O", "O" };
            var row3 = new[] { " ", " ", " " };
            var game = new Game(row1, row2, row3);

            // Act

            game.PlayAt(2, 0);

            // Assert

            Assert.AreEqual("X", game.Winner);
        }


        [Test]
        public void When_Player_O_puts_three_in_a_row_it_should_win()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" };
            var row2 = new[] { "X", "O", " " };
            var row3 = new[] { " ", " ", " " };
            
            var game = new Game(row1, row2, row3);

            // Act

            game.PlayAt(2, 0);

            // Assert

            Assert.AreEqual("O", game.Winner);
        }

        [Test]
        public void When_9_rows_are_filled_and_there_is_no_winner_It_should_be_Cats()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" };
            var row2 = new[] { "O", "O", "X" };
            var row3 = new[] { " ", "O", "X" };
            
            var game = new Game(row1, row2, row3);

            // Act

            game.PlayAt(2, 0);

            // Assert

            Assert.AreEqual(null, game.Winner);
        }

        [Test]
        public void When_9_rows_are_filled_and_there_is_no_winner_It_should_be_Cats_this_test_is_incorrect_and_it_should_fail()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" };
            var row2 = new[] { "X", "O", "X" };
            var row3 = new[] { " ", "O", "O" };
            
            var game = new Game(row1, row2, row3);

            // Act

            game.PlayAt(2, 0);

            // Assert

            Assert.AreEqual(null, game.Winner);
        }
    }
}
