using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

using TicTacToeEngine;

namespace SpecflowVsBDDfy.Fight.Round01.BDDfy
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


    [Story(
        AsA = "As a player",
        IWant = "I want to have a tic tac toe game",
        SoThat = "So that I can waste some time!")]    
    [TestFixture]
    public class Round01_BDDfy_TicTacToe_BoardTests
    {

        Game game;
        
        void Given_the_following_board(string[] firstRow, string[] secondRow, string[] thirdrow)
        {
            game = new Game(firstRow, secondRow, thirdrow);
        }

        void Then_the_winner_should_be(string expectedWinner)
        {
            Assert.AreEqual(game.Winner, expectedWinner);
        }

        void Then_it_should_be_a_Cats_game()
        {
            Assert.IsNull(game.Winner);
        }

        void When_the_game_is_played_at(int row, int column)
        {
            game.PlayAt(row, column);
        }

        void When_X_moves_at(int row, int column)
        {
            When_the_game_is_played_at(row, column);
        }

        void When_O_moves_at(int row, int column)
        {
            When_the_game_is_played_at(row, column);
        }
        
        
        
        [Test]
        public void X_Wins_situation()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" }; 
            var row2 = new[] { "X", "O", "O" };
            var row3 = new[] { " ", " ", " " };

            this.Given(_ => Given_the_following_board(row1, row2, row3))
                .When(_ => When_X_moves_at(2, 0))
                .Then(_ => Then_the_winner_should_be("X"))
                .BDDfy();
        }


        [Test]
        public void O_Wins_situation()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" };
            var row2 = new[] { "X", "O", " " };
            var row3 = new[] { " ", " ", " " };

            this.Given(_ => Given_the_following_board(row1, row2, row3))
                .When(_ => When_O_moves_at(2, 0))
                .Then(_ => Then_the_winner_should_be("O"))
                .BDDfy();
        }

        [Test]
        public void Cats_situation()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" };
            var row2 = new[] { "O", "O", "X" };
            var row3 = new[] { " ", "O", "X" };
            
            this.Given(_ => Given_the_following_board(row1, row2, row3))
                .When(_ => When_O_moves_at(2, 0))
                .Then(_ => Then_it_should_be_a_Cats_game())
                .BDDfy();
        }

        [Test]
        public void Cats_situation_this_test_is_incorrect_and_it_should_fail()
        {
            // Arrange 
            var row1 = new[] { "X", "X", "O" };
            var row2 = new[] { "X", "O", "X" };
            var row3 = new[] { " ", "O", "O" };

            this.Given(_ => Given_the_following_board(row1, row2, row3))
                .When(_ => When_O_moves_at(2, 0))
                .Then(_ => Then_it_should_be_a_Cats_game())
                .BDDfy();
        }
    }
}
