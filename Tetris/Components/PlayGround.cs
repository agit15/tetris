using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class PlayGround : Grid
    {
        public PlayGround(int width, int height, TableLayoutPanel panel) : base(width, height, panel)
        { }

        public override void PaintCell(object sender, TableLayoutCellPaintEventArgs e)
        {
            int col = e.Column - 1;
            int row = e.Row - 1;

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
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), e.CellBounds);
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

        public void PaintTetromino(int x, int y, Tetromino tetromino)
        {
            foreach (var cell in tetromino.Cells)
            {
                SetCell(x + cell.Position.X, y + cell.Position.Y, new Cell(tetromino.Color, new Cell.BorderStyle(-1, -1, Color.Black)));
            }
        }
    }
}
