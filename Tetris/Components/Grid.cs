using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class Grid
    {
        private readonly PlayGround _playGround;
        private readonly TableLayoutPanel tableLayoutPanel;
        protected readonly Color[] _cells;
        protected readonly int width;
        protected readonly int height;

        public Grid(TableLayoutPanel tableLayoutPanel, PlayGround playGround)
        {
            this.tableLayoutPanel = tableLayoutPanel;

            _playGround = playGround;

            width = this.tableLayoutPanel.ColumnCount;
            height = this.tableLayoutPanel.RowCount;

            _cells = new Color[width * height];

            // Draw entire board
            Draw();

            // Draw playground
            _playGround.Draw();

            tableLayoutPanel.Invalidate();
        }

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            _cells = new Color[width * height];
        }

        public virtual void Draw()
        {
            CreateBorder();
        }

        public void CreateBorder()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (y == 0 || x == 0 || y == height -1 || x == width - 1)
                    {
                        SetCell(x, y, Color.Gray);
                    } 
                    else
                    {
                        SetCell(x, y, Color.Transparent);
                    }
                }
            }
        }

        public virtual void PaintCell(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(GetCell(e.Column, e.Row)), e.CellBounds);
            _playGround.PaintCell(sender, e);
        }

        public Color GetCell(int x, int y)
        {
            return _cells[y * width + x];
        }

        public void SetCell(int x, int y, Color color)
        {
            _cells[y * width + x] = color;
        }
    }
}
