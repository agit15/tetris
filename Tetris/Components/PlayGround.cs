using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tetris.Config;

namespace Tetris.Components
{
    public class PlayGround : Grid
    {
        private KeyValuePair<Point, Tetromino>? _currentTetromino;

        public bool IsFalling { get { return _currentTetromino != null; } }

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
                SetCell(x + position.X, y + position.Y, new Cell(new Point(x + position.X, y + position.Y), tetromino.Color, new Cell.BorderStyle(-1, -1, Constants.TetrominoBorderColor)));
                tetromino.Cells.Add(GetCell(x + position.X, y + position.Y));
            }
            _currentTetromino = new KeyValuePair<Point, Tetromino>(new Point(x, y), tetromino);
        }

        public void PaintTetromino(Point position, Tetromino tetromino)
        {
            PaintTetromino(position.X, position.Y, tetromino);
        }

        public bool MoveTetromino(Direction direction)
        {
            if (_currentTetromino != null)
            {
                Point position;
                switch (direction)
                {
                    case Direction.Left:
                        position = new Point(_currentTetromino.Value.Key.X - 1, _currentTetromino.Value.Key.Y);
                        break;
                    case Direction.Right:
                        position = new Point(_currentTetromino.Value.Key.X + 1, _currentTetromino.Value.Key.Y);
                        break;
                    case Direction.Down:
                        position = new Point(_currentTetromino.Value.Key.X, _currentTetromino.Value.Key.Y + 1);
                        break;
                    default:
                        return false;
                }

                if (IsValidTetrominoPosition(position.X, position.Y, _currentTetromino.Value.Value))
                {
                    var tetromino = _currentTetromino.Value.Value;

                    // Clear previous position
                    ClearTetromino();
                    // Re-paint the new position
                    PaintTetromino(position, tetromino);

                    return true;
                }
                return false;
            }
            return false;
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
                    _currentTetromino.Value.Value.Cells.Clear();
                }
                _currentTetromino = null;
            }
        }

        public bool IsValidTetrominoPosition(int x, int y, Tetromino tetromino)
        {
            if (!InBounds(x, y)) return false;
            var targetCell = GetCell(x, y);
            if (targetCell != null && !tetromino.Cells.Any(a => a.Equals(targetCell))) return false;
            foreach (var position in tetromino.Positions)
            {
                if (!InBounds(x + position.X, y + position.Y)) return false;
                var cell = GetCell(x + position.X, y + position.Y);
                if (cell != null && !tetromino.Cells.Any(a => a.Equals(cell))) return false;
            }
            return true;
        }
    }
}
