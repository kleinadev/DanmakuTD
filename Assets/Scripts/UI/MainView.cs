using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainView : MonoBehaviour
{
    public VisualElement Root { get; set; }

    public VisualElement GameWindow;
    public Button NextWaveButton;
    //these should get replaced with a dynamic data model
    public Button SelectFocusButton;
    public Button SelectSpreadButton;

    // Start is called before the first frame update
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        Root = uiDocument.rootVisualElement;
        SelectFocusButton = Root.Q<Button>("SelectFocus");
        SelectSpreadButton = Root.Q<Button>("SelectSpread");
        NextWaveButton = Root.Q<Button>("NextWave");
        GameWindow = Root.Q<VisualElement>("GameWindow");
    }
}
