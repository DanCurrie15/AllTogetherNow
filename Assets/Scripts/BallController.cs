using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;

    public float force = 500f;
    public float dir = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Launch();
    }

    public void Launch()
    {
        rb.AddForce(new Vector2(dir, dir) * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OFB"))
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.LoseBall();
        }
        else
        {
            SoundManager.Instance.PlaySoundEffect(SoundEffect.Bounce);
        }
    }
}
