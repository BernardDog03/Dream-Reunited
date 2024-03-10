using UnityEngine;
using Fungus;

public class Door : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject laser;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string flowchartOpen;
    [SerializeField] string flowchartClosed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            laser.SetActive(false);
            flowchart.ExecuteBlock(flowchartOpen);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            laser.SetActive(true);
            flowchart.ExecuteBlock(flowchartClosed);
        }
    }

}