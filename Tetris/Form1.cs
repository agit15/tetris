using System;
using System.Windows.Forms;
using Tetris.Components;
using Tetris.Config;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Grid Grid;
        private Random _random;
        private Tetromino[] tetrominos;

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
            _random = new Random();
            tetrominos = Tetromino.ListAll();

            Grid = new Grid(GridBox, new PlayGround(GridBox.ColumnCount - 2, GridBox.RowCount - 2, GridBox));

            SetDoubleBuffered(GridBox);
            SetDoubleBuffered(NextGridBox);

            // Start game loop
            GameLoop.Start();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (!Grid.PlayGround.IsAlive)
            {
                var tetronimo = tetrominos[_random.Next(0, tetrominos.Length)];
                if (!Grid.PlayGround.IsValidTetrominoPosition(Constants.TetrominoSpawnPosition.X, Constants.TetrominoSpawnPosition.Y, tetronimo))
                {
                    // Game over?
                    GameLoop.Stop();
                    return;
                }
                else
                {
                    // Paint a random tetromino at spawn location
                    Grid.PlayGround.PaintTetromino(Constants.TetrominoSpawnPosition, tetronimo);
                }
            }
            else
            {
                if (!Grid.PlayGround.MoveTetromino(Direction.Down))
                {
                    Grid.PlayGround.ClearTetromino(false);
                }
            }

            Grid.Render();
        }

        #region Double buffer
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }
        #endregion
        #region Flickering fix
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion
    }
}
