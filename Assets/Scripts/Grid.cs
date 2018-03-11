using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Tile tile;
    public int GridSize;    

    private Tile[,] grid;


	// Use this for initialization
	void Start () {
        grid = new Tile[GridSize,GridSize];
        CreateGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateGrid()
    {
        int gridDistance = 10;
        for (int x = 0; x < GridSize; x++)
        {
            for (int y = 0; y < GridSize; y++)
            {
                Tile newTile = Instantiate(tile);
                grid[x,y] = newTile;
                newTile.LocX = x * gridDistance;
                newTile.LocY = y * gridDistance;
                newTile.gameObject.transform.position = new Vector3(x*gridDistance, 0, y*gridDistance);
                newTile.transform.parent = this.transform;
            }
        }
    }
    
}
