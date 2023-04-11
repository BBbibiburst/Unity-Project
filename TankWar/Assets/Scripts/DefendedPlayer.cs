using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendedPlayer : MonoBehaviour
{
    public float movespeed = 3;
    public float cd = 0.4f;
    private SpriteRenderer sr;
    public Vector3 bulletEularAngle;
    public Sprite[] Tanksprites;
    public GameObject bulletPrefab;
    public GameObject ExplodePrefab;
    public GameObject DefendPrefab;
    private float timeVal;
    private float DefendTimeVal = 3;
    private bool isDefended = true;
    // Start is called before the first frame update
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        isDefended = true;
    }
    void Start()
    {
        timeVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isDefended)
        //{
        //    DefendPrefab.SetActive(true);
        //    DefendTimeVal -= Time.deltaTime;
        //    if (DefendTimeVal <= 0)
        //    {
        //        DefendPrefab.SetActive(false);
        //        isDefended = false;
        //    }
        //}
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
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * movespeed * h * Time.fixedDeltaTime, Space.World);
        if (h > 0)
        {
            sr.sprite = Tanksprites[1];
            bulletEularAngle = new Vector3(0, 0, -90);
        }
        else if (h < 0)
        {
            sr.sprite = Tanksprites[3];
            bulletEularAngle = new Vector3(0, 0, 90);
        }
        if (h != 0) return;
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * movespeed * v * Time.fixedDeltaTime, Space.World);
        if (v > 0)
        {
            sr.sprite = Tanksprites[0];
            bulletEularAngle = new Vector3(0, 0, 0);
        }
        else if (v < 0)
        {
            sr.sprite = Tanksprites[2];
            bulletEularAngle = new Vector3(0, 0, 180);
        }
    }
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(bulletEularAngle + transform.eulerAngles));
        }
    }
    private void Die()
    {
        if (isDefended)
        {
            return;
        }
        Instantiate(ExplodePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
