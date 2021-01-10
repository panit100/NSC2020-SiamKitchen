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
    public Dictionary<string,int> CookingMenu = new Dictionary<string, int>() 
    {
        {"1,2",3} //Test
    };
}