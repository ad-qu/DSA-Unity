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

        

        if (level == 1)
        {
            while (i <= (columns + 10)) //Building the sky
            {
                while (y <= rows) { Instantiate(sky, new Vector3(i, y), Quaternion.identity); y++; } y = -10; i++;
            }

            i = -10; y = -2;

            while (y <= 0) //Building the ground
            {
                while (i < columns)
                {
                    if ((i == 12) || (i == 13) || (i == 14) || (i == 24) || (i == 25) || (i == 26) || (i == 27) || (i == 30) || (i == 31) || (i == 33) || (i == 34) ||
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
                    if (((i == 17) && (y == 4)) || ((i == 18) && (y == 4)) || ((i == 19) && (y == 4)) || ((i == 20) && (y == 4)) || ((i == 21) && (y == 4)) || ((i == 25) && (y == 2)) || 
                        ((i == 26) && (y == 2)) || ((i == 28) && (y == 5)) || ((i == 29) && (y == 5)) || ((i == 30) && (y == 5)) || ((i == 31) && (y == 5)) || ((i == 32) && (y == 5)) || 
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
                    if (((i == 11) && (y == 1)) || ((i == 11) && (y == 2)) || ((i == 11) && (y == 3)) || ((i == 11) && (y == 4)) || ((i == 11) && (y == 5)) || ((i == 49) && (y == 4)) ||
                        ((i == 49) && (y == 5)) || ((i == 49) && (y == 6)) || ((i == 49) && (y == 7)) || ((i == 49) && (y == 8)) || ((i == 58) && (y == 1)) || ((i == 59) && (y == 1)) || 
                        ((i == 60) && (y == 1)) || ((i == 59) && (y == 2)) || ((i == 60) && (y == 2)) || ((i == 60) && (y == 3))) { Instantiate(basicWall, new Vector3(i, y), Quaternion.identity); i++; }

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

        if (level == 2)
        {
            while (i <= (columns + 10)) //Building the sky
            {
                while (y <= rows) { Instantiate(sky, new Vector3(i, y), Quaternion.identity); y++; }
                y = -10; i++;
            }

            i = -10; y = -2;

            while (y <= 0) //Building the ground
            {
                while (i < columns)
                {
                    if ((i == 12) || (i == 13) || (i == 14) || (i == 24) || (i == 25) || (i == 26) || (i == 27) || (i == 30) || (i == 31) || (i == 33) || (i == 34) ||
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
                    if (((i == 17) && (y == 4)) || ((i == 18) && (y == 4)) || ((i == 19) && (y == 4)) || ((i == 20) && (y == 4)) || ((i == 21) && (y == 4)) || ((i == 25) && (y == 2)) ||
                        ((i == 26) && (y == 2)) || ((i == 28) && (y == 5)) || ((i == 29) && (y == 5)) || ((i == 30) && (y == 5)) || ((i == 31) && (y == 5)) || ((i == 32) && (y == 5)) ||
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
                    if (((i == 11) && (y == 1)) || ((i == 11) && (y == 2)) || ((i == 11) && (y == 3)) || ((i == 11) && (y == 4)) || ((i == 11) && (y == 5)) || ((i == 49) && (y == 4)) ||
                        ((i == 49) && (y == 5)) || ((i == 49) && (y == 6)) || ((i == 49) && (y == 7)) || ((i == 49) && (y == 8)) || ((i == 58) && (y == 1)) || ((i == 59) && (y == 1)) ||
                        ((i == 60) && (y == 1)) || ((i == 59) && (y == 2)) || ((i == 60) && (y == 2)) || ((i == 60) && (y == 3))) { Instantiate(basicWall, new Vector3(i, y), Quaternion.identity); i++; }

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

        if (level == 3)
        {

        }
    }

    public void PlacingCoins(int level)
    {
        if (level == 1)
        {
            Instantiate(coin, new Vector3(19, 5), Quaternion.identity);
            Instantiate(coin, new Vector3(33, 8), Quaternion.identity);
            Instantiate(coin, new Vector3(35, 1), Quaternion.identity);
            Instantiate(coin, new Vector3(37, 6), Quaternion.identity);
            Instantiate(coin, new Vector3(41, 3), Quaternion.identity);
            Instantiate(coin, new Vector3(49, 9), Quaternion.identity);
            Instantiate(coin, new Vector3(55, 1), Quaternion.identity);
            Instantiate(coin, new Vector3(63, 7), Quaternion.identity);
        }
        else if (level == 2)
        {

        }
        else
        {

        }
    }

    public void GenerateEnemies(int level)
    {
        if (level == 1)
        {
            Instantiate(goomba, new Vector3(15, 1), Quaternion.identity);
            Instantiate(goomba, new Vector3(17, 5), Quaternion.identity);
            Instantiate(goomba, new Vector3(28, 6), Quaternion.identity);
            Instantiate(goomba, new Vector3(35, 6), Quaternion.identity);
            Instantiate(goomba, new Vector3(46, 3), Quaternion.identity);
        }
        else if (level == 2)
        {

        }
        else
        {

        }
    }

    public void PlacingDecorations(int level)
    {
        if (level == 1)
        {
            PlacingClouds();

        }
        else if (level == 2)
        {

        }
        else
        {

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