using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float movespeed;
    public bool isPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up*movespeed*Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayers)
                {
                    if(!collision.GetComponent<player>().isDefended)
                        PlayerManager.Instance.isdead = true;
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Enermy":
                if (isPlayers)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            case "Grass":
                break;
            case "River":
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
