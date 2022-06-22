using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class HexmapController : MonoBehaviour
{
    private int SizeX = 12;
    private int SizeY = 10;
    private Grid Grid;
    public Tilemap Tilemap;
    public TileBase FreeTile;
    public TileBase PathTile;
    public GameObject PathParent;
    public GameObject StartNode;
    public Tilemap InteractionTilemap;
    public TileBase HoveredTile;

    private List<Vector2Int> PathHexCoords = new List<Vector2Int> { };
    private List<Vector2Int> TowerHexCoords = new List<Vector2Int> { };
    
    public void AddTowerCoords(Vector2Int hexCoords)
    {
        if(!TowerHexCoords.Contains(hexCoords))
        {
            TowerHexCoords.Add(hexCoords);
        }
    }

    public bool HexIsFree(Vector2Int hexCoords)
    {
        return !TowerHexCoords.Contains(hexCoords) && !PathHexCoords.Contains(hexCoords);
    }

    public void SetHoveredHex(Vector2Int oldHex, Vector2Int newHex)
    {
        InteractionTilemap.SetTile((Vector3Int)newHex, HoveredTile);
        InteractionTilemap.SetTile((Vector3Int)oldHex, null);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Grid = gameObject.GetComponent<Grid>();
        Tilemap.size = new Vector3Int(SizeX*2, SizeY*2);
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        PaintEmptyTiles();
        GeneratePath();
        Tilemap.RefreshAllTiles();
    }

    private void PaintEmptyTiles()
    {
        //create model for each hex
        for (int x = -SizeX; x < SizeX; x++)
        {
            for (int y = -SizeY; y < SizeY; y++)
            {
                Tilemap.SetTile(new Vector3Int(x, y), FreeTile);
            }
        }
    }

    private void GeneratePath()
    {
        //create the path that enemies will follow
        PathHexCoords = PlaceholderPathGen();
        foreach (var hexPos in PathHexCoords)
        {
            Tilemap.SetTile((Vector3Int)hexPos, null);
            Instantiate(StartNode, Grid.CellToWorld((Vector3Int)hexPos), new Quaternion(), PathParent.transform);
        }
    }

    private List<Vector2Int> PlaceholderPathGen()
    {
        List<Vector2Int> path = new List<Vector2Int> { };
        int y = -5;
        int x;
        for (x = -SizeX; x < 3; x++)
        {
            path.Add(new Vector2Int(x, y));
        }

        for (y = -4; y < 5; y++)
        {
            if (y%2 != 0)
            {
                x--;
            }
            path.Add(new Vector2Int(x, y));
        }

        for (x = -1; x < SizeX; x++)
        {
            path.Add(new Vector2Int(x, y));
        }
        return path;
    }

}
