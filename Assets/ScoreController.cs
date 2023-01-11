using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //TextMesh ProのNamespaceを追加

public class ScoreController : MonoBehaviour
{
    int score = 0;
    //Text textComponent;
    TextMeshProUGUI countText;

    // Start is called before the first frame update
    ///*
    void Start()
    {
        //this.countText =  GameObject.Find("Score_Num").GetComponent<TextMeshProUGUI>();
        //this.countText = GetComponent<TextMeshProUGUI>();
        //countText = GameObject.Find("Score_Num").GetComponent<TextMeshProUGUI>();
        this.countText = GetComponent<TextMeshProUGUI>();
        this.countText.text = score.ToString();
        //countText.text = score.ToString();

    }
    //*/
    /*
    void Start()
    {
        this.textComponent = GameObject.Find("Text").GetComponent<Text>();
        this.textComponent.text =  score.ToString();
    }
    */
    // Update is called once per frame
    void Update()
    {

    }

    //衝突判定のコード内に以下を追記してもらう。
    //スコア+100のとき↓
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore100();
    //スコア+50のとき↓
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore50();
    //スコア+10のとき↓
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore10();
    //スコア+5のとき↓
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore10();


    //スコアリセットの場合はコード内に以下を追記してもらう。
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().ClearScore();

    public void AddScore100()
    {
        this.score += 100;
        //this.textComponent.text = score.ToString();
        this.countText.text = score.ToString();
    }

    public void AddScore50()
    {
        this.score += 50;
        //this.textComponent.text = score.ToString();
        this.countText.text = score.ToString();
    }

    public void AddScore10()
    {
        this.score += 10;
        //this.textComponent.text = score.ToString();
        this.countText.text = score.ToString();
    }

    public void AddScore5()
    {
        this.score += 5;
        //this.textComponent.text = score.ToString();
        this.countText.text = score.ToString();
    }



    //スコアをクリアする関数
    public void ClearScore()
    {
        this.score = 0;
        //this.textComponent.text = score.ToString();
        this.countText.text = score.ToString();
    }

}