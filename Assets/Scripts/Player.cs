using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jump;
    public Animator anim;
    public SpriteRenderer sprite;

    private float move;
    private bool isOnFloor;
    private bool isMoving;
    private AudioSource jumpSound;

    void Start()
    {
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            rb.AddForce(new Vector2(rb.linearVelocityX, jump));
            isOnFloor = false;
            jumpSound.Play();
        }

        if (move > 0)
        {
            isMoving = true;
            sprite.flipX = false;
        }
        else if (move < 0)
        {
            isMoving = true;
            sprite.flipX = true;
        }
        else
        {
            isMoving = false;
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isOnFloor", isOnFloor);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnFloor = true;
        }
    }
}
