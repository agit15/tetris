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

        private T[,] RotateMatrixCounterClockwise<T>(T[,] oldMatrix)
        {
            T[,] newMatrix = new T[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        public void RotateTetromino90CounterClockwise(Tetromino tetromino)
        {
            var arr = ConvertToMultiDimensionalArray(tetromino.Positions);
            var cArr = RotateMatrixCounterClockwise(arr);
            var normalArr = ConvertToNormalArray(cArr);
            tetromino.Positions = normalArr;
            tetromino.Normalize();
        }

        private void ShiftAllValidCellsDown(int openLine)
        {
            for (int y=openLine; y > 0; y--)
            {
                for (int x=0; x < width; x++)
                {
                    SetCell(x, y, GetCell(x, y - 1));
                    SetCell(x, y - 1, null);
                }
            }
        }

        public void CheckLineCompletion()
        {
            if (!ReplaceFullLines()) return;

            int? openLine = GetNextOpenLine();
            while (openLine != null)
            {
                ShiftAllValidCellsDown(openLine.Value);
                openLine = GetNextOpenLine();
            }
        }

        private bool ReplaceFullLines()
        {
            bool updated = false;
            for (int y=0; y < height; y++)
            {
                bool lineComplete = true;
                for (int x=0; x < width; x++)
                {
                    if (GetCell(x, y) == null)
                    {
                        lineComplete = false;
                        break;
                    }
                }
                if (lineComplete)
                {
                    for (int x = 0; x < width; x++)
                    {
                        SetCell(x, y, null);
                    }
                    updated = true;
                }
            }
            return updated;
        }

        private int? GetNextOpenLine()
        {
            for (int y=height-1; y>0; y--)
            {
                bool allEmpty = true;
                for (int x=0; x < width; x++)
                {
                    if (GetCell(x, y) != null)
                    {
                        allEmpty = false;
                        break;
                    }
                }
                if (!allEmpty) continue;

                // Check if there are valid lines above this one
                var validLinesAbove = new List<int>();
                for (int y2 = y; y2 > 0; y2--)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (GetCell(x, y2) != null)
                        {
                            validLinesAbove.Add(y2);
                            break;
                        }
                    }
                    if (validLinesAbove.Count > 0) break;
                }
                if (validLinesAbove.Count > 0)
                    return y;
            }
            return null;
        }

        public Point TetronimoPosition { get { return _currentTetromino.Value.Key; } }
        public Tetromino Tetronimo { get { return _currentTetromino.Value.Value; } }

        private bool[,] ConvertToMultiDimensionalArray(Point[] positions)
        {
            var newPositions = new bool[positions.Max(a => a.X)+1, positions.Max(a => a.Y)+1];
            var arr = positions.Select(a => new Point?(a));
            for (int x = 0; x < newPositions.GetLength(0); x++)
            {
                for (int y = 0; y < newPositions.GetLength(1); y++)
                {
                    newPositions[x, y] = arr.FirstOrDefault(a => a.Value.X == x && a.Value.Y == y) == null ? false : true;
                }
            }
            return newPositions;
        }

        private Point[] ConvertToNormalArray(bool[,] positions)
        {
            var newPositions = new List<Point>();
            for (int x = 0; x < positions.GetLength(0); x++)
            {
                for (int y = 0; y < positions.GetLength(1); y++)
                {
                    // Change actual position value
                    var pos = positions[x, y];
                    if (pos)
                    {
                        // Add to list
                        newPositions.Add(new Point(x, y));
                    }
                }
            }
            return newPositions.ToArray();
        }

        public void PaintTetromino(int x, int y, Tetromino tetromino)
        {
            tetromino.Cells.Clear();
            foreach (var position in tetromino.Positions)
            {
                SetCell(x + position.X, y + position.Y, new Cell(new Point(x + position.X, y + position.Y), tetromino.Color, new Cell.BorderStyle(-1, -1, Constants.TetrominoBorderColor)));
                var cell = GetCell(x + position.X, y + position.Y);
                cell.Occupier = tetromino;
                tetromino.Cells.Add(cell);
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
            if (targetCell != null && !tetromino.Cells.Any(a => a.Equals(targetCell) && a.Occupier.Equals(targetCell.Occupier)))
            {
                return false;
            }
            foreach (var position in tetromino.Positions)
            {
                if (!InBounds(x + position.X, y + position.Y)) return false;
                var cell = GetCell(x + position.X, y + position.Y);
                if (cell != null && !tetromino.Cells.Any(a => a.Equals(cell) && a.Occupier.Equals(cell.Occupier)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
