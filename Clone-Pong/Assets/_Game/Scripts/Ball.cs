using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Min(1)]//Valor máximo da bola
    private const int maxVelocity = 9;
    private Rigidbody2D rigid;

    private const float force = 240.0f;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }


    void FixedUpdate()
    {
        //Condição para a bola nunca parar, eixo X
        if (Mathf.Abs(rigid.velocity.x) <= 2.0f)
        {
            rigid.AddForce(new Vector2(rigid.velocity.x * 2 * Mathf.Sign(rigid.velocity.x), 0));
        }
        //Condição para a bola nunca execeder o limite, eixo X
        if (rigid.velocity.x >= maxVelocity)
        {
            rigid.velocity = new Vector2(maxVelocity, rigid.velocity.y);
        }

        
        //Condição para a bola nunca parar, eixo Y
        if (Mathf.Abs(rigid.velocity.y) <= 2.0f)
        {
            rigid.AddForce(new Vector2(0, rigid.velocity.y * 2 * Mathf.Sign(rigid.velocity.y)));
        }
        //Condição para a bola nunca execeder o limite, eixo Y
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
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("WallScoreRight"))
        {
            Master.Instance.gameController.AddScore(1);
            Destroy(this.gameObject);
        }
    }

    //Espera 2 segundo para lançar a bola a cada rodada
    private IEnumerator Launch(){

        yield return new WaitForSeconds(2);
        rigid.AddForce(new Vector2(-1 * force, Random.Range(-0.9f, 0.9f) * force));
    }
}
