using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject lastFloor;
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            createFloor();
           
        }
    }

    private void Update()
    {
    }



    public void createFloor ()
    {
        Vector3 yon;

        if (Random.Range(0, 2) == 0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.forward;

        }

        lastFloor = Instantiate(lastFloor, lastFloor.transform.position + yon,lastFloor.transform.rotation);  /*Her seferinde oluşturduğum zemini son zemine eşitliyorum*/

        if (Random.Range(0, 10) == 0)
        {
            lastFloor.transform.GetChild(0).gameObject.SetActive(true);



        }
        else
        {
           lastFloor.transform.GetChild(0).gameObject.SetActive(false);

        }

    }



   
}
