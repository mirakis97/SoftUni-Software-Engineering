using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Wall wall;
        private Food[] food;
        private Queue<Point> snakeElements;
        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';

        private bool isFoodSpawned;
        private int snakePoints = 0;
        private int levelCount = 0;
        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.food = new Food[3];
            this.foodIndex = RandomFoodNumber;


            this.isFoodSpawned = false;

            this.GetFoods();
            this.CreateSnake();
        }

        public int SnakePoints => this.snakePoints;
        public int SnakeLevel => this.levelCount;

        private int RandomFoodNumber => new Random().Next(0, this.food.Length);

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            this.food[0] = new FoodHash(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
        

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }
            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);

            snakeNewHead.Draw(snakeSymbol);

            if (!this.isFoodSpawned)
            {
                this.food[foodIndex].SetRandomPosition(this.snakeElements);

                this.isFoodSpawned = true;
            }

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);

            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);
            return true;
        }

        private void Eat(Point direction,Point currentSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));

                GetNextPoint(direction, currentSnakeHead);
            }
            this.snakePoints++;
            if (snakePoints % 2 == 0)
            {
                this.levelCount++;
            }
            this.foodIndex = this.RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(this.snakeElements);
        }
    }
}
