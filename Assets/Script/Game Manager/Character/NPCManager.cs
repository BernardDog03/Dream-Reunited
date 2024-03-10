using UnityEngine;
using Fungus;
public class NPCManager : MonoBehaviour
{
    private bool isExecute;
    private bool isInsideTrigger = false;
    public Flowchart flowchart;
    public string dialogBlock;
    
    [SerializeField] Animator animator;
    [SerializeField] GameObject markNPC;
    public enum MoodNPCMarker{Talk, Sleep}
    [SerializeField]MoodNPCMarker moodNPCMarker; 
    void Update()
    {
        if(isInsideTrigger && (Input.GetKeyUp(KeyCode.F) || Input.GetKeyDown(KeyCode.F)))
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
            markNPC.SetActive(true);
            isInsideTrigger = true;
            animator.SetTrigger("StartMarkAnimation");
            checkAnimationBool();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            markNPC.SetActive(false);
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
    private void checkAnimationBool()
    {
        if(moodNPCMarker == MoodNPCMarker.Talk)
        {
            PlayTalkAnimation();
        }
        else if(moodNPCMarker == MoodNPCMarker.Sleep)
        {
            PlaySleepAnimation();
        }
    }

    
    private void PlayTalkAnimation()
    {
        AnimatorBool("isTalk", true);
    }
    private void PlaySleepAnimation()
    {
        AnimatorBool("isSleep", true);
    }
    private void AnimatorBool(string animationName, bool valueAnimation)
    {
        animator.SetBool(animationName, valueAnimation);
    }
}