using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridInteractionController
{
    private TowerPlacementController TowerPlacement;
    private Grid HexmapGrid;
    private HexmapController Hexmap;
    private Vector2Int HoveredHex;

    public GridInteractionController(TowerPlacementController towerPlacement, Grid hexmap)
    {
        TowerPlacement = towerPlacement;
        HexmapGrid = hexmap;
        Hexmap = HexmapGrid.GetComponent<HexmapController>();
    }

    public void HandleClick(ClickEvent e)
    {
        var hexCoords = CameraToHexCoords(e.position);
        if (Hexmap.HexIsFree(hexCoords))
        {
            bool towerPlaced = TowerPlacement.TryPlaceTower(CameraToHexCenter(e.position));
            if (towerPlaced)
            {
                Hexmap.AddTowerCoords(hexCoords);
            }
        }
    }

    public void HandlePointerMove(PointerMoveEvent e)
    {
        var currentHex = CameraToHexCoords(e.position);
        if (HoveredHex != currentHex)
        {
            Hexmap.SetHoveredHex(HoveredHex, currentHex);
            HoveredHex = currentHex;
            
        }
    }

    private Vector2 CameraToHexCenter(Vector2 cameraPoint)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(cameraPoint);
        var hexCoords = HexmapGrid.WorldToCell(worldPosition);
        //flip y because camera's 0,0 is in the top left
        return HexmapGrid.GetCellCenterWorld(new Vector3Int(hexCoords.x, -hexCoords.y));
    }

    private Vector2Int CameraToHexCoords(Vector2 cameraPoint)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(cameraPoint);
        var hexCoords = HexmapGrid.WorldToCell(worldPosition);
        return new Vector2Int(hexCoords.x, -hexCoords.y);
    }
}
