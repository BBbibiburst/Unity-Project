using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public float movespeed = 3;
    public float cd = 0.4f;
    private SpriteRenderer sr;
    public Vector3 bulletEularAngle;
    public Sprite[] Tanksprites;
    public GameObject bulletPrefab;
    public GameObject ExplodePrefab;
    private float timeVal;
    private float movetimeVal;
    private int moveDirection = 4;
    // Start is called before the first frame update
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        timeVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (movetimeVal >= cd)
        {
            moveDirection = (int)Random.Range(0, 4);
            movetimeVal = 0;
        }
        else
        {
            movetimeVal += Time.deltaTime;
        }
        if (timeVal >= cd)
        {
            Attack();
            timeVal = 0;
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (moveDirection == 0)
        {
            transform.Translate(Vector3.right * movespeed * 1 * Time.fixedDeltaTime, Space.World);
            sr.sprite = Tanksprites[1];
            bulletEularAngle = new Vector3(0, 0, 90);
        }
        else if (moveDirection == 1)
        {
            transform.Translate(Vector3.right * movespeed * -1 * Time.fixedDeltaTime, Space.World);
            sr.sprite = Tanksprites[3];
            bulletEularAngle = new Vector3(0, 0, -90);
        }
        else if (moveDirection == 2)
        {
            transform.Translate(Vector3.up * movespeed * -1 * Time.fixedDeltaTime, Space.World);
            sr.sprite = Tanksprites[2];
            bulletEularAngle = new Vector3(0, 0, 180);
        }
        else if (moveDirection == 3)
        {
            transform.Translate(Vector3.up * movespeed * 1 * Time.fixedDeltaTime, Space.World);
            sr.sprite = Tanksprites[0];
            bulletEularAngle = new Vector3(0, 0, 0);
        }

    }
    private void Attack()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(bulletEularAngle + transform.eulerAngles));
    }
    private void Die()
    {
        Instantiate(ExplodePrefab, transform.position, transform.rotation);
        PlayerManager.Instance.score++;
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Grass":
                break;
            case "Bullet":
                break;
            default:
                moveDirection = (moveDirection+1)%5;
                break;
        }
    }
}
