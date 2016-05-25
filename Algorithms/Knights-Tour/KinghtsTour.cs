namespace Knights_Tour
{
    using System;
    using System.Collections.Generic;

    class KinghtsTour
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var board = new int[n, n];

            StartTour(board);
            PrintTour(board);
        }

        private static void PrintTour(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", board[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void StartTour(int[,] board)
        {
            int rowNum = board.GetLength(0);
            int colNum = board.GetLength(1);

            var currentPosition = new Position(0, 0);
            var currentStep = 1;
            board[0, 0] = 1;


            while (true)
            {
                var availableMoves = FindAvailableMoves(board, currentPosition);

                if (availableMoves.Count == 0)
                {
                    break;
                }

                var smallestNumOfPossibleMoves = int.MaxValue;
                Position nextPosition = new Position();
                foreach (var move in availableMoves)
                {
                    var nextMoves = FindAvailableMoves(board, move);
                    if (nextMoves.Count < smallestNumOfPossibleMoves)
                    {
                        smallestNumOfPossibleMoves = nextMoves.Count;
                        nextPosition = move;
                    }
                }

                currentStep++;
                board[nextPosition.Row, nextPosition.Col] = currentStep;
                currentPosition = nextPosition;
            }
        }

        private static List<Position> FindAvailableMoves(int[,] board, Position currentPosition)
        {
            var availableMoves = new List<Position>();
            AddPositionIfPossible(board, currentPosition, -2, -1, availableMoves);
            AddPositionIfPossible(board, currentPosition, -2, +1, availableMoves);
            AddPositionIfPossible(board, currentPosition, -1, +2, availableMoves);
            AddPositionIfPossible(board, currentPosition, +1, +2, availableMoves);
            AddPositionIfPossible(board, currentPosition, +2, -1, availableMoves);
            AddPositionIfPossible(board, currentPosition, +2, +1, availableMoves);
            AddPositionIfPossible(board, currentPosition, -1, -2, availableMoves);
            AddPositionIfPossible(board, currentPosition, +1, -2, availableMoves);
            return availableMoves;
        }

        private static void AddPositionIfPossible(
            int[,] board, 
            Position currentPosition, 
            int rowChange, 
            int colChange, 
            List<Position> availableMoves)
        {
            if (IsPossible(currentPosition.Row + rowChange, currentPosition.Col + colChange, board))
            {
                availableMoves.Add(new Position(currentPosition.Row + rowChange, currentPosition.Col + colChange));
            }
        }

        private static bool IsPossible(int row, int col, int[,] board)
        {
            bool isPossible = !(row < 0 
                || row >= board.GetLength(0)
                || col < 0 
                || col >= board.GetLength(1)
                || board[row, col] != 0);

            return isPossible;
        }
    }
}
