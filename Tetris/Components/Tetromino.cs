using System.Collections.Generic;
using System.Drawing;
using Tetris.Config;

namespace Tetris.Components
{
    public class Tetromino
    {
        public Color Color;
        public TetrominoCell[] Cells;

        public Tetromino(Color color, TetrominoCell[] cells)
        {
            Color = color;
            Cells = cells;
        }

        public struct TetrominoCell
        {
            public Point Position;

            public TetrominoCell(Point position)
            {
                Position = position;
            }
        }

        public static Tetromino[] ListAll()
        {
            var tetrominos = new List<Tetromino>();
            foreach (var pattern in Constants.TetrominoPatterns)
            {
                int row = 0;
                var cells = new List<TetrominoCell>();
                foreach (var line in pattern.Value)
                {
                    for (int i=0; i < line.Length; i++)
                    {
                        if (line[i] == '0') continue;
                        cells.Add(new TetrominoCell(new Point(i, row)));
                    }
                    row++;
                }
                tetrominos.Add(new Tetromino(pattern.Key, cells.ToArray()));
            }
            return tetrominos.ToArray();
        }
    }
}
