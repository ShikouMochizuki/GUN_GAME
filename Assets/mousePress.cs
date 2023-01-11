using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mousePress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore10();
        }

        if (Input.GetMouseButtonDown(2))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore100();
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().ClearScore();
        }

    }





}
