using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float timer = 2.0f;
    private float xp;
    public bool Enemybullet;
    public float BulletSpeed = 0.1f;
    public int ATK = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(BulletSpeed　+ Time.deltaTime , 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Enemybullet)
        {


            if (collision.gameObject.CompareTag("build"))
            {
                Debug.Log("建物に当たった");
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("敵に当たった");
                Destroy(this.gameObject);
            }
        }
        if (Enemybullet)
        {

            if (collision.gameObject.CompareTag("build"))
            {
                Debug.Log("建物に当たった");
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("敵の弾が当たった");
                Destroy(this.gameObject);

            }
        }
    }
}
