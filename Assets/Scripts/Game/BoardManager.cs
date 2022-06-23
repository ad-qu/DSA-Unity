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


    public GameObject sky, ground, basicWall, brick;

    public GameObject[] wall, smallBush, bigBush, smallCloud;

    int i, y;

    public void SetupScene(int level)
    {
        if (level == 1)
        {
            while (i < 22)
            {
                while (y < 15)
                {
                    Instantiate(sky, new Vector3(i, y), Quaternion.identity);
                    y++;
                }

                y = 0;
                i++;
            }

            i = 0; y = -1;

            while (y < 1)
            {
                while (i < 22)
                {
                    Instantiate(ground, new Vector3(i, y), Quaternion.identity);
                    i++;
                }

                i = 0;
                y++;
            }

            Instantiate(smallBush[0], new Vector3(2, 1), Quaternion.identity);
            Instantiate(smallBush[1], new Vector3(3, 1), Quaternion.identity);

            Instantiate(smallCloud[2], new Vector3(4, 5), Quaternion.identity);
            Instantiate(smallCloud[0], new Vector3(4, 6), Quaternion.identity);
            Instantiate(smallCloud[3], new Vector3(5, 5), Quaternion.identity);
            Instantiate(smallCloud[1], new Vector3(5, 6), Quaternion.identity);

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