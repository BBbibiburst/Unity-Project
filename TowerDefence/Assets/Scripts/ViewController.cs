using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public float speed = 1;
    public float mousespeed = 1;
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float mouse = Input.GetAxisRaw("Mouse ScrollWheel");
        transform.Translate(new Vector3(h*speed, mouse*mousespeed, v*speed) * Time.deltaTime, Space.World);
    }
}
