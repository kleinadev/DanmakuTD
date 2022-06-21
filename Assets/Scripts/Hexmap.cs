using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Hexmap : MonoBehaviour
{
    private int sizeX = 12;
    private int sizeY = 10;
    private Grid grid;
    private Tilemap tilemap;
    public TileBase FreeTile;
    public TileBase PathTile;
    public GameObject PathParent;
    public GameObject StartNode;
    public GameObject Spawner;
    public GameObject FocusTower;
    public GameObject SpreadTower;
    public GameObject TilemapObject;
    
    // Start is called before the first frame update
    private void Start()
    {
        grid = (Grid) this.GetComponent(typeof(Grid));
        var tilemapObject = GameObject.Find("Tilemap");
        tilemap = tilemapObject.GetComponent<Tilemap>();
        tilemap.size = new Vector3Int(sizeX*2, sizeY*2);
        
        GenerateWorld();
        Instantiate(FocusTower, grid.GetCellCenterWorld(new Vector3Int(0, -3)), new Quaternion());
        Instantiate(SpreadTower, grid.GetCellCenterWorld(new Vector3Int(-3, -3)), new Quaternion());
        Spawner.transform.position = StartNode.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void GenerateWorld()
    {
        PaintEmptyTiles();
        GeneratePath();
        tilemap.RefreshAllTiles();
    }

    private void PaintEmptyTiles()
    {
        //create model for each hex
        for (int x = -sizeX; x < sizeX; x++)
        {
            for (int y = -sizeY; y < sizeY; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y), FreeTile);
            }
        }
    }

    private void GeneratePath()
    {
        //create the path that enemies will follow
        var pathCoords = PlaceholderPathGen();
        foreach (var hexPos in pathCoords)
        {
            tilemap.SetTile(hexPos, PathTile);
            GameObject.Instantiate(StartNode, grid.CellToWorld(hexPos), new Quaternion(), PathParent.transform);
        }
    }

    private List<Vector3Int> PlaceholderPathGen()
    {
        List<Vector3Int> path = new List<Vector3Int> { };
        int y = -5;
        int x;
        for (x = -sizeX; x < 3; x++)
        {
            path.Add(new Vector3Int(x, y));
        }

        for (y = -4; y < 5; y++)
        {
            if (y%2 != 0)
            {
                x--;
            }
            path.Add(new Vector3Int(x, y));
        }

        for (x = -1; x < sizeX; x++)
        {
            path.Add(new Vector3Int(x, y));
        }
        return path;
    }

}
