using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class PlayGround : Grid
    {
        public PlayGround(int width, int height) : base(width, height)
        {

        }

        public override void Draw()
        {
            SetBackground();
        }

        public void SetBackground()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    SetCell(x, y, Color.Black);
                }
            }
        }

        public override void PaintCell(object sender, TableLayoutCellPaintEventArgs e)
        {
            int col = e.Column - 1;
            int row = e.Row - 1;

            if (e.Column == 0 || e.Row == 0) return;
            if (e.Row >= 21 || e.Column >= 11) return;
            e.Graphics.FillRectangle(new SolidBrush(GetCell(col, row)), e.CellBounds);
        }
    }
}
