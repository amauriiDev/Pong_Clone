using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Min(1)]
    private const int maxVelocity = 9;
    private Rigidbody2D rigid;

    [SerializeField]
    private float force = 4.0f;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }


    void FixedUpdate()
    {
        if (Mathf.Abs(rigid.velocity.x) <= 2.0f)
        {
            rigid.AddForce(new Vector2(rigid.velocity.x * 2 * Mathf.Sign(rigid.velocity.x), 0));
        }
        if (rigid.velocity.x >= maxVelocity)
        {
            rigid.velocity = new Vector2(maxVelocity, rigid.velocity.y);
        }

        if (Mathf.Abs(rigid.velocity.y) <= 2.0f)
        {
            rigid.AddForce(new Vector2(0, rigid.velocity.y * 2 * Mathf.Sign(rigid.velocity.y)));
        }
        if (rigid.velocity.y >= maxVelocity)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WallScoreLeft"))
        {
            Master.Instance.gameController.AddScore(0);
        }
        if (other.gameObject.CompareTag("WallScoreRight"))
        {
            Master.Instance.gameController.AddScore(1);
        }
    }

    private IEnumerator Launch(){

        yield return new WaitForSeconds(3);
        rigid.AddForce(new Vector2(-1 * force, Random.Range(-0.7f, 0.7f) * force));
    }
}
