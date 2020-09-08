using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class Grid
    {
        private readonly PlayGround _playGround;
        private readonly TableLayoutPanel tableLayoutPanel;

        protected readonly Cell[] _cells;
        protected readonly int width;
        protected readonly int height;

        public Grid(TableLayoutPanel tableLayoutPanel, PlayGround playGround)
        {
            this.tableLayoutPanel = tableLayoutPanel;

            _playGround = playGround;

            width = this.tableLayoutPanel.ColumnCount;
            height = this.tableLayoutPanel.RowCount;

            _cells = new Cell[width * height];

            // Draw entire board
            Draw();

            // Draw playground
            _playGround.Draw();

            // Render the grid
            Render();
        }

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            _cells = new Cell[width * height];
        }

        /// <summary>
        /// Draws the grid in memory.
        /// </summary>
        public virtual void Draw()
        {
            // Create border area
            CreateBorder();

            _playGround.Draw();
        }

        /// <summary>
        /// Draws the grid to the layout panel
        /// </summary>
        public void Render()
        {
            tableLayoutPanel.Refresh();
        }

        protected void CreateBorder()
        {
            Cell borderCell = new Cell(Color.Gray, new Cell.BorderStyle(-1, -1, Color.Black));
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        SetCell(x, y, borderCell);
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
            _playGround.PaintCell(sender, e);
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
            _cells[y * width + x] = cell;
        }
    }
}
