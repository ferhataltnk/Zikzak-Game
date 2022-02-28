using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
  

  
    void Update()
    {
        this.transform.Rotate(0,0,75*Time.deltaTime);
    }

    
}
