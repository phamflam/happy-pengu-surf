using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//player controlling
// https://github.com/Chaker-Gamra/Endless-Runner-Game/blob/master/Assets/Scripts/Player/PlayerController.cs - modified by Lynn Pham 
public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float speed;
    public float forwardSpeed; //normal speed
    public float maxSpeed;
    public float boostedSpeed;
    public float cooldownSpeed;
    public float cooldownJump;
    private int disiredLane = 1; //0 left 2 right
    public float laneDistance = 4; //distance between 2 lanes
    public float jumpForce;
    public float jump;
    public float jumpBoost;
    public float gravity= -20;
    public Animator animator;
    private bool isSliding;

    void Start()
    {
        forwardSpeed = speed;
        controller = GetComponent<CharacterController>();

    }
    void Update()
    {
        if (!PlayerManager.isStarted)
            return;

        if(forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;
            
        animator.SetBool("isStarted", true);

        direction.z = forwardSpeed;

        if (controller.isGrounded)
        {
            //direction.y = -1; useless
               //if (Input.GetKeyDown(KeyCode.UpArrow))
               if(SwipeManager.swipeUp)
               {
                    Jump();
                    animator.SetBool("isGrounded", false);
            } 
        }
        else //add gravity when in jump
        {
            
            direction.y += gravity * Time.deltaTime;
            animator.SetBool("isGrounded", true);
        }
        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }
        //input 
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        if(SwipeManager.swipeRight)
        {
            disiredLane++;
            if (disiredLane == 3)
                disiredLane = 2;
        }

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        if (SwipeManager.swipeLeft)
        {
            disiredLane--;
            if (disiredLane == -1)
                disiredLane = 0;
        }

        //calc new position
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (disiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (disiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        };

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if(moveDir.sqrMagnitude < diff.sqrMagnitude)
            {
                controller.Move(moveDir);
            }
            else
            {
                controller.Move(diff);
            }
        }
          
        //move player
        controller.Move(direction * Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.CompareTag("Obstacle"))
        {
            animator.SetTrigger("Dead");
            StartCoroutine(PlayDeath());
            //PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("gameover");
        }
      
    }
    //events while player is running
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            forwardSpeed = boostedSpeed;
            StartCoroutine("SpeedDuration");
        }
        if (other.CompareTag("JumpPad"))
        {
            jumpForce = jumpBoost;
            StartCoroutine("JumpDuration");
        }
    }

    //Durations when triggered
    IEnumerator SpeedDuration()
    {
        yield return new WaitForSeconds(cooldownSpeed);
        forwardSpeed = speed;
    }
    IEnumerator JumpDuration()
    {
        yield return new WaitForSeconds(cooldownJump);
        jumpForce = jump;
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }

    private IEnumerator PlayDeath()
    {
        yield return new WaitForSeconds(0.2f);
        PlayerManager.gameOver = true;
    }
}
