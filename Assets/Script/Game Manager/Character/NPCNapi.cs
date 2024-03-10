using UnityEngine;

public class NPCNapi : MonoBehaviour
{
    [SerializeField] Animator animator;
    public enum DirectionAnimation {Up, Down, Left, Right}
    [SerializeField] DirectionAnimation directionAnimation;
    
    void Start ()
    {
        CheckAnimationBool();
    }

    private void CheckAnimationBool()
    {
        if (directionAnimation == DirectionAnimation.Up)
        {
            PlayIdleUpAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Down)
        {
            PlayIdleDownAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Left)
        {
            PlayIdleLeftAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Right)
        {
            PlayeIdleRightAnimation();
        }
    }

    private void PlayIdleUpAnimation()
    {
        SetAnimatorBool("isUp", true);
    }
    private void PlayIdleDownAnimation()
    {
        SetAnimatorBool("isDown", true);
    }
    private void PlayIdleLeftAnimation()
    {
        SetAnimatorBool("isLeft", true);
    }
    private void PlayeIdleRightAnimation()
    {
        SetAnimatorBool("isRight", true);
    }

    private void SetAnimatorBool(string animationName, bool valueAnimation)
    {
        animator.SetBool(animationName, valueAnimation);
    }
}
