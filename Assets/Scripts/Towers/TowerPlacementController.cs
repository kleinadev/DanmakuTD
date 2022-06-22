using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerPlacementController : MonoBehaviour
{
    public TowerPrefabs Prefabs;
    public GameObject SelectedTower;
    private HexmapController Hexmap;

    public void SelectFocusTower()
    {
        SelectedTower = Prefabs.FocusTower;
    }

    public void SelectSpreadTower()
    {
        SelectedTower = Prefabs.SpreadTower;
    }

    public bool TryPlaceTower(Vector2 position)
    {
        if (SelectedTower != null)
        {
            PlaceTower(position);
            return true;
        }
        return false;
    }


    private void PlaceTower(Vector2 position)
    {
        if(SelectedTower != null)
        {
            Instantiate(SelectedTower, position, new Quaternion());
            SelectedTower = null;
        }
    }
}
