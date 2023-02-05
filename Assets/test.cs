using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.gameObject.transform.position += new Vector3(0, -0.1f, 0);
        }
        else
        {
            this.gameObject.transform.position += new Vector3(0, 0.1f, 0);

        }
        if (Input.GetKey(KeyCode.Return)) {
            GameState.State = GameState.COUNT_DOWN;
            SceneManager.LoadScene("DevelopPlayer");
		}

    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("hit");
    }

}
