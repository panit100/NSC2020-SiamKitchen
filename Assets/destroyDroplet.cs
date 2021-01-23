using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDroplet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyDroplet");
    }
    IEnumerator DestroyDroplet(){
            yield return new WaitForSeconds(2f);
            Destroy(gameObject); 
            //spawn invisible prefab of droplet at bottle's cap
    }
}
