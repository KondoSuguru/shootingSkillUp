using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private GameObject fadePanel;
    private Fade fade;
    private bool isFadeStay;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel = transform.GetChild(transform.childCount - 1).gameObject;
        fade = fadePanel.GetComponent<Fade>();
        fade.FadeInStart();

        isFadeStay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fade.IsFadeIn() && Input.GetKeyUp(KeyCode.Space))
        {
            fade.FadeOutStart();
            isFadeStay = true;
        }

        if (isFadeStay && !fade.IsFadeOut())
        {
            SceneManager.LoadScene("Kondo");
        }
    }
}
