using UnityEngine;

public class SwarmMover : MonoBehaviour
{
    float speed = 5f;
    float minX = -24f;
    float maxX = 24f;

    float minY = -7f;
    float maxY = 7f;
    float incrementY = 0.25f;
    bool isMovingDown = true;

    void Start()
    {
        if (transform.position.x < 0)
        {
            speed = speed * -1;
        }
        if (transform.position.y < 0)
        {
            isMovingDown = false;
        }
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x > maxX || transform.position.x < minX)
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.ScoreOrLossPoints(-100);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            SoundManager.Instance.PlaySoundEffect(SoundEffect.Bounce);
            speed = speed * -1;
            if (isMovingDown)
            {
                transform.Translate(0, -incrementY, 0);
                if (transform.position.y < minY)
                {
                    isMovingDown = !isMovingDown;
                }
            }
            else
            {
                transform.Translate(0, incrementY, 0);
                if (transform.position.y > maxY)
                {
                    isMovingDown = !isMovingDown;
                }
            }
        }
    }
}
