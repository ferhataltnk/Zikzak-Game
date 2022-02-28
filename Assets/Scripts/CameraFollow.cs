using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 fark;
    [SerializeField] private Transform target;



    private void Start()
    {
        fark = transform.position - target.position;
    }


    private void Update()
    {
        if (BallMovement.dustuMu == false)
        {
            transform.position = target.position + fark;

        }
    }

   
    
}
