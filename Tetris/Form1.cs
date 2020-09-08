using System.Windows.Forms;
using Tetris.Components;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Grid Grid;

        public Form1()
        {
            InitializeComponent();
            var playGround = new PlayGround(tableLayoutPanel1.ColumnCount - 2, tableLayoutPanel1.RowCount - 2);
            Grid = new Grid(tableLayoutPanel1, playGround);
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Grid.PaintCell(sender, e);
        }
    }
}
