using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class MainCharacterManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float moveDistance;
    [SerializeField] float moveDuration;
    [SerializeField] GameObject panelSetting;
    [SerializeField] GameObject panelMap;
    [SerializeField] OnButtonClick buttonPause;


    [SerializeField] Flowchart flowchart;
    private Rigidbody2D rb;
    private float fixedDeltaTime;
    private bool canMove = true;

    private delegate void pauseChanged();
    private static event pauseChanged OnPauseChanged;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedDeltaTime = Time.fixedDeltaTime;
        OnPauseChanged += HandelPauseChange;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseChanged.Invoke();
        }

        Vector2 direction = Vector2.zero;
        if (canMove)
        {
            //WalkUp
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                PlayWalkUp();
                direction += Vector2.up;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                PlayWalkLeft();
                direction += Vector2.left;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                PlayWalkDown();
                direction += Vector2.down;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                PlayWalkRight();
                direction += Vector2.right;
            }
            if (direction != Vector2.zero)
            {
                Vector2 targetPosition = rb.position + direction * moveDistance * fixedDeltaTime;
                rb.MovePosition(Vector2.Lerp(rb.position, targetPosition, moveDuration));
            }

            //Run character
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDistance = 15;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveDistance = 10;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!panelSetting.activeSelf)
                {
                    panelSetting.SetActive(true);
                    panelMap.SetActive(false);
                    SetCantMove();
                }
                else
                {
                    panelSetting.SetActive(false);
                    panelSetting.SetActive(false);
                    SetCanMove();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            PlayIdleUp();
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayIdleLeft();
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayIdleDown();
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayIdleRight();
        }
    }

    public void SetCanMove()
    {
        canMove = true;
    }

    public void SetCantMove()
    {
        canMove = false;
    }

    public void OpenPauseMenu()
    {
        if (!flowchart.HasExecutingBlocks())
        {
            if (!panelSetting.activeSelf)
            {
                panelSetting.SetActive(true);
                panelMap.SetActive(false);
                SetCantMove();
            }
            else
            {
                panelSetting.SetActive(false);
                panelMap.SetActive(false);
                HandelPauseChange();
                SetCanMove();
            }
        } 
        else if (flowchart.HasExecutingBlocks())
        {
            SetCantMove();
        }
    }

    public void OpenMap()
    {
        if (!flowchart.HasExecutingBlocks())
        {
            if (!panelMap.activeSelf)
            {
                panelSetting.SetActive(false);
                panelMap.SetActive(true);
                SetCantMove();
            }
            else
            {
                panelSetting.SetActive(false);
                panelMap.SetActive(false);
                HandelPauseChange();
                SetCanMove();
            }
        } 
        else if (flowchart.HasExecutingBlocks())
        {
            SetCantMove();
        }
    }

    public void HandelPauseChange()
    {
        if (flowchart != null)
        {
            if (flowchart.HasExecutingBlocks())
            {
                SetCantMove();
            }
            else if (!flowchart.HasExecutingBlocks())
            {
                SetCanMove();
            }
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
