using System.Windows.Forms;
using Tetris.Components;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Grid Grid;
        public PlayGround PlayGround;

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Grid.PaintCell(sender, e);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            PlayGround = new PlayGround(tableLayoutPanel1.ColumnCount - 2, tableLayoutPanel1.RowCount - 2);
            Grid = new Grid(tableLayoutPanel1, PlayGround);
            Grid.Draw();
            Grid.Render();
        }
    }
}
