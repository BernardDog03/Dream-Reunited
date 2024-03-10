using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fungus;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Animator animator;
    public enum DirectionAnimation { Up, Down, Left, Right, Phone, SitLeft, SitRight}
    public enum AnimationName { Boy1, Boy2,Boy3, Girl1, Girl2, Male1, Male2, Male3, Male4,
    Male5, Male6, Male7,Female1, Female2, Female3, Female4, Female5, Doctor1, Nurse1, Nurse2, PoliceFemale1, PoliceFemale2,
    PoliceMale1, PoliceMale2}
    [SerializeField] DirectionAnimation directionAnimation;
    [SerializeField] AnimationName animationName;

    private Dictionary<AnimationName, Action> animationMethods = new Dictionary<AnimationName, Action>();

    void Start()
    {
        InitializeAnimationMethods();
        CheckAndRunAnimation();
    }

    private void InitializeAnimationMethods()
    {
        animationMethods[AnimationName.Boy1] = IsBoy1Play;
        animationMethods[AnimationName.Boy2] = IsBoy2Play;
        animationMethods[AnimationName.Boy3] = IsBoy3Play;
        animationMethods[AnimationName.Girl1] = IsGirl1Play;
        animationMethods[AnimationName.Girl2] = IsGirl2Play;
        animationMethods[AnimationName.Male1] = IsMale1Play;
        animationMethods[AnimationName.Male2] = IsMale2Play;
        animationMethods[AnimationName.Male3] = IsMale3Play;
        animationMethods[AnimationName.Male4] = IsMale4Play;
        animationMethods[AnimationName.Male5] = IsMale5Play;
        animationMethods[AnimationName.Male6] = IsMale6Play;
        animationMethods[AnimationName.Male7] = IsMale7Play;
        animationMethods[AnimationName.Female1] = IsFemale1Play;
        animationMethods[AnimationName.Female2] = IsFemale2Play;
        animationMethods[AnimationName.Female3] = IsFemale3Play;
        animationMethods[AnimationName.Female4] = IsFemale4Play;
        animationMethods[AnimationName.Female5] = IsFemale5Play;
        animationMethods[AnimationName.Doctor1] = IsDoctorPlay;
        animationMethods[AnimationName.Nurse1] = IsNurse1Play;
        animationMethods[AnimationName.Nurse2] = IsNursey2Play;
        animationMethods[AnimationName.PoliceFemale1] = IsPoliceFemale1Play;
        animationMethods[AnimationName.PoliceFemale2] = IsPoliceFemale2Play;
        animationMethods[AnimationName.PoliceMale1] = IsPoliceMale1Play;
        animationMethods[AnimationName.PoliceMale2] = IsPoliceMale2Play;
    }

    private void CheckAndRunAnimation()
    {
        if (animationMethods.ContainsKey(animationName))
        {
            animationMethods[animationName].Invoke();
            CheckAnimationBool();
        }
        else Debug.LogWarning("AnimationName not found: " + animationName);
    }

    private void CheckAnimationBool()
    {
        if (directionAnimation == DirectionAnimation.Up)
        {
            PlayIdleUpAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Left)
        {
            PlayIdleLeftAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Down)
        {
            PlayIdleDownAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Right)
        {
            PlayeIdleRightAnimation();
        }
        else if (directionAnimation == DirectionAnimation.Phone)
        {
            PlayOnPhoneAnimation();
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
    private void PlayOnPhoneAnimation()
    {
        SetAnimatorBool("isOnPhone", true);
    }
    private void PlaySitLeftAnimation()
    {
        SetAnimatorBool("isSitLeft", true);
    }
    private void PlaySitRightAnimation()
    {
        SetAnimatorBool("isSitRight", true);
    }

    //Animation Object Name
    private void IsBoy1Play()
    {
        SetAnimatorBool("isBoy1", true);
    }
    private void IsBoy2Play()
    {
        SetAnimatorBool("isBoy2", true);
    }
    private void IsBoy3Play()
    {
        SetAnimatorBool("isBoy3", true);
    }
    private void IsMale1Play()
    {
        SetAnimatorBool("isMale1", true);
    }
    private void IsMale2Play()
    {
        SetAnimatorBool("isMale2", true);
    }
    private void IsMale3Play()
    {
        SetAnimatorBool("isMale3", true);
    }
    private void IsMale4Play()
    {
        SetAnimatorBool("isMale4", true);
    }
    private void IsMale5Play()
    {
        SetAnimatorBool("isMale5", true);
    }
    private void IsMale6Play()
    {
        SetAnimatorBool("isMale6", true);
    }
    private void IsMale7Play()
    {
        SetAnimatorBool("isMale7", true);
    }
    private void IsGirl1Play()
    {
        SetAnimatorBool("isGirl1", true);
    }
    private void IsGirl2Play()
    {
        SetAnimatorBool("isGirl2", true);
    }
    private void IsFemale1Play()
    {
        SetAnimatorBool("isFemale1", true);
    }
    private void IsFemale2Play()
    {
        SetAnimatorBool("isFemale2", true);
    }
    private void IsFemale3Play()
    {
        SetAnimatorBool("isFemale3", true);
    }
    private void IsFemale4Play()
    {
        SetAnimatorBool("isFemale4", true);
    }
    private void IsFemale5Play()
    {
        SetAnimatorBool("isFemale5", true);
    }
    private void IsDoctorPlay()
    {
        SetAnimatorBool("isDoctor1", true);
    }
    private void IsNurse1Play()
    {
        SetAnimatorBool("isNurse1", true);
    }
    private void IsNursey2Play()
    {
        SetAnimatorBool("isNurse2", true);
    }
    private void IsPoliceFemale1Play()
    {
        SetAnimatorBool("isPoliceFemale1", true);
    }
    private void IsPoliceFemale2Play()
    {
        SetAnimatorBool("isPoliceFemale2", true);
    }
    private void IsPoliceMale1Play()
    {
        SetAnimatorBool("isPoliceMale1", true);
    }
    private void IsPoliceMale2Play()
    {
        SetAnimatorBool("isPoliceMale2", true);
    }

    private void SetAnimatorBool(string animationName, bool valueAnimation)
    {
        animator.SetBool(animationName, valueAnimation);
    }
}
