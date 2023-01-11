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
            GameObject.Find("ScoreGUI").GetComponent<ScoreController>().AddScore();
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Find("ScoreGUI").GetComponent<ScoreController>().ClearScore();
        }

    }





}
