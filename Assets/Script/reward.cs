using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class Powerup
{
    public void plusATK(int PowerUpATK)
    {
        GameManager.instance.ATK += PowerUpATK;
    }

}



public class reward : MonoBehaviour
{
    private int[] drow = new int[3];
    private int select;
    private int r;
    public Text[] ButtonText = new Text[3];
    private string cardText;
    private bool SelectItem = false;
    Powerup powerup = new Powerup();
    public Dictionary<int, string> card = new Dictionary<int, string>();


    // Soupdard befhe first e temetart is frat calle

    void Start()
    {
        
        card[0] = "攻撃力+10";
        card[1] = "マナコスト-10";
        card[2] = "マナコスト-20 攻撃力-10";
        card[3] = "吸収率+1";
        card[4] = "二回攻撃 + マナコスト+50";
        card[5] = "回復+50";
        
        Debug.Log("-------------------");
        Debug.Log(card.Count);
        int max = card.Count;
        var ary = Enumerable.Range(0, 6).OrderBy(n => Guid.NewGuid()).Take(5).ToArray();

        for (int s = 0; s < ary.Length; s++)
        {
            Debug.Log(s);
            if (r <= 2)
            {
                Debug.Log("R:" + r + "| S:" + s);
                ButtonText[r].text = card[s];
                r++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PushButton0()
    {
        
        select = 0;
        

    }
    public void PushButton1()
    {
        select = 1;
    }
    public void PushButton2()
    {
        select = 2;
    }

    public void Card()
    {



        //switch (drow[select])
        //{
        //    case 0:
        //        cardText = "ATK + 10";

        //        if (SelectItem)
        //        {

        //            Powerup.plusATK(10);
        //        }
        //        break;
        //    case 1:
        //        cardText = ("マナコスト-10");
        //        if (SelectItem)
        //        {

        //        }
        //        break;
        //    case 2:
        //        cardText = ("マナコスト-20、攻撃力-20");
        //        if (SelectItem)
        //        {

        //        }
        //        break;
        //    case 3:
        //        cardText = ("マナ吸収率+1");
        //        if (SelectItem)
        //        {

        //        }
        //        break;
        //    case 4:
        //        cardText = ("二回攻撃、マナコスト+50");
        //        if (SelectItem)
        //        {

        //        }
        //        break;
        //    case 5:
        //        cardText = ("回復+50");
        //        if (SelectItem)
        //        {

        //        }
        //        break;

        //}
    }

}
