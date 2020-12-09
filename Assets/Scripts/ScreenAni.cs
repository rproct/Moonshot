using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenAni : MonoBehaviour
{
    public Sprite[] sprites;

    private Image image;
    private int i;
    
    void Awake()
    {
        image = GetComponent<Image>();
        i = 0;
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            image.sprite = sprites[i];
            yield return new WaitForSeconds(0.025f);
            i = (i + 1) % sprites.Length;
        }
    }
}
