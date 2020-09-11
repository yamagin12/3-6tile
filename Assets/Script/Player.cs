using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameObject Field;
    field script;
    public GameObject thunder;
    Spell Spellscript;

    public GameObject Bullet;
    public Text HPText;
    Bullet BulletScript;


    public int xp = 1;
    public int yp = 1;

    public int[,] field_tile;


    // Start is called before the first frame update
    void Start()
    {
        Field = GameObject.Find("Field");
        script = Field.GetComponent<field>();
        Spellscript = thunder.GetComponent<Spell>();
        SetHPText();
    }

    
    // Update is called once per frame
    void Update()
    {
        int[,] field_tile = script.tile;
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (field_tile[xp , yp + 1] == script.MyField)
            {
                field_tile[xp,yp] = script.MyField;
                yp += 1 ;
                field_tile[xp, yp] = script.Player;
                tile_point();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (field_tile[xp, yp - 1] == script.MyField)
            {
                field_tile[xp, yp] = script.MyField;
                yp -= 1;
                field_tile[xp, yp] = script.Player;
                tile_point();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (field_tile[xp + 1, yp] == script.MyField)
            {
                field_tile[xp, yp] = script.MyField;
                xp += 1;
                field_tile[xp, yp] = script.Player;
                tile_point();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (field_tile[xp - 1, yp ] == script.MyField)
            {
                field_tile[xp, yp] = script.MyField;
                xp -= 1;
                field_tile[xp, yp] = script.Player;
                tile_point();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone =Instantiate(Bullet, new Vector2(xp + 0.5f, yp), Quaternion.identity);
            
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            
            
            Instantiate(thunder, new Vector2(xp + 2, yp), Quaternion.identity);
        }   

        this.gameObject.transform.position = new Vector3(xp, yp, 0);
    }
    void tile_point()
    {
        
        Debug.Log(xp + "," + yp);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("何かが侵入");
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("afdad");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyAttack"))
        {
            BulletScript = collision.GetComponent<Bullet>();
            GameManager.instance.HP -= BulletScript.ATK;
            SetHPText();
            if (GameManager.instance.HP <= 0) zeroHP_or_less();
        }
    }
    void SetHPText()
    {
        HPText.text = GameManager.instance.HP.ToString();
    }
    private void zeroHP_or_less()
    {
        Destroy(this.gameObject);
        
        Destroy(this);
    }
}
