using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isdead = false;
    public bool isdefeated;
    public int life = 3;
    public int score = 0;
    private static PlayerManager instance;
    public GameObject BornPrefab;

    public static PlayerManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead)
        {
            recover();
        }
    }
    private void recover()
    {
        if (life < 0)
        {
            //ÓÎÏ·½áÊø
        }
        else
        {
            life--;
            GameObject go = Instantiate(BornPrefab,new Vector3(11,6,0),Quaternion.identity);
            go.GetComponent<Born>().CreatePlayer = true;
            isdead = false;
        }
    }
}
