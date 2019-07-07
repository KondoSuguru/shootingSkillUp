using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float fadeSpeed;
    float r, g, b, a;
    Image fadePanel;
    bool isFadeIn;
    bool isFadeOut;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel = GetComponent<Image>();
        r = fadePanel.color.r;
        g = fadePanel.color.g;
        b = fadePanel.color.b;
        a = fadePanel.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            FadeInUpdate();
        }
        if (isFadeOut)
        {
            FadeOutUpdate();
        }
    }

    void FadeInUpdate()
    {
        a -= fadeSpeed;
        fadePanel.color = new Color(r, g, b, a);
        if (a <= 0)
            isFadeIn = false;
    }

    void FadeOutUpdate()
    {
        a += fadeSpeed;
        fadePanel.color = new Color(r, g, b, a);
        if (a >= 1)
            isFadeOut = false;
    }


    public bool IsFadeIn()
    {
        return isFadeIn;
    }

    public bool IsFadeOut()
    {
        return isFadeOut;
    }

    public void FadeInStart()
    {
        isFadeIn = true;
    }

    public void FadeOutStart()
    {
        isFadeOut = true;
    }
}
