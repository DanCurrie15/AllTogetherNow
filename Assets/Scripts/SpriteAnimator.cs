using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]
    private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float frameRate = 0.2f;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }
}
