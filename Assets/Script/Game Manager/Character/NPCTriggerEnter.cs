using UnityEngine;
using Fungus;

public class NPCTriggerEnter : MonoBehaviour
{
    private bool isExecute;
    private bool isInsideTrigger = false;
    public Flowchart flowchart;
    public string dialogBlock;    
    
    void Update()
    {
        if(isInsideTrigger)
        {
            if(isExecute)
            {
                isExecute = false;
            }
            else
            {
                ExecuteBlock(dialogBlock);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            isInsideTrigger = false;
        }
    }

    private void ExecuteBlock(string blockName)
    {
        Block block = flowchart.FindBlock(blockName);
        if(block != null && !block.IsExecuting())
        {
            flowchart.ExecuteBlock(block);
            isExecute = true;
        }
    }
}
