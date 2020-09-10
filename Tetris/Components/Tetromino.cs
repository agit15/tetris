using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tetris.Config;

namespace Tetris.Components
{
    public class Tetromino
    {
        public Color Color;
        public Point[] Positions;

        public List<Cell> Cells;

        public Tetromino(Color color, Point[] positions)
        {
            Color = color;
            Positions = positions;
            Cells = new List<Cell>();
        }

        public void Normalize()
        {
            int lowestPositionX = int.MaxValue;
            int lowestPositionY = int.MaxValue;
            foreach (var position in Positions)
            {
                if (lowestPositionX > position.X)
                    lowestPositionX = position.X;
                if (lowestPositionY > position.Y)
                    lowestPositionY = position.Y;
            }

            if (lowestPositionX != 0 && lowestPositionY != 0)
            {
                var smaller = new int[] { lowestPositionX, lowestPositionY }.Min();
                var difference = Math.Abs(0 - smaller);

                var newPositions = new List<Point>();
                foreach (var pos in Positions)
                {
                    newPositions.Add(new Point(pos.X - difference, pos.Y - difference));
                }

                Positions = newPositions.ToArray();
            }
        }

        public Tetromino Clone()
        {
            var t = new Tetromino(Color, Positions);
            t.Cells.AddRange(Cells);
            return t;
        }

        public static Tetromino[] ListAll()
        {
            var tetrominos = new List<Tetromino>();
            foreach (var pattern in Constants.TetrominoPatterns)
            {
                int row = 0;
                var cells = new List<Point>();
                foreach (var line in pattern.Value.Reverse())
                {
                    for (int i=0; i < line.Length; i++)
                    {
                        if (line[i] == '0') continue;
                        cells.Add(new Point(i, row));
                    }
                    row++;
                }
                tetrominos.Add(new Tetromino(pattern.Key, cells.ToArray()));
            }
            return tetrominos.ToArray();
        }
    }
}
