using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite BrokenSprite;
    public GameObject ExplodePrefab;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Die()
    {
        sr.sprite = BrokenSprite;
        PlayerManager.Instance.isdefeated = true;
        Instantiate(ExplodePrefab,transform.position,transform.rotation);
    }
}
