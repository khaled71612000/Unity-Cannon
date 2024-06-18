using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    MeshRenderer cubeMeshRenderer;
    [SerializeField] [Range(1f, 5f)] float lerpTime;
    [SerializeField] Color[] myColor;
    int colorIndex;
    float t;

    void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //change to current lerp color from uer color using delta time multi by time chosen
        cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color , myColor[colorIndex], lerpTime * Time.deltaTime);
        //lerp time from 0 to 1 
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        //when timme is 1 add index then reset if limit
        if(t > 0.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= myColor.Length) ? 0 : colorIndex;
        }
    }
}
