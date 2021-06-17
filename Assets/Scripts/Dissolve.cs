using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;
    Collider2D boxCollider2D;

    bool isDisolving = false;
    float fade = 1f;

    public bool isBoss = false;
    public GameObject swarm;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        boxCollider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isDisolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {                
                fade = 0f;
                isDisolving = false;
                this.gameObject.SetActive(false);
            }
            material.SetFloat("_Fade", fade);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CannonBall"))
        {
            SoundManager.Instance.PlaySoundEffect(SoundEffect.Explosion);
            isDisolving = true;
            boxCollider2D.enabled = false;
            if (isBoss)
            {
                GameManager.Instance.ScoreOrLossPoints(150);
                Instantiate(swarm, this.transform.position, Quaternion.identity);
            }
            else
            {
                GameManager.Instance.ScoreOrLossPoints(50);
            }
        }
    }
}
