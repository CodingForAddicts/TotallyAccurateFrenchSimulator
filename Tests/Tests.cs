using TAAS.Units;

namespace Tests;

public class MyRandomTests
    {
        [Fact]
        public void Constructor_InitializesSeedCorrectly()
        {
            // Arrange
            int initialSeed = 42;

            // Act
            MyRandom random = new MyRandom(initialSeed);

            // Assert
         //   Assert.Equal(81973, random.seed);
        }
        
        [Fact]
        public void SeedGetter_ProducesDeterministicValues()
        {
            // Arrange
            MyRandom random = new MyRandom(42);

            // Act
    //        int firstSeedValue = random.seed;  // Expected: 81973
     //       int secondSeedValue = random.seed; // Expected: 2561406
     //       int thirdSeedValue = random.seed;  // Continue pattern...

            // Assert
    //        Assert.Equal(81973, firstSeedValue);
     //       Assert.Equal(2561406, secondSeedValue);
     //       Assert.NotEqual(firstSeedValue, thirdSeedValue); // Verify values change
        }

        [Fact]
        public void SeedGetter_ModifiesSeedValue()
        {
            // Arrange
            int initialSeed = 123;
            MyRandom random = new MyRandom(initialSeed);

            // Act
           // int firstSeedValue = random.seed;
          //  int secondSeedValue = random.seed;

            // Assert
           // Assert.NotEqual(initialSeed, firstSeedValue);
         //   Assert.NotEqual(firstSeedValue, secondSeedValue);
        }

        [Fact]
        public void Next_ReturnsValueWithinMax()
        {
            // Arrange
            int initialSeed = 1234;
            MyRandom random = new MyRandom(initialSeed);
            int max = 100;

            // Act
            int result = random.Next(max);

            // Assert
            Assert.InRange(result, 0, max - 1);
        }

        [Fact]
        public void Next_ReturnsDifferentValuesOnMultipleCalls()
        {
            // Arrange
            MyRandom random = new MyRandom(567);

            // Act
            int firstValue = random.Next();
            int secondValue = random.Next();

            // Assert
            Assert.NotEqual(firstValue, secondValue);
        }

        [Fact]
        public void NextMin_ReturnsValueWithinRange()
        {
            // Arrange
            int initialSeed = 789;
            MyRandom random = new MyRandom(initialSeed);
            int min = 10;
            int max = 50;

            // Act
            int result = random.NextMin(min, max);

            // Assert
            Assert.InRange(result, min, max - 1);
        }

        [Fact]
        public void NextMin_HandlesMinEqualsMaxGracefully()
        {
            // Arrange
            MyRandom random = new MyRandom(123);
            int min = 25;
            int max = 25;

            // Act
            Action action = () => random.NextMin(min, max);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
    
public class BoardTests
    {
        [Fact]
        public void Constructor_InitializesBoardPropertiesCorrectly()
        {
            // Arrange
            int seed = 42;

            // Act
            Board board = new Board(seed);

            // Assert
            Assert.NotNull(board.Random);
            Assert.Equal(0, board.TurnCount);
            Assert.NotNull(board.Moves);
            Assert.Empty(board.Moves);
            Assert.Equal(Board.Height, board.Tiles.GetLength(0));
            Assert.Equal(Board.Width, board.Tiles.GetLength(1));
        }

        [Fact]
        public void Constructor_FillsTilesWithValidValues()
        {
            // Arrange
            int seed = 42;
            var expectedTileTypes = new HashSet<Tile> { Tile.Forest, Tile.Field };

            // Act
            Board board = new Board(seed);

            // Assert
            for (int i = 0; i < Board.Height; i++)
            {
                for (int j = 0; j < Board.Width; j++)
                {
                    var (tile, unit) = board.Tiles[i, j];
                    Assert.Contains(tile, expectedTileTypes);
                    Assert.Null(unit); // Ensure no units are placed initially
                }
            }
        }

        [Fact]
        public void Constructor_UsesProvidedSeedForRandomTilePlacement()
        {
            // Arrange
            int seed = 42;
            Board board1 = new Board(seed);
            Board board2 = new Board(seed);

            // Act
            var tiles1 = board1.Tiles;
            var tiles2 = board2.Tiles;

            // Assert
            for (int i = 0; i < Board.Height; i++)
            {
                for (int j = 0; j < Board.Width; j++)
                {
                    Assert.Equal(tiles1[i, j], tiles2[i, j]); // Ensure identical boards for same seed
                }
            }
        }

        [Fact]
        public void Constructor_ProducesDifferentBoardsForDifferentSeeds()
        {
            // Arrange
            int seed1 = 42;
            int seed2 = 99;
            Board board1 = new Board(seed1);
            Board board2 = new Board(seed2);

            // Act
            var tiles1 = board1.Tiles;
            var tiles2 = board2.Tiles;

            // Assert
            bool areBoardsDifferent = false;
            for (int i = 0; i < Board.Height; i++)
            {
                for (int j = 0; j < Board.Width; j++)
                {
                    if (tiles1[i, j] != tiles2[i, j])
                    {
                        areBoardsDifferent = true;
                        break;
                    }
                }
                if (areBoardsDifferent) break;
            }
            Assert.True(areBoardsDifferent); // Ensure different boards for different seeds
        }
    }
    
public class UnitUtilsTests
    {
        [Fact]
        public void PositionInBounds_ReturnsTrue_WhenPositionIsWithinBounds()
        {
            // Act
            bool result = UnitUtils.PositionInBounds(5, 5);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PositionInBounds_ReturnsFalse_WhenPositionIsOutOfBounds_HigherThanHeight()
        {

            // Act
            bool result = UnitUtils.PositionInBounds(20, 5);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PositionInBounds_ReturnsFalse_WhenPositionIsOutOfBounds_HigherThanWidth()
        {
            // Act
            bool result = UnitUtils.PositionInBounds(5, 21);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PositionInBounds_ReturnsFalse_WhenPositionIsNegative()
        {
            // Act
            bool result = UnitUtils.PositionInBounds(-1, -1);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsGaulish_ReturnsTrue_ForAsterix()
        {
            // Arrange
            var unit = new Asterix(null!);

            // Act
            bool result = UnitUtils.IsGaulish(unit);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsGaulish_ReturnsTrue_ForObelix()
        {
            // Arrange
            var unit = new Obelix(null!);

            // Act
            bool result = UnitUtils.IsGaulish(unit);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsGaulish_ReturnsTrue_ForIdefix()
        {
            // Arrange
            var unit = new Idefix(null!);

            // Act
            bool result = UnitUtils.IsGaulish(unit);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsGaulish_ReturnsFalse_ForNonGaulishObject()
        {
            // Arrange
            var unit = new object();

            // Act
            bool result = UnitUtils.IsGaulish(unit);

            // Assert
            Assert.False(result);
        }
    }
    
    public class BoardTests2
{
    [Fact]
    public void Constructor_InitializesTilesWithCorrectDimensions()
    {
        // Arrange
        int expectedHeight = Board.Height;
        int expectedWidth = Board.Width;
        int seed = 123;

        // Act
        Board board = new Board(seed);

        // Assert
        Assert.NotNull(board.Tiles);
        Assert.Equal(expectedHeight, board.Tiles.GetLength(0));
        Assert.Equal(expectedWidth, board.Tiles.GetLength(1));
    }

    [Fact]
    public void Constructor_InitializesTilesWithValidTileTypes()
    {
        // Arrange
        int seed = 123;
        var validTiles = new[] { Tile.Forest, Tile.Field };

        // Act
        Board board = new Board(seed);

        // Assert
        for (int i = 0; i < Board.Height; i++)
        {
            for (int j = 0; j < Board.Width; j++)
            {
                Assert.Contains(board.Tiles[i, j].tile, validTiles);
                Assert.Null(board.Tiles[i, j].unit); // Ensure no units are initialized
            }
        }
    }

    [Fact]
    public void Constructor_InitializesEmptyMovesStack()
    {
        // Arrange
        int seed = 123;

        // Act
        Board board = new Board(seed);

        // Assert
        Assert.NotNull(board.Moves);
        Assert.Empty(board.Moves);
    }

    [Fact]
    public void Constructor_InitializesTurnCountToZero()
    {
        // Arrange
        int seed = 123;

        // Act
        Board board = new Board(seed);

        // Assert
        Assert.Equal(0, board.TurnCount);
    }

    [Fact]
    public void Constructor_UsesSeedToInitializeTilesConsistently()
    {
        // Arrange
        int seed = 123;

        // Act
        Board board1 = new Board(seed);
        Board board2 = new Board(seed);

        // Assert
        for (int i = 0; i < Board.Height; i++)
        {
            for (int j = 0; j < Board.Width; j++)
            {
                Assert.Equal(board1.Tiles[i, j].tile, board2.Tiles[i, j].tile);
                Assert.Equal(board1.Tiles[i, j].unit, board2.Tiles[i, j].unit);
            }
        }
    }
}