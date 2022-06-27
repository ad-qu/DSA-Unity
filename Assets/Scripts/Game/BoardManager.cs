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

    public int rows = 30;
    public int columns = 75;

    public GameObject coin, goomba;

    public GameObject sky, ground, basicWall, brick, invisibleBlock, exit;

    public GameObject[] wall, smallBush, bigBush, smallCloud, castle, mountain;

    public void SetupScene(int level)
    {
        int i = -10, y = -10;

        if (level == 0)
        {
            while (i <= (columns + 10)) //Building the sky
            {
                while (y <= rows) { Instantiate(sky, new Vector3(i, y), Quaternion.identity); y++; } y = -10; i++;
            }

            i = -10; y = -3;

            while (y <= 0) //Building the ground
            {
                while (i < columns)
                {
                    if ((i == 12) || (i == 13) || (i == 14) || (i == 24) || (i == 26) || (i == 27) || (i == 33) || (i == 34) ||
                        (i == 45) || (i == 46) || (i == 47) || (i == 48) || (i == 49) || (i == 50) || (i == 51) || (i == 52) || (i == 61) || (i == 62) || (i == 63) || (i == 64)) { i++; }
                    
                    else { Instantiate(ground, new Vector3(i, y), Quaternion.identity); i++; }
                }

                i = -10;
                y++;
            }

            i = 10; y = 1;

            while (y < 10) //Building the bricks
            {
                while (i < columns)
                {
                    if (((i == 17) && (y == 4)) || ((i == 18) && (y == 4)) || ((i == 19) && (y == 4)) || ((i == 20) && (y == 4)) || ((i == 21) && (y == 4)) ||
                        ((i == 28) && (y == 5)) || ((i == 29) && (y == 5)) || ((i == 30) && (y == 5)) || ((i == 31) && (y == 5)) || ((i == 32) && (y == 5)) || 
                        ((i == 33) && (y == 5)) || ((i == 35) && (y == 5)) || ((i == 36) && (y == 5)) || ((i == 37) && (y == 5)) || ((i == 38) && (y == 5)) || ((i == 39) && (y == 5)) || 
                        ((i == 46) && (y == 2)) || ((i == 47) && (y == 2)) || ((i == 48) && (y == 2)) || ((i == 49) && (y == 2)) || ((i == 50) && (y == 2)) || ((i == 51) && (y == 2))) { Instantiate(brick, new Vector3(i, y), Quaternion.identity); i++; }

                    else { i++; }
                }

                i = 10;
                y++;
            }

            i = 10; y = 1;

            while (y < 10) //Building the basic walls
            {
                while (i < columns)
                {
                    if (((i == 11) && (y == 1)) || ((i == 11) && (y == 2)) || ((i == 11) && (y == 3)) || ((i == 11) && (y == 4)) || ((i == 11) && (y == 5)) || ((i == 25) && (y == 1)) || 
                        ((i == 25) && (y == 2)) || ((i == 49) && (y == 4)) || ((i == 49) && (y == 5)) || ((i == 49) && (y == 6)) || ((i == 49) && (y == 7)) || ((i == 49) && (y == 8)) || 
                        ((i == 58) && (y == 1)) || ((i == 59) && (y == 1)) ||  ((i == 60) && (y == 1)) || ((i == 59) && (y == 2)) || ((i == 60) && (y == 2)) || ((i == 60) && (y == 3))) { Instantiate(basicWall, new Vector3(i, y), Quaternion.identity); i++; }

                    else { i++; }
                }

                i = 10;
                y++;
            }

            i = 10; y = 1;

            while (y < 10) //Building the sticky walls
            {
                var rnd1 = Random.Range(0, 2);
                var rnd2 = Random.Range(3, 5);

                while (i < columns)
                {
                    if (((i == 10) && (y == 1)) || ((i == 10) && (y == 2)) || ((i == 10) && (y == 3)) || ((i == 10) && (y == 4)) || ((i == 10) && (y == 5)) || ((i == 48) && (y == 4)) ||
                        ((i == 48) && (y == 5)) || ((i == 48) && (y == 6)) || ((i == 48) && (y == 7)) || ((i == 48) && (y == 8))) { Instantiate(wall[rnd1], new Vector3(i, y), Quaternion.identity); i++; }
                    
                    else if (((i == 40) && (y == 1)) || ((i == 40) && (y == 2)) || ((i == 40) && (y == 3)) || ((i == 40) && (y == 4)) || ((i == 40) && (y == 5))) { Instantiate(wall[rnd2], new Vector3(i, y), Quaternion.identity); i++; }
                    
                    else { i++; }
                }

                i = 10;
                y++;
            }

            PlacingCoins(level);

            GenerateEnemies(level);

            PlacingDecorations(level);

            BuildingInvisibleWallAndExit();
        }

        else
        {
            while (i <= (columns + 10)) //Building the sky
            {
                while (y <= rows) { Instantiate(sky, new Vector3(i, y), Quaternion.identity); y++; }
                y = -10; i++;
            }

            i = -10; y = -3;

            while (y <= 0) //Building the ground
            {
                while (i < columns)
                {
                    if ((i == 12) || (i == 13) || (i == 14) || (i == 15) || (i == 16) || (i == 17) || (i == 18) || (i == 19) || (i == 20) || (i == 21) ||
                        (i == 22) || (i == 23) || (i == 24) || (i == 25) || (i == 26) || (i == 28) || (i == 57) || (i == 62) || (i == 63) || (i == 64)) { i++; }

                    else { Instantiate(ground, new Vector3(i, y), Quaternion.identity); i++; }
                }

                i = -10;
                y++;
            }

            i = 10; y = 1;

            while (y < 10) //Building the bricks
            {
                while (i < columns)
                {
                    if (((i == 14) && (y == 2)) || ((i == 15) && (y == 2)) || ((i == 16) && (y == 2)) || ((i == 17) && (y == 2)) || ((i == 18) && (y == 2)) || ((i == 19) && (y == 2)) ||
                        ((i == 16) && (y == 7)) || ((i == 17) && (y == 7)) || ((i == 21) && (y == 7)) || ((i == 22) && (y == 7)) || ((i == 25) && (y == 2)) ||
                        ((i == 23) && (y == 7)) || ((i == 22) && (y == 2)) || ((i == 23) && (y == 2)) || ((i == 24) && (y == 2)) || ((i == 30) && (y == 4)) || ((i == 31) && (y == 4)) ||
                        ((i == 32) && (y == 4)) || ((i == 33) && (y == 4)) || ((i == 36) && (y == 7)) || ((i == 37) && (y == 7)) || ((i == 40) && (y == 2)) || ((i == 41) && (y == 2)) || 
                        ((i == 42) && (y == 2)) || ((i == 43) && (y == 2)) || ((i == 45) && (y == 4)) || ((i == 46) && (y == 4)) || ((i == 47) && (y == 4)) || ((i == 48) && (y == 4)) || 
                        ((i == 49) && (y == 4)) || ((i == 50) && (y == 4))) { Instantiate(brick, new Vector3(i, y), Quaternion.identity); i++; }

                    else if (((i == 16) && (y == 6)) || ((i == 17) && (y == 6))) { Instantiate(castle[2], new Vector3(i, y), Quaternion.identity); i++; }

                    else { i++; }
                }

                i = 10;
                y++;
            }

            i = 10; y = 1;

            while (y < 12) //Building the basic walls
            {
                while (i < columns)
                {
                    if (((i == 11) && (y == 1)) || ((i == 11) && (y == 2)) || ((i == 11) && (y == 3)) || ((i == 11) && (y == 4)) || ((i == 11) && (y == 5)) ||
                        ((i == 26) && (y == 9)) || ((i == 26) && (y == 10)) || ((i == 26) && (y == 11)) || ((i == 27) && (y == 1)) || ((i == 38) && (y == 2)) ||
                        ((i == 38) && (y == 3)) || ((i == 48) && (y == 6)) || ((i == 48) && (y == 7)) || ((i == 48) && (y == 8)) || ((i == 48) && (y == 9)) || ((i == 48) && (y == 10)) || 
                        ((i == 58) && (y == 1)) || ((i == 59) && (y == 1)) || ((i == 60) && (y == 1)) || ((i == 61) && (y == 1)) || ((i == 59) && (y == 2)) || ((i == 60) && (y == 2)) || 
                        ((i == 61) && (y == 2)) || ((i == 60) && (y == 3)) || ((i == 61) && (y == 3)) || ((i == 61) && (y == 4))) { Instantiate(basicWall, new Vector3(i, y), Quaternion.identity); i++; }

                    else { i++; }
                }

                i = 10;
                y++;
            }

            i = 10; y = 1;

            while (y < 11) //Building the sticky walls
            {
                var rnd = Random.Range(0, 2);

                while (i < columns)
                {
                    if (((i == 10) && (y == 1)) || ((i == 10) && (y == 2)) || ((i == 10) && (y == 3)) || ((i == 10) && (y == 4)) || ((i == 10) && (y == 5)) || ((i == 20) && (y == 4)) ||
                        ((i == 20) && (y == 5)) || ((i == 20) && (y == 6)) || ((i == 20) && (y == 7)) || ((i == 37) && (y == 2)) || ((i == 37) && (y == 3)) || ((i == 47) && (y == 6)) || 
                        ((i == 47) && (y == 7)) || ((i == 47) && (y == 8)) || ((i == 47) && (y == 9)) || ((i == 47) && (y == 10))) { Instantiate(wall[rnd = Random.Range(0, 2)], new Vector3(i, y), Quaternion.identity); i++; }

                    else { i++; }
                }

                i = 10;
                y++;
            }

            PlacingCoins(level);
            GenerateEnemies(level);
            PlacingDecorations(level);
            BuildingInvisibleWallAndExit();
        }
    }

    public void PlacingCoins(int level)
    {
        if (level == 0)
        {
            Instantiate(coin, new Vector3(19, 5), Quaternion.identity); Instantiate(coin, new Vector3(33, 8), Quaternion.identity);
            Instantiate(coin, new Vector3(35, 1), Quaternion.identity); Instantiate(coin, new Vector3(37, 6), Quaternion.identity);
            Instantiate(coin, new Vector3(41, 3), Quaternion.identity); Instantiate(coin, new Vector3(49, 9), Quaternion.identity);
            Instantiate(coin, new Vector3(55, 1), Quaternion.identity); Instantiate(coin, new Vector3(63, 7), Quaternion.identity);
        }
        else
        {
            Instantiate(coin, new Vector3(16, 8), Quaternion.identity); Instantiate(coin, new Vector3(16, 9), Quaternion.identity);
            Instantiate(coin, new Vector3(17, 8), Quaternion.identity); Instantiate(coin, new Vector3(17, 9), Quaternion.identity);
            Instantiate(coin, new Vector3(19, 3), Quaternion.identity); Instantiate(coin, new Vector3(23, 8), Quaternion.identity); 
            Instantiate(coin, new Vector3(22, 3), Quaternion.identity); Instantiate(coin, new Vector3(25, 10), Quaternion.identity);
            Instantiate(coin, new Vector3(32, 6), Quaternion.identity); Instantiate(coin, new Vector3(37, 8), Quaternion.identity);
            Instantiate(coin, new Vector3(48, 11), Quaternion.identity); Instantiate(coin, new Vector3(45, 1), Quaternion.identity);
            Instantiate(coin, new Vector3(46, 1), Quaternion.identity); Instantiate(coin, new Vector3(47, 1), Quaternion.identity);
            Instantiate(coin, new Vector3(48, 1), Quaternion.identity); Instantiate(coin, new Vector3(49, 1), Quaternion.identity);
            Instantiate(coin, new Vector3(50, 1), Quaternion.identity); Instantiate(coin, new Vector3(63, 8), Quaternion.identity);
        }
    }

    public void GenerateEnemies(int level)
    {
        if (level == 0)
        {
            Instantiate(goomba, new Vector3(15, 1), Quaternion.identity);
            Instantiate(goomba, new Vector3(17, 5), Quaternion.identity);
            Instantiate(goomba, new Vector3(28, 6), Quaternion.identity);
            Instantiate(goomba, new Vector3(35, 6), Quaternion.identity);
            Instantiate(goomba, new Vector3(46, 3), Quaternion.identity);
        }
        else
        {
            Instantiate(goomba, new Vector3(14, 3), Quaternion.identity);
            Instantiate(goomba, new Vector3(20, 8), Quaternion.identity);
            Instantiate(goomba, new Vector3(30, 5), Quaternion.identity);
            Instantiate(goomba, new Vector3(45, 5), Quaternion.identity);
            Instantiate(goomba, new Vector3(28, 1), Quaternion.identity);
            Instantiate(goomba, new Vector3(50, 1), Quaternion.identity);
        }
    }

    public void PlacingDecorations(int level)
    {
        PlacingClouds();

        if (level == 0)
        {
            Instantiate(smallBush[0], new Vector3(4, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(5, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(-3, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(-2, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(17, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(18, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(21, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(22, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(28, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(29, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(21, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(22, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(42, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(43, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(66, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(67, 1), Quaternion.identity);

            Instantiate(mountain[0], new Vector3(36, 1), Quaternion.identity); Instantiate(mountain[1], new Vector3(37, 1), Quaternion.identity);
            Instantiate(mountain[2], new Vector3(37, 2), Quaternion.identity); Instantiate(mountain[3], new Vector3(38, 1), Quaternion.identity);
            Instantiate(mountain[0], new Vector3(54, 1), Quaternion.identity); Instantiate(mountain[1], new Vector3(55, 1), Quaternion.identity);
            Instantiate(mountain[2], new Vector3(55, 2), Quaternion.identity); Instantiate(mountain[3], new Vector3(56, 1), Quaternion.identity);
        }
        else
        {
            Instantiate(smallBush[0], new Vector3(4, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(5, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(-3, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(-2, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(30, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(31, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(42, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(43, 1), Quaternion.identity);
            Instantiate(smallBush[0], new Vector3(66, 1), Quaternion.identity); Instantiate(smallBush[1], new Vector3(67, 1), Quaternion.identity);

            Instantiate(mountain[0], new Vector3(33, 1), Quaternion.identity); Instantiate(mountain[1], new Vector3(34, 1), Quaternion.identity);
            Instantiate(mountain[2], new Vector3(34, 2), Quaternion.identity); Instantiate(mountain[3], new Vector3(35, 1), Quaternion.identity);
            Instantiate(mountain[0], new Vector3(53, 1), Quaternion.identity); Instantiate(mountain[1], new Vector3(54, 1), Quaternion.identity);
            Instantiate(mountain[2], new Vector3(54, 2), Quaternion.identity); Instantiate(mountain[3], new Vector3(55, 1), Quaternion.identity);
        }
    }

    public void PlacingClouds()
    {
        Instantiate(smallCloud[0], new Vector3(7, 6), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(8, 6), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(7, 5), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(8, 5), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(13, 8), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(14, 8), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(13, 7), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(14, 7), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(25, 8), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(26, 8), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(25, 7), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(26, 7), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(38, 10), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(39, 10), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(38, 9), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(39, 9), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(43, 6), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(44, 6), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(43, 5), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(44, 5), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(46, 13), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(47, 13), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(46, 12), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(47, 12), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(53, 9), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(54, 9), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(53, 8), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(54, 8), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(58, 7), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(59, 7), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(58, 6), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(59, 6), Quaternion.identity);
        Instantiate(smallCloud[0], new Vector3(66, 5), Quaternion.identity); Instantiate(smallCloud[1], new Vector3(67, 5), Quaternion.identity); Instantiate(smallCloud[2], new Vector3(66, 4), Quaternion.identity); Instantiate(smallCloud[3], new Vector3(67, 4), Quaternion.identity);
    }

    public void BuildingInvisibleWallAndExit()
    {
        Instantiate(invisibleBlock, new Vector3(2, 1), Quaternion.identity);
        Instantiate(invisibleBlock, new Vector3(2, 2), Quaternion.identity);
        Instantiate(invisibleBlock, new Vector3(2, 3), Quaternion.identity);
        Instantiate(invisibleBlock, new Vector3(2, 4), Quaternion.identity);
        Instantiate(invisibleBlock, new Vector3(2, 5), Quaternion.identity);

        Instantiate(castle[0], new Vector3(70, 5), Quaternion.identity);
        Instantiate(castle[0], new Vector3(71, 5), Quaternion.identity);
        Instantiate(castle[0], new Vector3(72, 5), Quaternion.identity);

        Instantiate(castle[1], new Vector3(70, 4), Quaternion.identity);
        Instantiate(castle[2], new Vector3(71, 4), Quaternion.identity);
        Instantiate(castle[3], new Vector3(72, 4), Quaternion.identity);

        Instantiate(castle[0], new Vector3(69, 3), Quaternion.identity);
        Instantiate(castle[4], new Vector3(70, 3), Quaternion.identity);
        Instantiate(castle[4], new Vector3(71, 3), Quaternion.identity);
        Instantiate(castle[4], new Vector3(72, 3), Quaternion.identity);
        Instantiate(castle[0], new Vector3(73, 3), Quaternion.identity);

        Instantiate(castle[2], new Vector3(69, 2), Quaternion.identity);
        Instantiate(castle[2], new Vector3(70, 2), Quaternion.identity);
        Instantiate(castle[5], new Vector3(71, 2), Quaternion.identity);
        Instantiate(castle[2], new Vector3(72, 2), Quaternion.identity);
        Instantiate(castle[2], new Vector3(73, 2), Quaternion.identity);

        Instantiate(castle[2], new Vector3(69, 1), Quaternion.identity);
        Instantiate(castle[2], new Vector3(70, 1), Quaternion.identity);
        Instantiate(castle[6], new Vector3(71, 1), Quaternion.identity);
        Instantiate(castle[2], new Vector3(72, 1), Quaternion.identity);
        Instantiate(castle[2], new Vector3(73, 1), Quaternion.identity);

        Instantiate(exit, new Vector3(72, 1), Quaternion.identity);
    }
}