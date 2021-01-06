using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Fired : MonoBehaviour
{
    public List<GameObject> ingredient = new List<GameObject>(); // GameObject ส่วนประกอบต่างๆในภาชนะ
    public bool readyToCook = false;
    public string ingredientID; // ID ของส่วนประกอบทั้งหมด

    [SerializeField]
    MenuManager menuManager = null;
    Menu menuCalculation = new Menu();

    private void FixedUpdate() {
        spawnCookingFood();
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

    private void OnTriggerStay(Collider other) {
        if(other.GetComponent<food>() != null && readyToCook){
            other.GetComponent<food>().CookingTimeCalculate();
        
            other.GetComponent<food>().checkStage();
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

    //Method ไว้สำหรับการ spawn อาหาร !!ยังไม่เสร็จ ต้องทำให้ run ครั้งเดียวเมื่ออาหารเสร็จ
    void spawnCookingFood(){
        foreach(GameObject n in ingredient){
            if(ingredient != null && n.GetComponent<food>().currentStage == food.Ripeness.Raw){
                return;
            }
        }

        Instantiate(menuManager.foodPrefab[menuCalculation.CookingMenu[ingredientID]]);
        
        foreach(GameObject n in ingredient){
            Destroy(n);
        }
        ingredientID = null;

        foreach(GameObject n in ingredient){
            if(ingredient != null && n.GetComponent<food>().currentStage == food.Ripeness.Raw){
                
            }
        }
        // print("IngredientID" + ingredientID);
        // print("Cookingmenu" + menuCalculation.CookingMenu[ingredientID]);
        // print("MenuPrefab" + menuManager.foodPrefab[menuCalculation.CookingMenu[ingredientID]]);
    }

    
}
