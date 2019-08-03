using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customGrid : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject tile;
    Vector3 truePos;
    public int gridSize;
    public int worldSizeX;
    public int worldSizeZ;
    private string[,] grid;

    void Start()
    {
       grid = new string[worldSizeZ, worldSizeX];
       initGrid();
       for(int z = 0; z < worldSizeZ; z++)
        {
            for(int x = 0; x < worldSizeX; x++)
            {
                Vector3 pos = new Vector3(x, 0, z);
                GameObject t = (GameObject)Instantiate(tile, pos, Quaternion.identity);
            }
        }
       foreach (GameObject building in buildings)
        {
            int x = (int)Mathf.Floor(building.transform.position.x / gridSize) * gridSize;
            int z = (int)Mathf.Floor(building.transform.position.z / gridSize) * gridSize;
            truePos.x = x;
            truePos.y = building.transform.position.y;
            truePos.z = z;
            grid[z, x] = building.name;
            Debug.Log("TYPE: " + building.name + grid[z, x]);
            
            printGrid();
        }
    }

    void initGrid()
    {
        int rowLength = grid.GetLength(0);
        int colLength = grid.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                grid[i, j] = "free";
            }
        }
    }

    void printGrid()
    {
        int rowLength = grid.GetLength(0);
        int colLength = grid.GetLength(1);

        string g = "";

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                g += string.Format(grid[i, j]);
            }
            g += System.Environment.NewLine;
        }

        Debug.Log("GRID: " + g);
    }

    void LateUpdate()
    {
        foreach (GameObject building in buildings)
        {
            truePos.x = Mathf.Floor(building.transform.position.x / gridSize) * gridSize;
            truePos.y = building.transform.position.y;
            truePos.z = Mathf.Floor(building.transform.position.z / gridSize) * gridSize;

            building.transform.position = truePos;
        }
    }
}
