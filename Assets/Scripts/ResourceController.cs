using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor;

public class ResourceController: MonoBehaviour
{
    [SerializeField]
    public int Power;
    [SerializeField]
    public int Lives;

    private Label UX_PowerLabel;

    public void InitializeResourceList(VisualElement root)
    {
        Power = 5;
        Lives = 3;
        UX_PowerLabel = root.Q<Label>("PowerAmount");

        SerializedObject so = new SerializedObject(this);
        root.Bind(so);
    }
}
