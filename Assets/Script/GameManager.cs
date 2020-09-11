using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject rewardobj;

    public int stageNum = 0;
    public int isEnemy = 0;
    public int killEnemy = 0;
    public bool fadeInComp = false;
    public bool fadeOutComp = false;
    public bool battle = false;
    public float mana = 3;
    public float maxmana = 3;
    public int[] ability = new int[8];
    public int ATK;
    public int HP = 250;


    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void battleEnd()
    {
        Invoke("reward", 2.0f);
    }
    private void reward()
    {
        rewardobj.SetActive(true);
    }
}
