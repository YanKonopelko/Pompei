using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;

    [SerializeField] private LayerMask _jumpableGround;

    [SerializeField] public float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForce;

    private Animator animator;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<CapsuleCollider2D>();

        animator = gameObject.GetComponent<Animator>();

        _moveSpeed = 2f;
        _maxSpeed = 7f;
        _jumpForce = 20f;

        animator.SetBool("Running", true);
    }

    private void Update()
    {
        /*
        if (_moveSpeed < _maxSpeed)
        {
            _moveSpeed += Time.deltaTime; //ускорение до максимальной скорости
        }
        */

        rb.velocity = new Vector2(_moveSpeed, rb.velocity.y);
        
        if (Input.GetButton("Stop") && IsGrounded())
        {
            if (_moveSpeed > 2.1f)
            {
                _moveSpeed -= Time.deltaTime * 25; //замедление
            }
            rb.velocity = new Vector2(_moveSpeed, rb.velocity.y);
        }

        if (Input.GetButton("Go"))
        {
            if (_moveSpeed < _maxSpeed)
            {
                _moveSpeed += Time.deltaTime * 5; //замедление
            }
            rb.velocity = new Vector2(_moveSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce); //прыжок
            SoundManager.PlaySound(SoundManager.instance.JumpSound);
        }

        /*
        if (Input.GetButton("Drop") && !IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, -_jumpForce);
        }
        */
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, _jumpableGround);
    }
}
