using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Config;

namespace Tetris.Components
{
    public class PlayGround : Grid
    {
        private KeyValuePair<Point, Tetromino>? _currentTetromino;

        public PlayGround(int width, int height, TableLayoutPanel panel) : base(width, height, panel)
        { }

        public override void PaintCell(object sender, TableLayoutCellPaintEventArgs e)
        {
            int col = e.Column - 1;
            int row = e.Row - 1;

            // Paint's everything except the borders based on the offset of the PlayGround grid
            if (e.Column == 0 || e.Row == 0) return;
            if (e.Column >= width +1 || e.Row >= height + 1) return;

            var cell = GetCell(col, row);
            if (cell != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(cell.color), e.CellBounds);

                if (cell.borderStyle != null)
                {
                    SetBorder(e, cell.borderStyle.borderColor, cell.borderStyle.borderStyle, cell.borderStyle.borderHeight, cell.borderStyle.borderWidth);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Constants.DefaultBackGround), e.CellBounds);
            }
        }

        public override void Reset()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    SetCell(x, y, null);
                }
            }
        }

        public override void Render()
        {
            if (!isDirty) return;
            tableLayoutPanel.Refresh();
            isDirty = false;
        }

        public void PaintTetromino(int x, int y, Tetromino tetromino)
        {
            foreach (var position in tetromino.Positions)
            {
                SetCell(x + position.X, y + position.Y, new Cell(tetromino.Color, new Cell.BorderStyle(-1, -1, Constants.TetrominoBorderColor)));
            }
            _currentTetromino = new KeyValuePair<Point, Tetromino>(new Point(x, y), tetromino);
        }

        public void ClearTetromino(bool clearCells = true)
        {
            if (_currentTetromino != null)
            {
                if (clearCells)
                {
                    foreach (var position in _currentTetromino.Value.Value.Positions)
                    {
                        SetCell(_currentTetromino.Value.Key.X + position.X, _currentTetromino.Value.Key.Y + position.Y, null);
                    }
                }
                _currentTetromino = null;
            }
        }
    }
}
