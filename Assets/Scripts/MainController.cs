using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    public MainView View;

    public TowerPlacementController TowerPlacement;
    public HexmapController Hexmap;
    public ResourceController Resources;
    public EnemySpawner Spawner;

    private GridInteractionController GridInteraction;
    private int WaveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Grid grid = Hexmap.gameObject.GetComponent<Grid>();
        GridInteraction = new GridInteractionController(TowerPlacement, grid);
        SetUpEventHandlers();
        SetUpSpawner();
    }

    public void SetUpDataBindings()
    {
        Resources.InitializeResourceList(View.Root);
    }

    public void SetUpEventHandlers()
    {
        View.SelectFocusButton.clickable = new Clickable(() => TowerPlacement.SelectFocusTower());
        View.SelectSpreadButton.clickable = new Clickable(() => TowerPlacement.SelectSpreadTower());
        View.NextWaveButton.clickable = new Clickable(() => StartNextWave());
        View.GameWindow.RegisterCallback<ClickEvent>(GridInteraction.HandleClick);
        View.GameWindow.RegisterCallback<PointerMoveEvent>(GridInteraction.HandlePointerMove);
    }

    public void StartNextWave()
    {
        WaveCount++;
        Spawner.StartNextWave();
    }

    private void SetUpSpawner()
    {
        Spawner.transform.position = Hexmap.StartNode.transform.position;
    }
}
