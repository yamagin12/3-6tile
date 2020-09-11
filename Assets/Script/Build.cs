using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    GameObject Field;
    field script;
    public Text HPText;
    private int HP;
    public int xp;
    public int yp;
    public int[,] field_tile;

    // Start is called before the first frame update
    void Start()
    {
        Field = GameObject.Find("Field");
        script = Field.GetComponent<field>();
        HP = 100;
        SetHPText();
        
        xp = 2;
        yp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetHPText()
    {
        HPText.text = HP.ToString();
    }
    private void zeroHP_or_less()
    {
        int[,] field_tile = script.tile;
        if (xp == 1 || xp ==2|| xp==3)
        {
            field_tile[xp, yp] = script.MyField;
            Destroy(this.gameObject);
        }
        else if (xp == 4 || xp == 5 || xp == 6)
        {
            field_tile[xp, yp] = script.EnemyField;
            Destroy(this.gameObject);
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= 10;
            SetHPText();
            if (HP <= 0) zeroHP_or_less();

        }
    }
}
