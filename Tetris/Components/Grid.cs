using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class Grid
    {
        public readonly PlayGround PlayGround;

        private readonly TableLayoutPanel tableLayoutPanel;

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

            // Setup initial grid data
            InitializeGrid();
        }

        public Grid(int width, int height, TableLayoutPanel tableLayoutPanel)
        {
            this.tableLayoutPanel = tableLayoutPanel;
            this.width = width;
            this.height = height;

            _cells = new Cell[width * height];
        }

        private void InitializeGrid()
        {
            // Create border area
            CreateBorder();
        }

        /// <summary>
        /// Draws the grid to the layout panel
        /// </summary>
        public void Render()
        {
            if (!isDirty) return;
            tableLayoutPanel.Refresh();
            isDirty = false;
        }

        protected void CreateBorder()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        SetCell(x, y, new Cell(Color.Gray, new Cell.BorderStyle(-1, -1, Color.Black)));
                    } 
                }
            }
        }

        public virtual void Reset()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        SetCell(x, y, new Cell(Color.Gray));
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
            return _cells[y * width + x];
        }

        public void SetCell(int x, int y, Cell cell)
        {
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
            }
            else if (!isDirty)
            {
                isDirty = prev.color.Equals(cell.color);
            }
        }
    }
}
