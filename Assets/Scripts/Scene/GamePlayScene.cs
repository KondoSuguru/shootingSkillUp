using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayScene : MonoBehaviour
{
    private GameObject fadePanel;
    private Fade fade;
    private bool isGameOver;
    private bool isClear;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel = GameObject.FindGameObjectWithTag("FadePanel");
        fade = fadePanel.GetComponent<Fade>();
        fade.FadeInStart();

        isGameOver = false;
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isClear && !fade.IsFadeOut())
        {
            SceneManager.LoadScene("Clear");
        }
        if(isGameOver && !fade.IsFadeOut())
        {
            SceneManager.LoadScene("GameOver");           
        }
    }

    public void GameOver()
    {
        if (isClear)
            return;
        fade.FadeOutStart();
        isGameOver = true;
    }

    public void Clear()
    {
        if (isGameOver)
            return;
        fade.FadeOutStart();
        isClear = true;       
    }
}
