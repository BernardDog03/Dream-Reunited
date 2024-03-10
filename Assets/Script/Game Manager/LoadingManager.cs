using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public Animator animator;
    
    //Play Animation Loading
    private void PlayAnimationStartLoading()
    {
        animator.Play("CrossFade_Start");
    }
    private void PlayAnimationEndLoading()
    {
        animator.Play("CrossFade_End");
    }
}
