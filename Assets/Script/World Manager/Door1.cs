using UnityEngine;
using Fungus;

public class Door1 : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string flowchartOpen;
    [SerializeField] string flowchartClosed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            flowchart.ExecuteBlock(flowchartOpen);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            flowchart.ExecuteBlock(flowchartClosed);
        }
    }

}