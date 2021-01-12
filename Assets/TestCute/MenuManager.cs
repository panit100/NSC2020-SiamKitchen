using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager
{
    // นำ ingredientID มาใช้เพื่อหา ID ของอาหารที่กำลังจะทำ
    // ID ส่วนประกรอบ : 1 = กุ้ง , 2 = กระเพราะ
    // {ส่วนประกรอบ , อาหารที่จะออกมา}

    //สำหรับทอด
    public Dictionary<string,int> FiredMenu = new Dictionary<string, int>() 
    {
        {"1,2",3} //Test
    };

    //สำหรับตำ
    public Dictionary<string,int> PoundMenu = new Dictionary<string, int>() 
    {
        {"1,2",3} //Test
    };

    //สำหรับต้ม
    public Dictionary<string,int> BoiledMenu = new Dictionary<string, int>() 
    {
        {"1,2",3} //Test
    };
}