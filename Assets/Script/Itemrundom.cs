using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemrundom : MonoBehaviour
{
    public GameObject Item;
    public GameObject stone;
    GameObject Field;
    field script;
    public int[,] field_tile;

    // Start is called before the first frame update
    void Start()
    {
        Field = GameObject.Find("Field");
        script = Field.GetComponent<field>();
    }

    // Update is called once per frame
    void Update()
    {
        int[,] field_tile = script.tile;
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(Item,new Vector2(Random.Range(1,4),Random.Range(1,4)),Quaternion.identity);

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            
            
            if (field_tile[2, 3] == script.MyField)
            {
                script.createStone = true;
                field_tile[2, 3] = script.building;
                Instantiate(stone, new Vector2(2, 3), Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            field_tile[2, 3] = script.building;
        }
    }
}
