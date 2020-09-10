using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Config;

namespace Tetris.Components
{
    public class PreviewGrid : PlayGround
    {
        public PreviewGrid(int width, int height, TableLayoutPanel panel) : base(width, height, panel)
        { }

        public override void PaintCell(object sender, TableLayoutCellPaintEventArgs e)
        {
            var cell = GetCell(e.Column, e.Row);
            if (cell != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(cell.color), e.CellBounds);

                if (cell.borderStyle != null)
                {
                    SetBorder(e, cell.borderStyle.borderColor, cell.borderStyle.borderStyle, cell.borderStyle.borderHeight, cell.borderStyle.borderWidth);
                }
            }
        }

        public override void PaintTetromino(int x, int y, Tetromino tetromino)
        {
            tetromino.Cells.Clear();
            foreach (var position in tetromino.Positions)
            {
                SetCell(x + position.X, y + position.Y, new Cell(new Point(x + position.X, y + position.Y), tetromino.Color, new Cell.BorderStyle(-1, -1, Constants.TetrominoBorderColor)));
            }
            _currentTetromino = new KeyValuePair<Point, Tetromino>(new Point(x, y), tetromino);
        }

        public override void ClearTetromino(bool clearCells = true)
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
