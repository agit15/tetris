using System.Drawing;
using System.Windows.Forms;
using Tetris.Config;

namespace Tetris.Components
{
    public class Grid
    {
        public readonly PlayGround PlayGround;

        protected readonly TableLayoutPanel tableLayoutPanel;

        protected bool isDirty = false;
        protected readonly Cell[] _cells;
        protected readonly int width;
        protected readonly int height;

        public Grid(TableLayoutPanel tableLayoutPanel, PlayGround playGround)
        {
            this.tableLayoutPanel = tableLayoutPanel;
            width = this.tableLayoutPanel.ColumnCount;
            height = this.tableLayoutPanel.RowCount;
            _cells = new Cell[width * height];
            PlayGround = playGround;

            // Reset to it's default state
            Reset();
        }

        public Grid(int width, int height, TableLayoutPanel tableLayoutPanel)
        {
            this.tableLayoutPanel = tableLayoutPanel;
            this.width = width;
            this.height = height;

            _cells = new Cell[width * height];
        }

        /// <summary>
        /// Draws the grid to the layout panel
        /// </summary>
        public virtual void Render()
        {
            // Also call playground
            PlayGround.Render();

            if (!isDirty) return;
            tableLayoutPanel.Refresh();
            isDirty = false;
        }

        public virtual void Reset()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        SetCell(x, y, new Cell(Constants.DefaultBorderColor, new Cell.BorderStyle(1,1, Constants.TetrominoBorderColor)));
                    }
                    else
                    {
                        SetCell(x, y, null);
                    }
                }
            }
        }

        public virtual void PaintCell(object sender, TableLayoutCellPaintEventArgs e)
        {
            var cell = GetCell(e.Column, e.Row);
            if (cell != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(cell.color), e.CellBounds);

                if(cell.borderStyle != null)
                {
                    SetBorder(e, cell.borderStyle.borderColor, cell.borderStyle.borderStyle, cell.borderStyle.borderHeight, cell.borderStyle.borderWidth);
                }
            }
            PlayGround.PaintCell(sender, e);
        }

        protected void SetBorder(TableLayoutCellPaintEventArgs e, Color color, ButtonBorderStyle borderStyle, int height, int width)
        {
            var rectangle = e.CellBounds;
            rectangle.Inflate(width, height);
            ControlPaint.DrawBorder(e.Graphics, rectangle, color, borderStyle);
        }

        public Cell GetCell(int x, int y)
        {
            if (!InBounds(x, y)) return null;
            return _cells[y * width + x];
        }

        public void SetCell(int x, int y, Cell cell)
        {
            if (!InBounds(x, y)) return;

            var prev = _cells[y * width + x];
            _cells[y * width + x] = cell;
            
            if (prev == null && cell != null)
            {
                isDirty = true;
            }
            else if (prev != null && cell == null)
            {
                isDirty = true;
            }
            else if (prev == null && cell == null)
            {
                return;
            }
            else if (!isDirty)
            {
                isDirty = prev.color.Equals(cell.color);
            }
        }

        protected bool InBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }
    }
}
