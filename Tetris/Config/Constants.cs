using System.Collections.Generic;
using System.Drawing;

namespace Tetris.Config
{
    public static class Constants
    {
        public static Color DefaultBorderColor = Color.DarkSlateGray;
        public static Color TetrominoBorderColor = Color.Black;
        public static Color DefaultBackGround = Color.Black;

        public static Dictionary<Color, string[]> TetrominoPatterns = new Dictionary<Color, string[]>
        {
            { Color.Cyan, new string[]
                {
                    "0000",
                    "1111"
                }
            },
            { Color.Blue, new string[]
                {
                    "0100",
                    "0111"
                }
            },
            { Color.Orange, new string[]
                {
                    "0001",
                    "0111"
                }
            },
            { Color.Yellow, new string[]
                {
                    "0110",
                    "0110"
                }
            },
            { Color.Red, new string[]
                {
                    "0110",
                    "0011"
                }
            },
            { Color.Green, new string[]
                {
                    "0011",
                    "0110"
                }
            },
            { Color.Magenta, new string[]
                {
                    "0010",
                    "0111"
                }
            }
        };
    }
}
