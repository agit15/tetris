using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class Grid
    {
        private TableLayoutPanel tableLayoutPanel;

        public Grid(TableLayoutPanel tableLayoutPanel)
        {
            this.tableLayoutPanel = tableLayoutPanel;
        }
    }
}
