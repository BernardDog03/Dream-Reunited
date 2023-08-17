using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.EventSystems;

public class MainCharacterManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveDuration;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        //WalkUp
        if (Input.GetKey(KeyCode.W) || Input.GetKey(key: KeyCode.UpArrow))
        {
            PlayWalkUp();
            direction += Vector2.up;
        }
        //IdleUp
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(key: KeyCode.UpArrow))
        {
            PlayIdleUp();
        }
        //WalkLeft
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            PlayWalkLeft();
            direction += Vector2.left;
        }
        //IdleLeft
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayIdleLeft();
        }
        //WalkDown
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            PlayWalkDown();
            direction += Vector2.down;
        }
        //IdleDown
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayIdleDown();
        }
        //WalkRight
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            PlayWalkRight();
            direction += Vector2.right;
        }
        //IdleRight
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayIdleRight();
        }

        if(direction != Vector2.zero)
        {
            Vector2 targetPosition = rb.position + direction * moveDistance; 
            rb.DOMove(targetPosition, moveDuration);
        }
    }


    private void PlayIdleDown()
    {
        AnimatorBool("isWalkDown", false);
    }
    private void PlayWalkDown()
    {
        AnimatorBool("isWalkDown", true);
        AnimatorBool("isWalkUp", false);
        AnimatorBool("isWalkLeft", false);
        AnimatorBool("isWalkRight", false);
    }
    private void PlayIdleLeft()
    {
        AnimatorBool("isWalkLeft", false);
    }
    private void PlayWalkLeft()
    {
        AnimatorBool("isWalkDown", false);
        AnimatorBool("isWalkUp", false);
        AnimatorBool("isWalkLeft", true);
        AnimatorBool("isWalkRight", false);
    }
    private void PlayIdleUp()
    {
        AnimatorBool("isWalkUp", false);
    }
    private void PlayWalkUp()
    {
        AnimatorBool("isWalkDown", false);
        AnimatorBool("isWalkUp", true);
        AnimatorBool("isWalkLeft", false);
        AnimatorBool("isWalkRight", false);
    }
    private void PlayIdleRight()
    {
        AnimatorBool("isWalkRight", false);
    }
    private void PlayWalkRight()
    {
        AnimatorBool("isWalkDown", false);
        AnimatorBool("isWalkUp", false);
        AnimatorBool("isWalkLeft", false);
        AnimatorBool("isWalkRight", true);
    }
    private void AnimatorBool(string animationName, bool valueAnimation)
    {
        animator.SetBool(animationName, valueAnimation);
    }
}
