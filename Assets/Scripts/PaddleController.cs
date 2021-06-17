using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float minY = -7.5f;
    public float maxY = 7.5f;

    void Update()
    {
        if(GameManager.Instance.gameOn && GameManager.Instance.isBreaker)
        {
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && transform.position.y <= maxY)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && transform.position.y >= minY)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }
        
    }
}
