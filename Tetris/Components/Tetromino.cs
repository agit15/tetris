using System.Collections.Generic;
using System.Drawing;
using Tetris.Config;

namespace Tetris.Components
{
    public class Tetromino
    {
        public Color Color;
        public Point[] Positions;

        public Tetromino(Color color, Point[] positions)
        {
            Color = color;
            Positions = positions;
        }

        public static Tetromino[] ListAll()
        {
            var tetrominos = new List<Tetromino>();
            foreach (var pattern in Constants.TetrominoPatterns)
            {
                int row = 0;
                var cells = new List<Point>();
                foreach (var line in pattern.Value)
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
