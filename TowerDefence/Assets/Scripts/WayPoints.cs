using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] position;
    public void Awake()
    {
        position = new Transform[transform.childCount];
        for (int i = 0; i < position.Length; i++){
            position[i] = transform.GetChild(i);
        }
    }
}
