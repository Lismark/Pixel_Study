using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemBase))]
public class ItemBaseEditor : Editor
{
    private ItemBase itemBase;

    public void Awake()
    {
        itemBase = (ItemBase)target;
    }
    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New item"))
            itemBase.CreateItem();

        if (GUILayout.Button("Remove item"))
            itemBase.RemoveItem();

        if (GUILayout.Button("<="))
            itemBase.PrevItem();

        if (GUILayout.Button("=>"))
            itemBase.NextItem();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
