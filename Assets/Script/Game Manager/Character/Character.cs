using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;

    public enum DirectionAnimation{Up, Down, Left, Right, SitLeft, SitRight}
    public DirectionAnimation directionAnimation;

    void Start()
    {
        CheckAnimationBool();
    }

    private void CheckAnimationBool()
    {
        if (directionAnimation == DirectionAnimation.Up)
        {
            PlayeIdleUpAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Down)
        {
            PlayeIdleDownAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Left)
        {
            PlayIdleLeftAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Right)
        {
            PlayIdleRightAnimation();
        }
        else if (directionAnimation == DirectionAnimation.SitLeft)
        {
            PlaySitLeftAnimation();
        }
        else if (directionAnimation == DirectionAnimation.SitRight)
        {
            PlaySitRightAnimation();
        }
    }

    private void PlayeIdleUpAnimation()
    {
        SetAnimatorBool("IsIdleUp", true);
    }
    private void PlayeIdleDownAnimation()
    {
        SetAnimatorBool("IsIdleDown", true);
    }
    private void PlayIdleLeftAnimation()
    {
        SetAnimatorBool("IsIdleLeft", true);
    }
    private void PlayIdleRightAnimation()
    {
        SetAnimatorBool("IsIdleRight", true);
    }
    private void PlaySitLeftAnimation()
    {
        SetAnimatorBool("IsSitLeft", true);
    }
    private void PlaySitRightAnimation()
    {
        SetAnimatorBool("IsSitRight", true);
    }

    private void SetAnimatorBool(string animationName,  bool valueAnimation)
    {
        animator.SetBool(animationName, valueAnimation);
    }
}
