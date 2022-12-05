using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 10)]
    public float DeadSecond = 3f;
    [Range(0, 200)]
    public float Speed = 100f;

    public Vector3 StartPos { get; set; }
    public Vector3 TargetPos { get; set; }

    public void Init(Vector3 startPos, Vector3 targetPos)
    {
        StartPos = startPos;
        TargetPos = targetPos;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float time = 0f;
        transform.position = StartPos;
        var vec = (TargetPos - StartPos).normalized;
        while(time < DeadSecond)
        {
            time += Time.deltaTime;
            transform.position += vec * Speed * Time.deltaTime;
            yield return null;
        }
        Object.Destroy(gameObject);
    }

    private void OnMouseUpAsButton()
    {
        _player.ShotBullet(transform.position);
    }
}
