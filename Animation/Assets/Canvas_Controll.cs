using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Controll : MonoBehaviour
{
    public Canvas Intro;
    public Canvas InPlay;
    public Canvas Ending;

    // Start is called before the first frame update
    void Start()
    {
        Intro.enabled = true;
        InPlay.enabled = false;
        Ending.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Intro.enabled == true)
            {
                Intro.enabled = false;
                InPlay.enabled = true;
            }
            /*
            if (Ending.enabled == true)
            {
                Ending.enabled = false;
            }*/
        }
    }

    public void gameEnd()
    {
        InPlay.enabled = false;
        Ending.enabled = true;
    }
}
