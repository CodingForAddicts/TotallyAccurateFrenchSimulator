using TAAS.Units;

namespace TAAS;

public class Board
{
   public const int Height = 9;
   public const int Width = 20;

   public MyRandom? Random { get; private set; }

   public int TurnCount { get; set; }

   public Stack<Move?> Moves { get; private set; }
   public (Tile tile, object? unit)[,] Tiles { get; private set; }

   public Board(int seed)
   {
      Tiles = new (Tile tile, object? unit)[Height, Width];
      Random  = new MyRandom(seed);
      TurnCount = 0;
      Moves = new Stack<Move?>();
      for (int i = 0; i < Height; i++)
      {
         for (int j = 0; j < Width; j++)
         {
            switch (Random.Next(2))
            {
               case 0:
                  Tiles[i, j] = (Tile.Forest, null);
                  break;
               case 1:
                  Tiles[i, j] = (Tile.Field, null);
                  break;
            }
         }
      }
   }
   
   public void PrintBoard()
   {
      Console.WriteLine( $"Current Turn  {TurnCount} : { (TurnCount % 2 == 0 ? "Gauls" : "Romans" )}");
   
      Console.Write("  ");
      for (int i = 0; i < Width; i++)
         Console.Write($"{i, 2}");
      Console.WriteLine();
      for (int h = 0; h < Height; h++)
      {
         Console.ResetColor();
         Console.Write($"{h} ");
         for (int w = 0; w < Width; w++)
         {
            var (tile, unit) = Tiles[h, w];
            switch(unit)
            {
               case Idefix :
                  Console.ForegroundColor = ConsoleColor.Gray;
                  Console.Write("ID");
                  break;
               case Roman :
                  Console.ForegroundColor = ConsoleColor.DarkGray;
                  Console.Write("RR");
                  break;
               case RomanCamp :
                  Console.ForegroundColor = ConsoleColor.DarkCyan;
                  Console.Write("RC");
                  break;
               case Caesar :
                  Console.ForegroundColor = ConsoleColor.DarkYellow;
                  Console.Write("CC");
                  break;
               case Obelix :
                  Console.ForegroundColor = ConsoleColor.Blue;
                  Console.Write("OB");
                  break;
               case Asterix :
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.Write("AS");
                  break;
               case null :
                  switch(tile)
                  {
                     case Tile.Field :
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                     case Tile.Forest :
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                     case Tile.River :
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                  }
                  Console.Write("\u2588\u2588");
                  break;
            }
         }
         Console.WriteLine();
      }
      Console.ResetColor();
   }
   
   
   public bool PlayTurn()
   {
      bool gameWon = false;
    
      // Create a list to track units that have already moved in this turn
      var movedUnits = new List<object>();

      for (int h = 0; h < Board.Height; h++)
      {
         for (int w = 0; w < Board.Width; w++)
         {
            var (tile, unit) = Tiles[h, w];
            
            if (unit == null || 
                (TurnCount % 2 == 0 && !UnitUtils.IsGaulish(unit)) || 
                (TurnCount % 2 == 1 && UnitUtils.IsGaulish(unit)) ||
                movedUnits.Contains(unit))  // Skip if the unit has already moved this turn
            {
               continue;
            }
            
            bool reachedObjective = unit switch
            {
               Roman roman => roman.Update(h, w),
               Obelix obelix => obelix.Update(h, w),
               Idefix idefix => idefix.Update(h, w),
               Caesar caesar => caesar.Update(),
               RomanCamp camp => camp.Update(w),
               _ => false
            };
            
            if (reachedObjective)
            {
               return true;
            }

            Console.WriteLine(unit);
            // Mark the unit as moved for this turn
            movedUnits.Add(unit);
         }
      }

      TurnCount++;

      return gameWon;
   }

   public void FillBoard(Difficulty d)
   {
      switch (d)
      {
         case Difficulty.Tinydefix:
            Tiles[4, 0].unit = new Caesar();      
            Tiles[4, 2].unit = new RomanCamp(this);   
            Tiles[4, 19].unit = new Idefix(this);     
            Tiles[4, 10].tile = Tile.River;
            Tiles[6,10].tile = Tile.River;
            Tiles[2,10].tile = Tile.River;
            break;

         case Difficulty.Grobelix:
            Tiles[4, 0].unit = new Caesar();
            Tiles[4, 2].unit = new RomanCamp(this);
            Tiles[2, 2].unit = new Roman(this);
            Tiles[3, 3].unit = new Roman(this);
            Tiles[4, 4].unit = new Roman(this);
            Tiles[5, 3].unit = new Roman(this);
            Tiles[6, 2].unit = new Roman(this);
            Tiles[3, 19].unit = new Obelix(this); 
            Tiles[4, 19].unit = new Idefix(this);
            Tiles[1, 9].tile = Tile.River;
            Tiles[1, 10].tile = Tile.River;
            Tiles[1, 11].tile = Tile.River;
            Tiles[2,9].tile = Tile.River;
            Tiles[2,10].tile = Tile.River;
            Tiles[2,11].tile = Tile.River;
            Tiles[6,9].tile = Tile.River;
            Tiles[6,10].tile = Tile.River;
            Tiles[6,11].tile = Tile.River;
            Tiles[7,9].tile = Tile.River;
            Tiles[7,10].tile = Tile.River;
            Tiles[7,11].tile = Tile.River;
            break;

         case Difficulty.Megasterix:
            Tiles[3, 0].unit = new Roman(this);
            Tiles[4, 0].unit = new Roman(this);
            Tiles[5, 0].unit = new Roman(this);
            
            Tiles[2, 1].unit = new Roman(this);
            Tiles[4, 1].unit = new Caesar();
            Tiles[6, 1].unit = new Roman(this);
            
            Tiles[2, 2].unit = new Roman(this);
            Tiles[3, 2].unit = new RomanCamp(this);
            Tiles[5, 2].unit = new RomanCamp(this);
            Tiles[6, 2].unit = new Roman(this);
            
            Tiles[3, 3].unit = new Roman(this);
            Tiles[4, 3].unit = new Roman(this);
            Tiles[5, 3].unit = new Roman(this);
            
            Tiles[3, 19].unit = new Obelix(this);
            Tiles[4, 19].unit = new Idefix(this);
            Tiles[5, 19].unit = new Asterix(this);
            
            break;
      }
   }
   
   public void UndoTurn()
   {
      if (Moves.Count != 0)
      {
         // If there is something on the stack, it has to be a null
         // since this method has to be called after Board.PlayTurn()
         TurnCount -= 1;
         Moves.Pop(); // Remove the null (indicating the end of the turn)
      }

      while (Moves.Count != 0 && Moves.Peek() != null)
      {
         // Undo every move until you reach the end of the turn or start of game
         Moves.Pop()!.UndoMove(this); // Undo the move
      }
   }
}

