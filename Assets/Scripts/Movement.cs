using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class Movement : MonoBehaviour
{
    public Transform targetcam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Onclick()
    {
         //targetcam.transform.position.x += Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
    }
}
