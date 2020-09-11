using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    GameObject Field;
    public GameObject Bullet;
    field script;

    Spell Spellscript;

    bool first = true;

    public Text HPText;
    public int HP;
    public int xp;
    public int yp;
    public int[,] field_tile;
    public int difficult;
    
    //public script;

    //repeat intarval 
    public float Repeat = 2.0f;
    //repeats
    public float Repeats = 0.0f;
    //attack intarval
    public float attackintarval = 3;


    //敵の挙動
    //縦に動く
    public bool verticalmove;
    //横に動く
    public bool Horizontalmove;
    //敵の攻撃
    public bool Enemyattack;

    // Start is called before the first frame update
    public void Start()
    {
        spawnEnemy();
        Field = GameObject.Find("Field");
        script = Field.GetComponent<field>();
        HP = 100;
        SetHPText();

    }
    // Update is called once per frame
    public void Update()
    {

        this.gameObject.transform.position = new Vector3(xp, yp, 0);
        if (first)
        {

            if (GameManager.instance.fadeInComp)
            {
                InvokeRepeating("pattern", 2, Repeat);
                first = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= 10;
            SetHPText();

            
        }
        if (collision.gameObject.CompareTag("Spell"))
        {
            Debug.Log("Spellに当たった");
            Spellscript = collision.GetComponent<Spell>();
            Debug.Log(GameManager.instance.ATK);
            HP -= GameManager.instance.ATK;
            SetHPText();
        }
    }
    void spawnEnemy()
    {
        GameManager.instance.isEnemy++;
        xp = Random.Range(4, 7);
        yp = Random.Range(1, 4);
    }
    void SetHPText()
    {
        HPText.text = HP.ToString();
        if (HP <= 0) zeroHP_or_less();
    }
    private void zeroHP_or_less()
    {
        GameManager.instance.isEnemy--;
        if (GameManager.instance.isEnemy <= 0)
        {
            GameManager.instance.battleEnd();
        }
            
        Destroy(this.gameObject);
        CancelInvoke("pattern");
        Destroy(this);
    }

    public void pattern()
    {
        Repeats++;
        field_tile = script.tile;
        int dice = Random.Range(1, 5);
        if (dice == 1)
        {
            if (field_tile[xp, yp + 1] == script.EnemyField)
            {

                Up();

            }
        }
        if (dice == 2)
        {
            if (field_tile[xp, yp - 1] == script.EnemyField)
            {
                Down();
            }
        }
        if (dice == 3)
        {
            if (field_tile[xp + 1, yp] == script.EnemyField)
            {
                Right();
            }
        }
        if (dice == 4)
        {
            if (field_tile[xp - 1, yp] == script.EnemyField)
            {
                Left();
            }
        }
        if (Enemyattack)
        {
            if (Repeats >= attackintarval)
            {
                attack();
            }
        }
    }
    void attack()
    {
        Repeats = 0;
        GameObject clone = Instantiate(Bullet, new Vector2(xp + -0.5f, yp), Quaternion.identity);
        Debug.Log("敵が球を発射");
    }
    void Up()
    {
        field_tile[xp, yp] = script.EnemyField;
        yp += 1;
        field_tile[xp, yp] = script.Enemy;
    }
    void Down()
    {
        field_tile[xp, yp] = script.EnemyField;
        yp -= 1;
        field_tile[xp, yp] = script.Enemy;
    }
    void Right()
    {
        field_tile[xp, yp] = script.EnemyField;
        xp += 1;
        field_tile[xp, yp] = script.Enemy;
    }
    void Left()
    {
        field_tile[xp, yp] = script.EnemyField;
        xp -= 1;
        field_tile[xp, yp] = script.Enemy;
    }
    
}
