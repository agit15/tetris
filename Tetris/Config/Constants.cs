using System.Collections.Generic;
using System.Drawing;

namespace Tetris.Config
{
    public static class Constants
    {
        public static Color DefaultBorderColor = Color.Gray;
        public static Color TetrominoBorderColor = Color.Black;
        public static Color DefaultBackGround = Color.Black;
        public static Point TetrominoSpawnPosition = new Point(3, 0);

        public static Dictionary<Color, int> PointsPerColor = new Dictionary<Color, int>
        {
            { Color.Cyan, 6 },
            { Color.Blue, 8 },
            { Color.Orange, 7 },
            { Color.Yellow, 6 },
            { Color.Red, 5 },
            { Color.Green, 8 },
            { Color.Magenta, 9 }
        };

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
                    "1000",
                    "1110"
                }
            },
            { Color.Orange, new string[]
                {
                    "0010",
                    "1110"
                }
            },
            { Color.Yellow, new string[]
                {
                    "1100",
                    "1100"
                }
            },
            { Color.Red, new string[]
                {
                    "1100",
                    "0110"
                }
            },
            { Color.Green, new string[]
                {
                    "0110",
                    "1100"
                }
            },
            { Color.Magenta, new string[]
                {
                    "0100",
                    "1110"
                }
            }
        };
    }
}
