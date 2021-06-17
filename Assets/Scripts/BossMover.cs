using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    private bool isMovingDown = true;
    private bool isMovingRight = true;
    public float minX;
    public float maxX;
    private float currentX;
    public float minY;
    public float maxY;
    private float yIncrement = 1f;
    private float currentY;
    private float xIncrement;
    public float speedFactor = 100;
    private float musicControl;

    private void Update()
    {
        xIncrement = speedFactor * Time.deltaTime;// * musicControl.Tempo * Time.deltaTime;
        if (isMovingRight && isMovingDown)
        {
            currentX += xIncrement;
            if (currentX < maxX)
            {
                MoveInvaders(xIncrement, 0);
                if (currentY < minY)
                {
                    ChangeDirectionVert();
                }
            }            
            else
            {
                ChangeDirectionHort();
            }
        }
        else if(!isMovingRight && isMovingDown)
        {
            currentX -= xIncrement;
            if (currentX > minX)
            {
                MoveInvaders(-xIncrement, 0);
                if (currentY < minY)
                {
                    ChangeDirectionVert();
                }
            }            
            else
            {
                ChangeDirectionHort();
            }
        }
        else if(isMovingRight && !isMovingDown)
        {
            currentX += xIncrement;
            if (currentX < maxX)
            {
                MoveInvaders(xIncrement, 0);
                if (currentY > maxY)
                {
                    ChangeDirectionVert();
                }
            }            
            else
            {
                ChangeDirectionHort();
            }
        }
        else
        {
            currentX -= xIncrement;
            if (currentX > minX)
            {
                MoveInvaders(-xIncrement, 0);
                if (currentY > maxY)
                {
                    ChangeDirectionVert();
                }
            }            
            else
            {
                ChangeDirectionHort();
            }
        }
    }

    private void MoveInvaders(float x, float y)
    {
        this.transform.Translate(x, y, 0);
    }

    private void ChangeDirectionHort()
    {
        isMovingRight = !isMovingRight;
        if (isMovingDown)
        {
            MoveInvaders(0, -yIncrement);
            currentY -= yIncrement;
        }
        else
        {
            MoveInvaders(0, yIncrement);
            currentY += yIncrement;
        }        
    }

    private void ChangeDirectionVert()
    {
        isMovingDown = !isMovingDown;
    }
}
