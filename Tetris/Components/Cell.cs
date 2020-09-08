using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Components
{
    public class Cell
    {
        public Color color;
        public BorderStyle borderStyle;

        public class BorderStyle
        {
            public int borderWidth;
            public int borderHeight;
            public Color borderColor;
            public ButtonBorderStyle borderStyle;

            public BorderStyle(int width, int height, Color color, ButtonBorderStyle style = ButtonBorderStyle.Solid)
            {
                borderWidth = width;
                borderHeight = height;
                borderColor = color;
                borderStyle = style;
            }
        }

        public Cell(Color color) 
        {
            this.color = color;
        }
    }
}
