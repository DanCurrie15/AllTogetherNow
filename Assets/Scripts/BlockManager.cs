using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : Singleton<BlockManager>
{
    public List<Block> ActiveBlocks = new List<Block>();

    public void AddBlock(Block block)
    {
        ActiveBlocks.Add(block);
    }

    public void RemoveBlock(Block block)
    {
        ActiveBlocks.Remove(block);
        if (ActiveBlocks.Count < 1 && GameManager.Instance != null && GameManager.Instance.gameOn)
        {
            GameManager.Instance.GameOver(true);
        }
    }

    private void OnDisable()
    {
        ActiveBlocks.Clear();
    }
}
