using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    [Header("fade")] public FadeImage fade;

    private bool firstPush = false;
    private bool goNextScene = false;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Canvas/Button").GetComponent<Button>();

        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("SampleScene");
            goNextScene = true;
        }
    }
    public void PressStart()
    {
        if (!firstPush)
        {
            Debug.Log("スタートします");
            fade.StartFadeOut();
            firstPush = true;
        }
        
    }
    public void PressOption()
    {
        Debug.Log("オプションを開きます");
    }
}
