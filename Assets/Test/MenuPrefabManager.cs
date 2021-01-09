using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrefabManager : MonoBehaviour
{
    //รวม ScriptableObject MenuPrefab ให้กลายเป็น Dictionary
    public MenuPrefab menuPrefab;
    public Dictionary<int,GameObject> foodPrefab = new Dictionary<int, GameObject>();

    private void Awake() {
        for(int i = 0; i < menuPrefab.ID.Count; i++){
            foodPrefab.Add(menuPrefab.ID[i],menuPrefab.prefab[i]);
        }
    }
}
