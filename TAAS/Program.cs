// See https://aka.ms/new-console-template for more information
using TAAS;
using TAAS.Units;

// PLAY THE GAME HERE

Board board = new Board(seed: 42);
board.FillBoard(Difficulty.Grobelix); // SET THE DIFFICULTIES (Grobelix, Tinydefix, Megasterix)

while (!board.PlayTurn())
{
    board.PrintBoard();
    Thread.Sleep(300);
}
Console.WriteLine("FINAL GAME STATE :");
board.PrintBoard();

// TESTING (update the usings + readd the Board configs for some tests to test the functions)

// Tranferred from Board.cs 

// Console.WriteLine("=== Testing FindRightmostTargets ===");
//
// // Test 1: Empty Board
// Board emptyBoard = new Board(42);
// Idefix idEmpty = new Idefix(emptyBoard);
// var result = idEmpty.FindRightmostTargets();
// Console.WriteLine("Test 1 - Empty Board:");
// Console.WriteLine(result.Count == 0 ? "Pass" : "Fail");
//
// // Test 2: Single Roman in the rightmost column
// Board singleRomanBoard = new Board(42);
// singleRomanBoard.Tiles[2, Board.Width - 1].unit = new Roman(singleRomanBoard);
// Idefix idSingle = new Idefix(singleRomanBoard);
// result = idSingle.FindRightmostTargets();
// Console.WriteLine("Test 2 - Single Roman in rightmost column:");
// Console.WriteLine(result.Count == 1 && result[0] == (2, Board.Width - 1) ? "Pass" : "Fail");
//
// // Test 3: Multiple Romans in different columns
// Board multipleRomansBoard = new Board(42);
// multipleRomansBoard.Tiles[1, 5].unit = new Roman(multipleRomansBoard);
// multipleRomansBoard.Tiles[3, 7].unit = new Roman(multipleRomansBoard);
// multipleRomansBoard.Tiles[4, 7].unit = new Roman(multipleRomansBoard);
// Idefix idMultiple = new Idefix(multipleRomansBoard);
// result = idMultiple.FindRightmostTargets();
// Console.WriteLine("Test 3 - Multiple Romans:");
// Console.WriteLine(result.Count == 2 && result.Contains((3, 7)) && result.Contains((4, 7)) ? "Pass" : "Fail");
//
// // Test 4: Romans and Gauls mixed
// Board mixedUnitsBoard = new Board(42);
// mixedUnitsBoard.Tiles[0, 4].unit = new Asterix(null!);
// mixedUnitsBoard.Tiles[2, 4].unit = new Roman(mixedUnitsBoard);
// mixedUnitsBoard.Tiles[5, 4].unit = new Asterix(null!);
// mixedUnitsBoard.Tiles[1, 6].unit = new Roman(mixedUnitsBoard);
// Idefix idMixed = new Idefix(mixedUnitsBoard);
// result = idMixed.FindRightmostTargets();
// Console.WriteLine("Test 4 - Romans and Gauls mixed:");
// Console.WriteLine(result.Count == 1 && result[0] == (1, 6) ? "Pass" : "Fail");
//
// // Test 5: Full Board with mixed units
// Board fullBoard = new Board(42);
// for (int row = 0; row < Board.Height; row++)
// {
//     for (int col = 0; col < Board.Width; col++)
//     {
//         if ((row + col) % 2 == 0)
//             fullBoard.Tiles[row, col].unit = new Roman(fullBoard);
//         else
//             fullBoard.Tiles[row, col].unit = new Asterix(null!);
//     }
// }
// Idefix idFull = new Idefix(fullBoard);
// result = idFull.FindRightmostTargets();
// Console.WriteLine("Test 5 - Full Board with mixed units:");
// Console.WriteLine(result.Count == Board.Height / 2 && result.TrueForAll(r => r.Item2 == Board.Width - 1) ? "Pass" : "Fail");
//
// // Test 6: No Romans on the board
// Board noRomansBoard = new Board(42);
// for (int row = 0; row < Board.Height; row++)
//     noRomansBoard.Tiles[row, 5].unit = new Asterix(null!);
// Idefix idNoRomans = new Idefix(noRomansBoard);
// result = idNoRomans.FindRightmostTargets();
// Console.WriteLine("Test 6 - No Romans on the board:");
// Console.WriteLine(result.Count == 0 ? "Pass" : "Fail");
//
// Console.WriteLine("=== Testing PickClosestTarget ===");
//
// // Test 1: Single Target
// Console.WriteLine("Test 1 - Single Target:");
// var units1 = new List<(int, int)> { (2, 3) };
// var result1 = PickClosestTarget(units1, 0, 0);
// Console.WriteLine(result1 == (2, 3) ? "Pass" : "Fail");
//
// // Test 2: Multiple Targets, Closest at Origin
// Console.WriteLine("Test 2 - Closest at Origin:");
// var units2 = new List<(int, int)> { (5, 5), (0, 0), (10, 10) };
// var result2 = PickClosestTarget(units2, 1, 1);
// Console.WriteLine(result2 == (0, 0) ? "Pass" : "Fail");
//
// // Test 3: Multiple Targets, Closest in Middle
// Console.WriteLine("Test 3 - Closest in Middle:");
// var units3 = new List<(int, int)> { (0, 0), (5, 5), (10, 10) };
// var result3 = PickClosestTarget(units3, 4, 4);
// Console.WriteLine(result3 == (5, 5) ? "Pass" : "Fail");
//
// // Test 4: Tie in Distance
// Console.WriteLine("Test 4 - Tie in Distance:");
// var units4 = new List<(int, int)> { (3, 3), (3, -3) };
// var result4 = PickClosestTarget(units4, 0, 0);
// Console.WriteLine(result4 == (3, 3) || result4 == (3, -3) ? "Pass" : "Fail");
//
// // Test 5: Empty Units List
// Console.WriteLine("Test 5 - Empty Units List:");
// var units5 = new List<(int, int)>();
// var result5 = PickClosestTarget(units5, 0, 0);
// Console.WriteLine(result5 == (0, 0) ? "Pass" : "Fail");
//
// // Test 6: Large Coordinates
// Console.WriteLine("Test 6 - Large Coordinates:");
// var units6 = new List<(int, int)> { (1000, 1000), (-1000, -1000) };
// var result6 = PickClosestTarget(units6, 0, 0);
// Console.WriteLine(result6 == (1000, 1000) || result6 == (-1000, -1000) ? "Pass" : "Fail");
//
// // Test 7: Negative Coordinates
// Console.WriteLine("Test 7 - Negative Coordinates:");
// var units7 = new List<(int, int)> { (-3, -3), (-2, -2), (-10, -10) };
// var result7 = PickClosestTarget(units7, -5, -5);
// Console.WriteLine(result7 == (-3, -3) ? "Pass" : "Fail");
//
// // Test 8: Mixed Positive and Negative Coordinates
// Console.WriteLine("Test 8 - Mixed Positive and Negative Coordinates:");
// var units8 = new List<(int, int)> { (1, 1), (-1, -1), (10, 10) };
// var result8 = PickClosestTarget(units8, 0, 0);
// Console.WriteLine(result8 == (1, 1) || result8 == (-1, -1) ? "Pass" : "Fail");
//
//  Console.WriteLine("=== Testing IsValidTile ===");
//
// // Test 1: River Tile
// Console.WriteLine("Test 1 - River Tile:");
// var board1 = new Board(42);
// board1.Tiles[2, 3].tile = Tile.River;
// var unit1 = new Idefix(board1);
// Console.WriteLine(unit1.IsValidTile(2, 3) == false ? "Pass" : "Fail");
//
// // Test 2: Tile with Gaulish Unit
// Console.WriteLine("Test 2 - Tile with Gaulish Unit:");
// var board2 = new Board(42);
// board2.Tiles[4, 5].unit = new Asterix(null!);
// var unit2 = new Idefix(board2);
// Console.WriteLine(unit2.IsValidTile(4, 5) == false ? "Pass" : "Fail");
//
// // Test 3: Empty Valid Tile
// Console.WriteLine("Test 3 - Empty Valid Tile:");
// var board3 = new Board(42);
// var unit3 = new Idefix(board3);
// Console.WriteLine(unit3.IsValidTile(0, 0) == true ? "Pass" : "Fail");
//
// Console.WriteLine("\n=== Testing Update ===");
//
// // Test 4: No Targets
// Console.WriteLine("Test 4 - No Targets:");
// var board4 = new Board(42);
// var unit4 = new Idefix(board4);
// Console.WriteLine(unit4.Update(0, 0) == false ? "Pass" : "Fail");
//
// // Test 5: Target Reached
// Console.WriteLine("Test 5 - Target Reached (Caesar):");
// var board5 = new Board(42);
// board5.Tiles[1, 1].unit = new Caesar();
// var unit5 = new Idefix(board5);
// var result5 = unit5.Update(0, 0);
// Console.WriteLine(result5 == true && board5.Tiles[1, 1].unit == unit5 ? "Pass" : "Fail");
//
// // Test 6: Move Up
// Console.WriteLine("Test 6 - Move Up:");
// var board6 = new Board(42);
// board6.Tiles[2, 2].unit = new Roman(board6);
// var unit6 = new Idefix(board6);
// var result6 = unit6.Update(3, 2);
// Console.WriteLine(result6 == false && board6.Tiles[2, 2].unit == unit6 && board6.Tiles[3, 2].unit == null ? "Pass" : "Fail");
//
// // Test 7: Move Down
// Console.WriteLine("Test 7 - Move Down:");
// var board7 = new Board(42);
// board7.Tiles[2, 2].unit = new Roman(board7);
// var unit7 = new Idefix(board7);
// var result7 = unit7.Update(1, 2);
// Console.WriteLine(result7 == false && board7.Tiles[2, 2].unit == unit7 && board7.Tiles[1, 2].unit == null ? "Pass" : "Fail");
//
// // Test 8: Move Right (Single Step)
// Console.WriteLine("Test 8 - Move Right (Single Step):");
// var board8 = new Board(42);
// board8.Tiles[1, 3].unit = new Roman(board8);
// var unit8 = new Idefix(board8);
// var result8 = unit8.Update(1, 2);
// Console.WriteLine(result8 == false && board8.Tiles[1, 3].unit == unit8 && board8.Tiles[1, 2].unit == null ? "Pass" : "Fail");
//
// // Test 9: Move Left
// Console.WriteLine("Test 9 - Move Left:");
// var board9 = new Board(42);
// board9.Tiles[1, 0].unit = new Roman(board9);
// var unit9 = new Idefix(board9);
// var result9 = unit9.Update(1, 1);
// Console.WriteLine(result9 == false && board9.Tiles[1, 0].unit == unit9 && board9.Tiles[1, 1].unit == null ? "Pass" : "Fail");
//
// Console.WriteLine("=== Testing CheckSurroundings ===");
//
// // Test 1: Roman unit in the surroundings
// Console.WriteLine("Test 1 - Roman in surroundings:");
// var board1 = new Board(42);
// board1.Tiles[3, 3].unit = new Roman(board1);
// var unit1 = new Idefix(board1);
// var result1 = unit1.CheckSurroundings(4, 4);
// Console.WriteLine(result1 == (3, 3) ? "Pass" : "Fail");
//
// // Test 2: Caesar in the surroundings
// Console.WriteLine("Test 2 - Caesar in surroundings:");
// var board2 = new Board(42);
// board2.Tiles[2, 2].unit = new Caesar();
// var unit2 = new Idefix(board2);
// var result2 = unit2.CheckSurroundings(4, 4);
// Console.WriteLine(result2 == (2, 2) ? "Pass" : "Fail");
//
// // Test 3: RomanCamp in the surroundings
// Console.WriteLine("Test 3 - RomanCamp in surroundings:");
// var board3 = new Board(42);
// board3.Tiles[1, 1].unit = new RomanCamp();
// var unit3 = new Idefix(board3);
// var result3 = unit3.CheckSurroundings(2, 2);
// Console.WriteLine(result3 == (1, 1) ? "Pass" : "Fail");
//
// // Test 4: No unit in surroundings
// Console.WriteLine("Test 4 - No unit in surroundings:");
// var board4 = new Board(42);
// var unit4 = new Idefix(board4);
// var result4 = unit4.CheckSurroundings(4, 4);
// Console.WriteLine(result4 == (-1, -1) ? "Pass" : "Fail");
//
// Console.WriteLine("\n=== Testing LookForCaesarPosition ===");
//
// // Test 5: Caesar at specific position
// Console.WriteLine("Test 5 - Caesar at specific position:");
// var board5 = new Board(42);
// board5.Tiles[5, 5].unit = new Caesar();
// var result5 = Idefix.LookForCaesarPosition(board5);
// Console.WriteLine(result5 == (5, 5) ? "Pass" : "Fail");
//
// // Test 6: No Caesar on the board
// Console.WriteLine("Test 6 - No Caesar on the board:");
// var board6 = new Board(42);
// var result6 = Idefix.LookForCaesarPosition(board6);
// Console.WriteLine(result6 == (-1, -1) ? "Pass" : "Fail");
//
// // Test 7: Caesar at (0,0)
// Console.WriteLine("Test 7 - Caesar at (0,0):");
// var board7 = new Board(42);
// board7.Tiles[0, 0].unit = new Caesar();
// var result7 = Idefix.LookForCaesarPosition(board7);
// Console.WriteLine(result7 == (0, 0) ? "Pass" : "Fail");
//
// Console.WriteLine("=== Testing LookForCaesarPosition ===");
//
// // Test 1: Caesar at specific position
// Console.WriteLine("Test 1 - Caesar at (3, 4):");
// var board1 = new Board(42);
// board1.Tiles[3, 4].unit = new Caesar();
// var result1 = Obelix.LookForCaesarPosition(board1);
// Console.WriteLine(result1 == (3, 4) ? "Pass" : "Fail");
//
// // Test 2: No Caesar on the board
// Console.WriteLine("Test 2 - No Caesar on the board:");
// var board2 = new Board(42);
// var result2 = Obelix.LookForCaesarPosition(board2);
// Console.WriteLine(result2 == (-1, -1) ? "Pass" : "Fail");
//
// // Test 3: Caesar at (0, 0)
// Console.WriteLine("Test 3 - Caesar at (0, 0):");
// var board3 = new Board(42);
// board3.Tiles[0, 0].unit = new Caesar();
// var result3 = Obelix.LookForCaesarPosition(board3);
// Console.WriteLine(result3 == (0, 0) ? "Pass" : "Fail");
//
// Console.WriteLine("\n=== Testing MoveObelix ===");
//
// // Test 4: Move Obelix to (5, 5)
// Console.WriteLine("Test 4 - Move Obelix to (5, 5):");
// var board4 = new Board(42);
// var obelix = new Obelix(board4);
// obelix.MoveObelix(5, 5);
// var result4 = board4.Tiles[5, 5].unit is Obelix &&
//           !AnyObelixElsewhere(board4, 5, 5);
// Console.WriteLine(result4 ? "Pass" : "Fail");
//
// // Test 5: Move Obelix from (7, 7) to (2, 2)
// Console.WriteLine("Test 5 - Move Obelix from (7, 7) to (2, 2):");
// var board5 = new Board(42);
// board5.Tiles[7, 7].unit = new Obelix(board5);
// var obelix2 = (Obelix)board5.Tiles[7, 7].unit!;
// obelix2.MoveObelix(2, 2);
// var result5 = board5.Tiles[2, 2].unit is Obelix &&
//           !AnyObelixElsewhere(board5, 2, 2);
// Console.WriteLine(result5 ? "Pass" : "Fail");
//
// Console.WriteLine("=== Testing IsValidTile ===");
//
// // Test 1: Tile is empty and valid
// Console.WriteLine("Test 1 - Empty tile is valid:");
// var board1 = new Board(42);
// var obelix = new Obelix(board1);
// var result1 = obelix.IsValidTile(0, 0);
// Console.WriteLine(result1 ? "Pass" : "Fail");
//
// // Test 2: Tile has a Gaulish unit and is invalid
// Console.WriteLine("Test 2 - Tile with Gaulish unit is invalid:");
// board1.Tiles[0, 0].unit = new GaulishUnit();
// var result2 = obelix.IsValidTile(0, 0);
// Console.WriteLine(!result2 ? "Pass" : "Fail");
//
// // Test 3: Tile has a Roman unit and is valid
// Console.WriteLine("Test 3 - Tile with Roman unit is valid:");
// board1.Tiles[0, 0].unit = new Roman();
// var result3 = obelix.IsValidTile(0, 0);
// Console.WriteLine(result3 ? "Pass" : "Fail");
//
// Console.WriteLine("\n=== Testing Update ===");
//
// // Test 4: Move toward Caesar and win
// Console.WriteLine("Test 4 - Move toward Caesar and win:");
// var board2 = new Board(42);
// var obelix2 = new Obelix(board2);
// board2.Tiles[5, 5].unit = obelix2;
// board2.Tiles[5, 4].unit = new Caesar();
// var result4 = obelix2.Update(5, 5);
// Console.WriteLine(result4 && board2.Tiles[5, 4].unit is Obelix ? "Pass" : "Fail");
//
// // Test 5: Move toward a Roman and continue
// Console.WriteLine("Test 5 - Move toward Roman and continue:");
// var board3 = new Board(42);
// var obelix3 = new Obelix(board3);
// board3.Tiles[5, 5].unit = obelix3;
// board3.Tiles[5, 4].unit = new Roman();
// var result5 = obelix3.Update(5, 5);
// Console.WriteLine(!result5 && board3.Tiles[5, 4].unit is Obelix ? "Pass" : "Fail");
//
// // Test 6: No Caesar found, move left if possible
// Console.WriteLine("Test 6 - Move left if no Caesar found:");
// var board4 = new Board(42);
// var obelix4 = new Obelix(board4);
// board4.Tiles[5, 5].unit = obelix4;
// var result6 = obelix4.Update(5, 5);
// Console.WriteLine(!result6 && board4.Tiles[5, 4].unit is Obelix ? "Pass" : "Fail");
//
// // Test 7: Obelix moves vertically toward Caesar
// Console.WriteLine("Test 7 - Move vertically toward Caesar:");
// var board5 = new Board(42);
// var obelix5 = new Obelix(board5);
// board5.Tiles[5, 5].unit = obelix5;
// board5.Tiles[3, 5].unit = new Caesar();
// var result7 = obelix5.Update(5, 5);
// Console.WriteLine(!result7 && board5.Tiles[4, 5].unit is Obelix ? "Pass" : "Fail");
//
// Console.WriteLine("=== Testing RomanCamp.Update ===");
//
// // Test 1: Summoning a Roman on an empty, valid tile
// Console.WriteLine("Test 1 - Summoning a Roman on an empty tile:");
// var board1 = new Board(42);
// var romanCamp1 = new RomanCamp(board1) { turntosummon = 2 };
// board1.TurnCount = 5; // Turn 5 meets summon condition
// var result1 = romanCamp1.Update(3); // Attempt to summon at column 3
// var isRomanSummoned = IsRomanInColumn(board1, 4);
// Console.WriteLine(result1 == false && isRomanSummoned ? "Pass" : "Fail");
//
// // Test 2: No summoning on a turn that does not meet conditions
// Console.WriteLine("Test 2 - No summoning on non-summon turn:");
// var board2 = new Board(42);
// var romanCamp2 = new RomanCamp(board2) { turntosummon = 3 };
// board2.TurnCount = 4; // Does not meet summon condition
// var result2 = romanCamp2.Update(2);
// Console.WriteLine(result2 == false && !IsRomanInColumn(board2, 3) ? "Pass" : "Fail");
//
// // Test 3: Summoning fails when all tiles are invalid
// Console.WriteLine("Test 3 - Summoning fails on invalid tiles:");
// var board3 = new Board(42);
// var romanCamp3 = new RomanCamp(board3) { turntosummon = 1 };
// board3.TurnCount = 3;
// for (int i = 0; i < Board.Height; i++)
//     board3.Tiles[i, 3].tile = Tile.River; // All tiles are rivers
// var result3 = romanCamp3.Update(2);
// Console.WriteLine(result3 == false && !IsRomanInColumn(board3, 3) ? "Pass" : "Fail");
//
// // Test 4: Winning move is achieved
// Console.WriteLine("Test 4 - Winning move:");
// var board4 = new Board(42);
// var romanCamp4 = new RomanCamp(board4) { turntosummon = 1 };
// board4.TurnCount = 3;
// var result4 = romanCamp4.Update(Board.Width - 2); // Column just before the edge
// Console.WriteLine(result4 == true ? "Pass" : "Fail");
//
// Console.WriteLine("=== Testing RomanCamp.Update with Custom Board ===");
//
// // Test 1: Summoning a Roman on an empty, valid tile
// Console.WriteLine("Test 1 - Summoning a Roman on an empty tile:");
// var board1 = new Board(42);
// var romanCamp1 = new RomanCamp(board1) { turntosummon = 2 };
// board1.TurnCount = 5; // Turn 5 meets summon condition
// var result1 = romanCamp1.Update(3); // Attempt to summon at column 3
// var isRomanSummoned = IsRomanInColumn(board1, 4);
// Console.WriteLine(result1 == false && isRomanSummoned ? "Pass" : "Fail");
//
// // Test 2: No summoning on a turn that does not meet conditions
// Console.WriteLine("Test 2 - No summoning on non-summon turn:");
// var board2 = new Board(42);
// var romanCamp2 = new RomanCamp(board2) { turntosummon = 3 };
// board2.TurnCount = 4; // Does not meet summon condition
// var result2 = romanCamp2.Update(2);
// Console.WriteLine(result2 == false && !IsRomanInColumn(board2, 3) ? "Pass" : "Fail");
//
// // Test 3: Summoning fails when all tiles are invalid
// Console.WriteLine("Test 3 - Summoning fails on invalid tiles:");
// var board3 = new Board(42);
// var romanCamp3 = new RomanCamp(board3) { turntosummon = 1 };
// board3.TurnCount = 3;
// for (int i = 0; i < Board.Height; i++)
//     board3.Tiles[i, 3] = (Tile.River, null); // All tiles are rivers
// var result3 = romanCamp3.Update(2);
// Console.WriteLine(result3 == false && !IsRomanInColumn(board3, 3) ? "Pass" : "Fail");
//
// // Test 4: Winning move is achieved
// Console.WriteLine("Test 4 - Winning move:");
// var board4 = new Board(42);
// var romanCamp4 = new RomanCamp(board4) { turntosummon = 1 };
// board4.TurnCount = 3;
// var result4 = romanCamp4.Update(Board.Width - 2); // Column just before the edge
// Console.WriteLine(result4 == true ? "Pass" : "Fail");
//
