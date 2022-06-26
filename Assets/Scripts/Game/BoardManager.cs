using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int rows = 10;
    public int columns = 20;

    public GameObject coin, goomba;

    public GameObject sky, ground, basicWall, brick, invisibleBlock, exit;

    public GameObject[] wall, smallBush, bigBush, smallCloud;

    int i = -20, y = -10;

    public void SetupScene(int level)
    {
        if (level == 1)
        {
            while (i < 42)
            {
                while (y < 15)
                {
                    Instantiate(sky, new Vector3(i, y), Quaternion.identity);
                    y++;
                }

                y = -10;
                i++;
            }

            i = -20; y = -1;

            while (y < 1)
            {
                while (i < 42)
                {
                    if (i == 28)
                    {
                        i = 32;
                    }
                    else
                    {
                        Instantiate(ground, new Vector3(i, y), Quaternion.identity);
                        i++;
                    }
                }

                i = -42;
                y++;
            }

            Instantiate(invisibleBlock, new Vector3(2, 1), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 2), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 3), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 4), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 5), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(-5, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(-4, 1), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(2, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(3, 1), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(2, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(3, 1), Quaternion.identity);

            Instantiate(brick, new Vector3(15, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(16, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(17, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(18, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(19, 4), Quaternion.identity);

            Instantiate(coin, new Vector3(17, 5), Quaternion.identity);

            Instantiate(goomba, new Vector3(16, 1), Quaternion.identity);
            Instantiate(goomba, new Vector3(15, 5), Quaternion.identity);

            Instantiate(smallCloud[2], new Vector3(4, 5), Quaternion.identity);
            Instantiate(smallCloud[0], new Vector3(4, 6), Quaternion.identity);
            Instantiate(smallCloud[3], new Vector3(5, 5), Quaternion.identity);
            Instantiate(smallCloud[1], new Vector3(5, 6), Quaternion.identity);

            Instantiate(smallCloud[2], new Vector3(16, 7), Quaternion.identity);
            Instantiate(smallCloud[0], new Vector3(16, 8), Quaternion.identity);
            Instantiate(smallCloud[3], new Vector3(17, 7), Quaternion.identity);
            Instantiate(smallCloud[1], new Vector3(17, 8), Quaternion.identity);

            Instantiate(wall[0], new Vector3(10, 1), Quaternion.identity);
            Instantiate(wall[1], new Vector3(10, 2), Quaternion.identity);
            Instantiate(wall[2], new Vector3(10, 3), Quaternion.identity);
            Instantiate(wall[1], new Vector3(10, 4), Quaternion.identity);
            Instantiate(wall[2], new Vector3(10, 5), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 1), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 2), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 3), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 4), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 5), Quaternion.identity);

            Instantiate(exit, new Vector3(35, 1), Quaternion.identity);
        }

        if (level == 2)
        {
            while (i < 42)
            {
                while (y < 15)
                {
                    Instantiate(sky, new Vector3(i, y), Quaternion.identity);
                    y++;
                }

                y = 0;
                i++;
            }

            i = -20; y = -1;

            while (y < 1)
            {
                while (i < 42)
                {
                    if (i == 20)
                    {
                        i=31;
                    }
                    else
                    {
                        Instantiate(ground, new Vector3(i, y), Quaternion.identity);
                        i++;
                    }
                }

                i = -42;
                y++;
            }

            Instantiate(invisibleBlock, new Vector3(2, 1), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 2), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 3), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 4), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 5), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(-5, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(-4, 1), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(2, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(3, 1), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(2, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(3, 1), Quaternion.identity);

            Instantiate(brick, new Vector3(15, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(16, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(17, 4), Quaternion.identity);

            Instantiate(coin, new Vector3(16, 5), Quaternion.identity);

            Instantiate(goomba, new Vector3(16, 1), Quaternion.identity);

            Instantiate(smallCloud[2], new Vector3(4, 5), Quaternion.identity);
            Instantiate(smallCloud[0], new Vector3(4, 6), Quaternion.identity);
            Instantiate(smallCloud[3], new Vector3(5, 5), Quaternion.identity);
            Instantiate(smallCloud[1], new Vector3(5, 6), Quaternion.identity);

            Instantiate(smallCloud[2], new Vector3(16, 7), Quaternion.identity);
            Instantiate(smallCloud[0], new Vector3(16, 8), Quaternion.identity);
            Instantiate(smallCloud[3], new Vector3(17, 7), Quaternion.identity);
            Instantiate(smallCloud[1], new Vector3(17, 8), Quaternion.identity);

            Instantiate(wall[0], new Vector3(10, 1), Quaternion.identity);
            Instantiate(wall[1], new Vector3(10, 2), Quaternion.identity);
            Instantiate(wall[2], new Vector3(10, 3), Quaternion.identity);
            Instantiate(wall[1], new Vector3(10, 4), Quaternion.identity);
            Instantiate(wall[2], new Vector3(10, 5), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 1), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 2), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 3), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 4), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 5), Quaternion.identity);

            Instantiate(exit, new Vector3(35, 1), Quaternion.identity);
        }

        if (level == 3)
        {
            while (i < 42)
            {
                while (y < 15)
                {
                    Instantiate(sky, new Vector3(i, y), Quaternion.identity);
                    y++;
                }

                y = 0;
                i++;
            }

            i = -20; y = -1;

            while (y < 1)
            {
                while (i < 42)
                {
                    if (i == 28 && i == 29 && i == 30)
                    {
                        i++;
                    }
                    else
                    {
                        Instantiate(ground, new Vector3(i, y), Quaternion.identity);
                        i++;
                    }
                }

                i = -42;
                y++;
            }

            Instantiate(invisibleBlock, new Vector3(2, 1), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 2), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 3), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 4), Quaternion.identity);
            Instantiate(invisibleBlock, new Vector3(2, 5), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(-5, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(-4, 1), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(2, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(3, 1), Quaternion.identity);

            Instantiate(smallBush[0], new Vector3(2, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(3, 1), Quaternion.identity);

            Instantiate(brick, new Vector3(15, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(16, 4), Quaternion.identity);
            Instantiate(brick, new Vector3(17, 4), Quaternion.identity);

            Instantiate(coin, new Vector3(16, 5), Quaternion.identity);

            Instantiate(smallCloud[2], new Vector3(4, 5), Quaternion.identity);
            Instantiate(smallCloud[0], new Vector3(4, 6), Quaternion.identity);
            Instantiate(smallCloud[3], new Vector3(5, 5), Quaternion.identity);
            Instantiate(smallCloud[1], new Vector3(5, 6), Quaternion.identity);

            Instantiate(smallCloud[2], new Vector3(16, 7), Quaternion.identity);
            Instantiate(smallCloud[0], new Vector3(16, 8), Quaternion.identity);
            Instantiate(smallCloud[3], new Vector3(17, 7), Quaternion.identity);
            Instantiate(smallCloud[1], new Vector3(17, 8), Quaternion.identity);

            Instantiate(wall[0], new Vector3(10, 1), Quaternion.identity);
            Instantiate(wall[1], new Vector3(10, 2), Quaternion.identity);
            Instantiate(wall[2], new Vector3(10, 3), Quaternion.identity);
            Instantiate(wall[1], new Vector3(10, 4), Quaternion.identity);
            Instantiate(wall[2], new Vector3(10, 5), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 1), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 2), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 3), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 4), Quaternion.identity);
            Instantiate(basicWall, new Vector3(11, 5), Quaternion.identity);

            Instantiate(exit, new Vector3(35, 1), Quaternion.identity);
        }
    }
}