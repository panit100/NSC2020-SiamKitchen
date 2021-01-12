using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiled : MonoBehaviour
{
    public List<GameObject> ingredient = new List<GameObject>(); // GameObject ส่วนประกอบต่างๆในภาชนะ
    MenuManager menuCalculation = new MenuManager();
    
    public bool readyToCook = false; //พร้อมทำอาหารหรือไม่ ดูจากไฟว่าเปิดหรือยัง
    public string ingredientID; // ID ของส่วนประกอบทั้งหมด

    [SerializeField]
    MenuPrefabManager menuPrefabManager = null;
    [SerializeField]
    Transform instantiatePosition = null; //ตำแหน่งที่จะให้ของเกิด
    
    private void OnTriggerStay(Collider other) {
        if(other.GetComponent<food>() != null && readyToCook){
            other.GetComponent<food>().CookingTimeCalculate();
        
            other.GetComponent<food>().checkStage();
            spawnCookingFood();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<food>() != null){
            ingredient.Add(other.gameObject);
            UpdateIngredientID();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<food>() != null){
            ingredient.Remove(other.gameObject);
            UpdateIngredientID();
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
        foreach(GameObject n in ingredient){
            if(ingredient != null && n.GetComponent<food>().currentStage == food.Ripeness.Raw){
                return;
            }
        }

        Instantiate(menuPrefabManager.foodPrefab[menuCalculation.BoiledMenu[ingredientID]],instantiatePosition.position,instantiatePosition.rotation);
        
        foreach(GameObject n in ingredient){
            Destroy(n);
        }
        ingredient = new List<GameObject>(0);
    }
}
