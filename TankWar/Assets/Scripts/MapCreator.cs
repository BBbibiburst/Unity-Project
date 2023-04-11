using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject[] GameObjects;
    public TextAsset txtReader;
    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateMap()
    {
        string txt = txtReader.text;
        string[] maps = txt.Split('\n');
        for(int i = 0; i <= 26; i++)
        {
            for(int j = 0; j <= 18; j++)
            {
                if (maps[j][i] == '7') continue;
                createItem(GameObjects[(int)(maps[j][i]-'0')],new Vector3(-13+i,9-j,0),Quaternion.identity);
            }
        }
    }
    GameObject createItem(GameObject go,Vector3 position,Quaternion rotation)
    {
        GameObject item = Instantiate(go,position,rotation);
        item.transform.SetParent(gameObject.transform);
        return item;
    }
}
