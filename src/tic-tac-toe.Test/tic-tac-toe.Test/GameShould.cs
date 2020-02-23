using System;
using System.Linq;
using tic_tac_toe.Domain;
using Xunit;

namespace tic_tac_toe.Test
{
    public class GameShould
    {
        [Fact]
        public void PlaceXOnFirstMove()
        {
            var sut = new Game();
            var exptected = "X";
            sut.Play(5);
            Assert.True(sut.Table.Any(x=>x==exptected));
        }
        [Fact]
        public void PlaceXAndOAlternatively()
        {
            var sut = new Game();
            var play = sut.Play(5);
            var res = sut.Play(1);
            
            Assert.True(sut.Table.Any(x => x == "X"));
            Assert.True(sut.Table.Any(x => x == "O"));
        }
        [Fact]
        public void CanNotPlayOcupatedPosition()
        {
            var sut = new Game();
            sut.Play(5);
            Assert.False(sut.Play(5));
        }
        [Fact]
        public void RowWins()
        {
            var playCollection = new int[] { 0, 3, 1, 4, 2 };
            var sut = new Game();
            foreach (var play in playCollection)
            {
                sut.Play(play);
            }
            Assert.NotNull(sut.GetWinner());
        }
        [Fact]
        public void ColumnWins()
        {
            var playCollection = new int[] { 8, 1, 2, 4, 3, 7 };
            var sut = new Game();
            foreach (var play in playCollection)
            {
                sut.Play(play);
            }
            Assert.NotNull(sut.GetWinner());

        }
        [Fact]
        public void DiagonalWins()
        {
            var playCollection = new int[] { 0, 3, 4, 1, 8 };
            var sut = new Game();
            foreach (var play in playCollection)
            {
                sut.Play(play);
            }
            Assert.NotNull(sut.GetWinner());

        }
        [Fact]
        public void ReverseDiagonalWins()
        {
            var playCollection = new int[] { 2, 3, 4, 1, 6 };
            var sut = new Game();
            foreach (var play in playCollection)
            {
                sut.Play(play);
            }
            Assert.NotNull(sut.GetWinner());

        }
        [Fact]
        public void DrawWhenAllPostionsPlayed()
        {
            var playCollection = new int[] { 0, 1, 2, 3, 4, 6, 5, 8, 7 };
            var sut = new Game();
            foreach (var play in playCollection)
            {
                sut.Play(play);
            }
            Assert.Null(sut.GetWinner());
            Assert.True(sut.IsDraw());

        }
    }
}
