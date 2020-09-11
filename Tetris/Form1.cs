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
        private bool _isPaused = false;
        private Tetromino nextTetromino;
        private PreviewGrid _nextSlot;

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

            _nextSlot = new PreviewGrid(4, 2, NextGridBox);
            Grid = new Grid(GridBox, new PlayGround(GridBox.ColumnCount - 2, GridBox.RowCount - 2, GridBox));

            // Set default text
            LinesBox.Text = "0";
            ScoreBox.Text = "0";
            LevelBox.Text = "0";

            SetDoubleBuffered(GridBox);
            SetDoubleBuffered(NextGridBox);

            Focus();

            // Start game loop
            GameLoop.Start();
        }

        private void SpawnNextTetrimono()
        {
            var tetronimo = nextTetromino ?? tetrominos[_random.Next(0, tetrominos.Length)].Clone();
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

            nextTetromino = tetrominos[_random.Next(0, tetrominos.Length)].Clone();

            // Render nextTetromino in 
            _nextSlot.ClearTetromino();
            _nextSlot.PaintTetromino(0, 0, nextTetromino);
            _nextSlot.Render();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (_isPaused) return;

            if (!Grid.PlayGround.IsFalling)
            {
                // Set speed based on level
                int level = int.Parse(LevelBox.Text);
                GameLoop.Interval = 900 - (level * 35);

                if (GameLoop.Interval < 200)
                    GameLoop.Interval = 200;

                SpawnNextTetrimono();
            }
            else
            {
                // Move tetronimo downwards 1 line
                if (!Grid.PlayGround.MoveTetromino(Direction.Down))
                {
                    // If we have collided, we clear the tetronimo from the memory
                    // But we make sure not the clear the cells.
                    Grid.PlayGround.ClearTetromino(false);

                    // Check if we completed a line
                    Grid.PlayGround.CheckLineCompletion();

                    // Update text
                    LinesBox.Text = Grid.PlayGround.LinesScored.ToString();
                    ScoreBox.Text = Grid.PlayGround.Score.ToString();
                    LevelBox.Text = Grid.PlayGround.Level.ToString();
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isPaused)
            {
                e.Handled = true;
                return;
            }
            if (!Grid.PlayGround.IsFalling)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Q)
            {
                if (!Grid.PlayGround.MoveTetromino(Direction.Left)) return;
                Grid.Render();
            }
            else if (e.KeyCode == Keys.D)
            {
                if (!Grid.PlayGround.MoveTetromino(Direction.Right)) return;
                Grid.Render();
            }
            else if (e.KeyCode == Keys.S)
            {
                if (!Grid.PlayGround.MoveTetromino(Direction.Down))
                {
                    // If we have collided, we clear the tetronimo from the memory
                    // But we make sure not to clear the cells.
                    Grid.PlayGround.ClearTetromino(false);

                    // Check if we completed a line
                    Grid.PlayGround.CheckLineCompletion();

                    // Update text
                    LinesBox.Text = Grid.PlayGround.LinesScored.ToString();
                    ScoreBox.Text = Grid.PlayGround.Score.ToString();
                    LevelBox.Text = Grid.PlayGround.Level.ToString();

                    // Spawn the next
                    SpawnNextTetrimono();
                }
                Grid.Render();
            }
            else if (e.KeyCode == Keys.Z)
            {
                // Rotate tetromino
                var currentPos = Grid.PlayGround.TetronimoPosition;
                var orig = Grid.PlayGround.Tetronimo;
                var tetromino = Grid.PlayGround.Tetronimo.Clone();

                Grid.PlayGround.ClearTetromino(true);
                Grid.PlayGround.RotateTetromino90CounterClockwise(tetromino, currentPos);

                if (Grid.PlayGround.IsValidTetrominoPosition(currentPos.X, currentPos.Y, tetromino))
                {
                    Grid.PlayGround.PaintTetromino(currentPos, tetromino);
                    Grid.Render();
                }
                else
                {
                    // Repaint the original again
                    Grid.PlayGround.PaintTetromino(currentPos, orig);

                    // We don't need to render, because nothing changed
                }
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            _isPaused = !_isPaused;
            PauseButton.Text = _isPaused ? "UnPause" : "Pause";
        }

        private void Textbox_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void NextGridBox_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            _nextSlot.PaintCell(sender, e);
        }
    }
}
