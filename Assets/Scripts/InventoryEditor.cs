using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEditor.SceneManagement;


[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    private Inventory _inventory; // let's specify which script will be configured
    private void OnEnable() // when active 
    {
        _inventory = (Inventory)target; // convert Object to Inventory type 
    }

    public override void OnInspectorGUI()
    {
        if (_inventory.itemList.Count > 0)
        {
            foreach (Inventory.Item item in _inventory.itemList)
            {
                EditorGUILayout.BeginVertical("box");
                item.id = EditorGUILayout.IntField("Identificator", item.id);
                item.name = EditorGUILayout.TextField("Item Name", item.name);
                item.image = (Sprite) EditorGUILayout.ObjectField("Sprite", item.image, typeof(Sprite), false);
                EditorGUILayout.EndVertical();
            }

        }
        else
        {
            EditorGUILayout.LabelField("Inventory is empty");
        }
        if (GUILayout.Button("Add an item",GUILayout.Width(200), GUILayout.Height(30)))
            _inventory.itemList.Add(new Inventory.Item());
        if (GUI.changed)
            SetObjectDirty(_inventory.gameObject);
    }
    public static void SetObjectDirty (GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }

}
