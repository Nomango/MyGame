using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    [Header("States Check")]
    public bool isGround;
    public bool isJumping;
    public bool canJump;

    [Header("Jump FX")]
    public GameObject jumpFX;
    public GameObject landFX;

    [Header("Attack Settings")]
    public GameObject bombPrefab;
    public float nextAttack = 0;
    public float attackRate;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        PhysicsCheck();
        Movement();
        Jump();
    }

    void CheckInput()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    void Movement()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(hInput * speed, rb.velocity.y);

        if (hInput != 0)
        {
            transform.localScale = new Vector3(hInput, 1, 1);
        }
    }

    void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            canJump = false;
            isJumping = true;
            jumpFX.transform.position = transform.position + new Vector3(0, -0.45f, 0);
            jumpFX.SetActive(true);
        }
    }

    public void Attack()
    {
        if (Time.time > nextAttack)
        {
            Instantiate(bombPrefab, transform.position, bombPrefab.transform.rotation);
            nextAttack = Time.time + attackRate;
        }
    }

    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            rb.gravityScale = 1;
            isJumping = false;
        }
    }

    public void LandFX()
    {
        landFX.SetActive(true);
        landFX.transform.position = transform.position + new Vector3(0, -0.75f, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
