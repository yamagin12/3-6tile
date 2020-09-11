using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public int Manacost;
    public float DestroyTimer = 0.2f;
    public GameObject Player;
    public GameObject spell;
    

    
    Player script;
    //
    // Start is called before the first frame update
    void Start()
    {
        script = Player.GetComponent<Player>();
        Destroy(gameObject, DestroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void　Play()
    {
        Debug.Log("ThunderPlay");
    }
}
