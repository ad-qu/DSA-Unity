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


    public GameObject sky, ground, basicWall;

    public GameObject[] wall;

    int i, y;

    public void SetupScene(int level)
    {
        if (level == 1)
        {
            Instantiate(ground, new Vector3(0, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(1, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(2, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(3, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(4, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(5, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(6, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(7, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(8, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(9, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(10, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(11, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(12, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(13, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(14, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(15, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(16, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(17, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(18, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(19, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(20, 0), Quaternion.identity);
            Instantiate(ground, new Vector3(21, 0), Quaternion.identity);

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