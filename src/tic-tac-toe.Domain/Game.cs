using System;
using System.Collections.Generic;
using System.Linq;

namespace tic_tac_toe.Domain
{
    public class Game
    {
        public IList<string> Table { get; private set; }

        public Game()
        {
            Table = new string[]
            {
                string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty
            };
        }
        public bool Play(int pos)
        {
            if(Table[pos]==string.Empty)
            {
                var xCount = Table.Where(x => x == "X").Count();
                var oCount = Table.Where(x => x == "O").Count();
                var currPlay = "X";
                if(xCount>oCount)
                {
                    currPlay = "O";
                }
                Table[pos] = currPlay;
            }
            return false;
        }

        public string GetWinner()
        {
            var winner = GetRowWiner();
            if(string.IsNullOrWhiteSpace(winner))
            {
                winner = GetColumnsWiner();
                if(string.IsNullOrWhiteSpace(winner))
                {
                    winner = GetDiagonalWiner();
                }
            }
            return winner;
        }

        private string GetDiagonalWiner()
        {
            if (IsLine(new List<int> { 0, 4, 8 }))
            {
                return Table[0];
            }
            else if (IsLine(new List<int> { 2, 4, 6 }))
            {
                return Table[3];
            }
            return null;
        }

        private string GetRowWiner()
        {
            if(IsLine(new List<int> { 0, 1, 2 }))
            {
                return Table[0];
            }
            else if (IsLine(new List<int> { 3, 4, 5 }))
            {
                return Table[3];
            }
            else if (IsLine(new List<int> { 6, 7, 8 }))
            {
                return Table[6];
            }
            return null;
        }
        private string GetColumnsWiner()
        {
            if (IsLine(new List<int> { 0, 3, 6 }))
            {
                return Table[0];
            }
            else if (IsLine(new List<int> { 1, 4, 7 }))
            {
                return Table[1];
            }
            else if (IsLine(new List<int> { 2, 5, 8 }))
            {
                return Table[2];
            }
            return null;
        }
        private bool IsLine(IList<int> plays)=>
            !string.IsNullOrWhiteSpace(Table[plays[0]]) && Table[plays[0]] == Table[plays[1]] && Table[plays[0]] == Table[plays[2]];

        public bool IsDraw() => !Table.Any(x => string.IsNullOrWhiteSpace(x));
    }
}
