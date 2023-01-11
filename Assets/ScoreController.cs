using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //TextMesh Pro��Namespace��ǉ�

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

    //�Փ˔���̃R�[�h���Ɉȉ���ǋL���Ă��炤�B
    //�X�R�A+100�̂Ƃ���
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore100();
    //�X�R�A+50�̂Ƃ���
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore50();
    //�X�R�A+10�̂Ƃ���
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore10();
    //�X�R�A+5�̂Ƃ���
    //GameObject.Find("ScoreGUI/Score_Num").GetComponent<ScoreController>().AddScore10();


    //�X�R�A���Z�b�g�̏ꍇ�̓R�[�h���Ɉȉ���ǋL���Ă��炤�B
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



    //�X�R�A���N���A����֐�
    public void ClearScore()
    {
        this.score = 0;
        //this.textComponent.text = score.ToString();
        this.countText.text = score.ToString();
    }

}