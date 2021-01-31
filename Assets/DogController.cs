using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public string axis = "Horizontal";
    public float speed = 2f;
    public float jumpPower = 6.5f;
    public bool ground;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    private bool attack;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Ground", ground);

        HandleInputs();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis(axis);

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);

        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        }

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h > 0.1f && gameObject.CompareTag("Pome"))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        if (h < -0.1f )
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (h < -0.1f && gameObject.CompareTag("Pome"))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        HandleAttack();

        ResetValues();
    }

    private void HandleAttack()
    {
        if (attack)
        {
            anim.SetTrigger("Attack");
        }   
    }

    private void ResetValues()
    {
        attack = false;
    }

    private void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !gameObject.CompareTag("Pome") && ground)
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && gameObject.CompareTag("Pome") && ground)
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            attack = true;
        }
    }
}
