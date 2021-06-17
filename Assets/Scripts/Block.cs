using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void Start()
    {
        BlockManager.Instance.AddBlock(this);
    }

    private void OnDisable()
    {
        BlockManager.Instance.RemoveBlock(this);
    }
}
