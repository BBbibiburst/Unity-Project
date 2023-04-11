using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject[] EnermyPrefabList;
    public bool CreatePlayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornPlayer", 1f);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BornPlayer()
    {
        if (CreatePlayer)
        {
            Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        }
        else
        {

            Instantiate(EnermyPrefabList[Random.Range(0,EnermyPrefabList.Length)], transform.position, Quaternion.identity);
        }
    } 
}
