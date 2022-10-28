using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform3 : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-8, 0, 0) * Time.deltaTime);
    }
}