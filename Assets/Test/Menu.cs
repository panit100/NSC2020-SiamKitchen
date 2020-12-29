using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    Dictionary<List<int>,int> menu = new Dictionary<List<int>, int>()
                                        {
                                            {new List<int>(){1,2,3},1}
                                        };


    List<int> input = new List<int>(){1,2,3};

  



    private void Update() {
        Debug.Log(input[0]);
        Debug.Log(input[1]);
        Debug.Log(input[2]);
    }
}