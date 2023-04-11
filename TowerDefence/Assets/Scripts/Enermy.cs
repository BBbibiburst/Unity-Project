using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    private Transform[] positions;
    private int index = 0;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        positions = WayPoints.position;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnDestroy()
    {
        EnermySpawner.EnermyAlive--;
    }
    private void Move()
    {
        transform.Translate((positions[index].position-transform.position).normalized*Time.deltaTime*speed,Space.World);
        if (Vector3.Distance(positions[index].position , transform.position) <0.2f)
        {
            index++;
            if (index == positions.Length)
            {
                OnArrival();
            }
        }
    }
    void OnArrival()
    {
        Destroy(gameObject);
    }

}
