using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("hit");
    }

}
