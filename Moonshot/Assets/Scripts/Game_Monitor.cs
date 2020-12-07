using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Monitor : MonoBehaviour
{
    public Text menu_text;
    public Text ui_text;
    public float strokes;
    public GameObject ball;
    private DragShoot drag;

    // Start is called before the first frame update
    void Start()
    {
        drag = ball.GetComponent<DragShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        strokes = drag.strokes;

        ui_text.text = strokes.ToString();
        menu_text.text = strokes.ToString();
    }
}
