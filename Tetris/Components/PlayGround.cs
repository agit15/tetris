using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class PlayGround : Grid
    {
        public PlayGround(int width, int height) : base(width, height)
        { }

        public override void Draw()
        {
            // Draws only on the play ground
        }

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
    }
}
