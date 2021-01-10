using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public enum Ripeness {Raw,Done,Burnt}; //ระดับความสุก
    
    
    //public bool isStir = false;
    

    [Header("Cooking Stage")]
    public Ripeness currentStage = Ripeness.Raw; //ระดับความสกปัจจุบัน

    [SerializeField]
    float CookingTime; //เวลาเริ่มทำอาหาร
    [SerializeField]
    float DoneTime = 0; //ตั้งเวลาสุก
    [SerializeField]
    float BurntTime = 0; //ตั้งเวลาไหม้

    [Header("Slice Setting")]
    public bool isSlice = false;
    public GameObject SliceObject = null;

    [Header("Food ID")]
    public int ID;

    private void FixedUpdate() {
        //checkStage();

        if(currentStage == Ripeness.Done){
            print("Done");
            //isStir = true;
            DoneStage();
        }else if(currentStage == Ripeness.Burnt){
            print("Burnt");
            BurntStage();
        }
    }

    //เช็คระดับความสุกจากเวลา
    public void checkStage(){
        if(CookingTime >= DoneTime && CookingTime < BurntTime){
            currentStage = Ripeness.Done;
        }else if(CookingTime >= BurntTime){
            currentStage = Ripeness.Burnt;
        }
    }

    //ตั้งเวลาที่เริ่มทำอาหาร
    public void CookingTimeCalculate(){
        CookingTime += Time.deltaTime * 1f;
    }

    //เปลี่ยนสีอาหารเมื่อสุก
    void DoneStage(){
        Renderer Food = gameObject.GetComponent<Renderer>();
        Food.material.SetColor("_Color",Color.white);
    }

    //เปลี่ยนสีอาหารเมื่อไหม้
    void BurntStage(){
        Renderer Food = gameObject.GetComponent<Renderer>();
        Food.material.SetColor("_Color",Color.red);
    }
    
}
