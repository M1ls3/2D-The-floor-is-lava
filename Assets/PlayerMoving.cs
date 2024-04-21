using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
    public float acceleration;
    public float impulseY;
    public int jumpTimer;
    private float speadX;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumped;
    public bool toJump;
    public bool toLeft;
    public bool toRight;
    private bool isDead;
    private bool isBonus;
    private Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        isJumped = false;
        isBonus = false;
        toJump = false;
        toLeft = false;
        toRight = false;
        startPos = transform.position;
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || toLeft) 
        {
            MoveLeft();
            toLeft = false;
        }
        else if (Input.GetKey(KeyCode.D) || toRight)
        {
            MoveRight();
            toRight = false;
        }
        if (((Input.GetKey(KeyCode.Space) || toJump) && isGrounded && !isJumped))
        {
            MoveUp();
        }
        transform.Translate(speadX, 0, 0);
        speadX = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Floor") 
        {
            isGrounded = true; Debug.Log("OnFloor"); 
        }
        if (collision2D.gameObject.tag == "Bonus")
        {
            isGrounded = true; Debug.Log("OnBonus");
        }
        if (collision2D.gameObject.tag == "Finish")
        {
            isGrounded = true; Debug.Log("OnFinish");
        }
        if (collision2D.gameObject.tag == "Lava") 
        {
            transform.position = startPos; 
            Debug.Log("Death"); 
            isDead = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Floor" || collision2D.gameObject.tag == "Bonus") 
        {
            isGrounded = false; Debug.Log("NotFloor"); 
        }
    }
    public void Timer(int time)
    {
        Debug.Log($"Wait {time * 1000} sec.");
        Thread.Sleep(time);
        isJumped = false;
        toJump = false;
    }
    public void Timer()
    {
        int temp = jumpTimer;
        Debug.Log($"Wait {temp * 1000} sec.");
        Thread.Sleep(temp);
        isJumped = false;
        toJump = false;
    }

    public void MoveRight()
    {
        speadX = +acceleration;
    }

    public void MoveLeft()
    {
        speadX = -acceleration;
    }

    public void MoveUp()
    {
        isJumped = true;
        Thread thread = new Thread(() => Timer(jumpTimer));
        Debug.Log("Jump");
        rb.AddForce(new Vector2(0, impulseY * 1000000), ForceMode2D.Impulse);
        thread.Start();
    }
}
