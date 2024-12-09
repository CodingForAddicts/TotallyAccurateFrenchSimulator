// See https://aka.ms/new-console-template for more information
using TAAS;
using TAAS.Units;

Board board = new Board(seed: 42);
board.FillBoard(Difficulty.Grobelix);
//board.Tiles[8, 0].unit = new Caesar();

//board.Tiles[4, 10].unit = new Idefix(board);
//board.Tiles[6, 7].unit = new Idefix(board);

while (!board.PlayTurn())
{
    board.PrintBoard();
    Thread.Sleep(300);
}
Console.WriteLine("FINAL GAME STATE :");
board.PrintBoard();

