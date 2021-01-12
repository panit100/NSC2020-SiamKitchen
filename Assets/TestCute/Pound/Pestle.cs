using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pestle : MonoBehaviour
{
    [SerializeField]
    int currentPoundTime = 0; //จำนวนครั้งที่ตำปัจจุบัน
    public List<GameObject> ingredient = new List<GameObject>(); // GameObject ส่วนประกอบต่างๆในภาชนะ
    MenuManager menuCalculation = new MenuManager();
    
    public string ingredientID; // ID ของส่วนประกอบทั้งหมด

    [SerializeField]
    MenuPrefabManager menuPrefabManager = null;
    [SerializeField]
    Transform instantiatePosition = null; //ตำแหน่งที่จะให้ของเกิด

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<food>() != null){
            ingredient.Add(other.gameObject);
            UpdateIngredientID();
        }

        if(other.tag == "Pound" && ingredient != null){
            currentPoundTime++;
            checkPound();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<food>() != null){
            ingredient.Remove(other.gameObject);
        }
    }

    //เช็คการตำ
    void checkPound(){
        if(currentPoundTime >= 10){
            spawnCookingFood();
        }
    }

    //อัพเดต ส่วนประกอบที่อยู่ในภาชนะ
    void UpdateIngredientID(){
        List<int> listIngredient = new List<int>();
        foreach(GameObject n in ingredient){
            listIngredient.Add(n.GetComponent<food>().ID);
        }
        listIngredient.Sort();
        ingredientID = string.Join(",",listIngredient);

        //Debug.Log("Ingredient ID " + ingredientID);
    }

    //Method ไว้สำหรับการ spawn อาหาร 
    void spawnCookingFood(){
        

        Instantiate(menuPrefabManager.foodPrefab[menuCalculation.PoundMenu[ingredientID]],instantiatePosition.position,instantiatePosition.rotation);
        
        foreach(GameObject n in ingredient){
            Destroy(n);
        }
        ingredient = new List<GameObject>(0);
        currentPoundTime = 0;
    }
}
