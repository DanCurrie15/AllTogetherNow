using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject, 0.01f);
    }
}
