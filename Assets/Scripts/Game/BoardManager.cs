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

    public GameObject coin, basicGoomba, kingGoomba;

    public GameObject sky, ground, basicWall, brick, invisibleBlock;

    public GameObject[] wall, smallBush, bigBush, smallCloud;

    int i = -20, y;

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

                y = 0;
                i++;
            }

            i = -20; y = -1;

            while (y < 1)
            {
                while (i < 42)
                {
                    Instantiate(ground, new Vector3(i, y), Quaternion.identity);
                    i++;
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

            Instantiate(basicGoomba, new Vector3(14, 1), Quaternion.identity);
            Instantiate(kingGoomba, new Vector3(16, 1), Quaternion.identity);

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
        }

        if (level == 2)
        {

        }

        if (level == 3)
        {

        }
    }
}