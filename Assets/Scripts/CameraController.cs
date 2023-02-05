using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        dir = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * dir;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
}
