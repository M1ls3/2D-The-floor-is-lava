using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float acceleration;
    public float impulseY;
    public int jumpTimer;
    private float speadX;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumped;
    private bool isDead;
    private bool isBonus;
    private Vector2 startPos;
    //private Thread task = new Thread(() => Timer(jumpTimer));


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        isJumped = false;
        isBonus = false;
        startPos = transform.position;
    }


    async void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speadX = -acceleration;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speadX = +acceleration;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isJumped)
        {
            isJumped = true;
            Debug.Log("Jump");
            rb.AddForce(new Vector2(0, impulseY * 1000000), ForceMode2D.Impulse);
            await Timer(jumpTimer);
            isJumped = false;
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
    private static async Task Timer(int time)
    {
        Debug.Log($"Wait {time * 1000} sec.");
        await Task.Delay(time);
    }
}
