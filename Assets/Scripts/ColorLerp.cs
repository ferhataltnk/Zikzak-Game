using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    MeshRenderer cubeMesh;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;

    int colorIndex = 0;
    float t = 0f;
    int length;

    void Start()
    {
        cubeMesh = GetComponent<MeshRenderer>();
        length = myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        cubeMesh.material.color = Color.Lerp(cubeMesh.material.color,myColors[colorIndex],lerpTime*Time.deltaTime);
        t = Mathf.Lerp(t, 1f,lerpTime*Time.deltaTime);

        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= length) ? 0 : colorIndex;
        }
    }
}
