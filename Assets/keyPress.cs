using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore5();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore10();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore50();
        }

        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore100();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Minus))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().ClearScore();
        }

    }





}
