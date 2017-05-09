using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WFTetris
{
    class Tetris
    {
        public enum Pieces { Empty, O, I, S, Z, L, J, T };

        Dictionary<Pieces, Brush> colors = new Dictionary<Pieces, Brush>();

        Random rnd = new Random();
        int lines;
        int columns;
        int cellSize = 30;
        int topX = 100;
        int topY = 100;
        Pieces[,] board;
        Stopwatch sw = new Stopwatch(); 

        Point fallingPieceLocation;
        Pieces fallingPiece;

        public Tetris() : this(22,10)
        {
        }


        public Tetris(int lines, int columns) {
            this.lines = lines;
            this.columns = columns;
            board = new Pieces[columns, lines];

            clearBoard();
            initColors();
            addFallingPiece();
        }

        private void clearBoard() {
            // Effacer le Tetris
            for (int line = 0; line < lines; line++)
            {
                for (int col = 0; col < columns; col++)
                {
                    board[col, line] = Pieces.Empty;
                }
            }
        }

        public void initColors() {
            // Initialiser le dictionnaire des couleurs
            colors.Add(Pieces.O, Brushes.Blue);
            colors.Add(Pieces.I, Brushes.Yellow);
            colors.Add(Pieces.S, Brushes.Red);
            colors.Add(Pieces.Z, Brushes.Green);
            colors.Add(Pieces.L, Brushes.Orange);
            colors.Add(Pieces.J, Brushes.Pink);
            colors.Add(Pieces.T, Brushes.Purple);
            colors.Add(Pieces.Empty, Brushes.LightGray);
        }

        private void addFallingPiece() {
            fallingPiece = Pieces.O;
            fallingPieceLocation = new Point(4, 0);
            setPiece();
            sw.Start();
        }

        private void drawFallingPiece() {
            //game.clearPiece(Tetris.Pieces.O, where);
            //if (where.Y < 22)
            //    where.Y += 1;
            //game.setPiece(Tetris.Pieces.O, where);

        }

        public void setPiece()
        {
            switch (fallingPiece) {
                case Pieces.O:
                    board[fallingPieceLocation.X, fallingPieceLocation.Y] = Pieces.O;
                    board[fallingPieceLocation.X+1, fallingPieceLocation.Y] = Pieces.O;
                    board[fallingPieceLocation.X, fallingPieceLocation.Y+1] = Pieces.O;
                    board[fallingPieceLocation.X+1, fallingPieceLocation.Y+1] = Pieces.O;
                    break;

            }
        }

        public void clearPiece()
        {
            switch (fallingPiece)
            {
                case Pieces.O:
                    board[fallingPieceLocation.X, fallingPieceLocation.Y] = Pieces.Empty;
                    board[fallingPieceLocation.X + 1, fallingPieceLocation.Y] = Pieces.Empty;
                    board[fallingPieceLocation.X, fallingPieceLocation.Y + 1] = Pieces.Empty;
                    board[fallingPieceLocation.X + 1, fallingPieceLocation.Y + 1] = Pieces.Empty;
                    break;

            }
        }
        // public void newPiece()

        public void Paint(object sender, PaintEventArgs e) {

            if (sw.ElapsedMilliseconds >= 500)
            {
                clearPiece();
                fallingPieceLocation.Y += 1;
                sw.Restart();
                setPiece();

            }

            for (int line = 0; line <= lines; line++)
                for (int column = 0; column <= columns; column++) {
                    // Draw Lines
                    e.Graphics.DrawLine(Pens.Black, topX + 0, topY + line * cellSize,
                                                    topX + cellSize * columns, topY + line * cellSize);
                    // Draw Columns
                    e.Graphics.DrawLine(Pens.Black, topX + column * cellSize, topY + 0,
                                                    topX + column * cellSize, topY + lines * cellSize);
                    if ((line < lines) && (column < columns))
                        e.Graphics.FillRectangle(colors[board[column,line]], 
                                                 topX + column * cellSize + 2, topY + line * cellSize + 2,
                                                 cellSize - 3, cellSize - 3);

                }
        }
    }
}
