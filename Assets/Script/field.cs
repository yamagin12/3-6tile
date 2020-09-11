using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    //100
    public int[,] tile = new int[8,5];
    public int MyField = 101;
    public int EnemyField = 102;
    public int building = 103;
    public int Player = 104;
    public int Enemy = 105;
    public int STOP = 110;                            
    public bool createStone;

    //200
    public GameObject[] buildID = new GameObject[10];
    public GameObject stone;

    // Start is called before the first frame update
    public void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            for(int j = 1;j < 4; j++)
            {
                tile[i, j] = MyField;
                Debug.Log(i + "," + j + ":" + tile[i, j]);
            }
        }
        for (int i = 4; i < 7; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                tile[i, j] = EnemyField;
                Debug.Log(i + "," + j + ":" + tile[i, j]);
            }
        }
        for (int i = 0; i <7;i++)
        {
            tile[i, 4] = STOP;
        }
        for (int i = 0; i < 7; i++)
        {
            tile[i, 0] = STOP;
        }
        for(int i = 0; i < 4; i++)
        {
            tile[0, i] = STOP;
        }
        for (int i = 0; i < 4; i++)
        {
            tile[7, i] = STOP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
