using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuPrefab",menuName = "ScriptableObjects/MenuPrefab",order = 1)]
public class MenuPrefab : ScriptableObject
{
    //เรียง ให้ ID ตรงกับ Prefab อันนั้น
    public List<int> ID = new List<int>(); // ID ของอาหาร

    public List<GameObject> prefab = new List<GameObject>(); // Prefab ของอาหาร
    
}
