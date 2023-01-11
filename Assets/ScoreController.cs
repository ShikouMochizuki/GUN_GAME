using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int score = 0;
    Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = GameObject.Find("Text").GetComponent<Text>();
        this.textComponent.text =  score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        this.score += 10;
        this.textComponent.text = score.ToString();
    }

    //衝突判定のコード内に以下を追記してもらう。
    //GameObject.Find("ScoreGUI").GetComponent<ScoreController>().AddScore();

    //スコアをクリアする関数
    public void ClearScore()
    {
        this.score = 0;
        this.textComponent.text = score.ToString();
    }

}