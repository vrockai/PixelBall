using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    Animator animator;
    Rigidbody2D myRigidbody;
    Rigidbody2D ballRigidbody;
    Collider2D myCollider;
    Collider2D ballCollider;

    SpriteRenderer mySprite;
    bool facingRight;

    public Transform groundCheck;
    public bool grounded = false;
    public bool canShoot = false;
    public float shootForce = 6f;
    public float jumpForce = 10;
    public float horizontalSpeed = 2f;
    public AudioClip jumpSound1;
    public AudioClip jumpSound2;
    public AudioClip jumpSound3;
    public AudioClip shootSound;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        ballCollider = GameObject.Find("Ball").GetComponent<CircleCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalSpeed;

        if (Input.GetKey(KeyCode.Z) && canShoot) {
            shoot();
            canShoot = false;
        }

        if (!grounded) {
            animator.SetTrigger("playerJump");
        } else if (x != 0 && grounded) {
            animator.SetTrigger("playerMove");
        } else if (grounded) {
            animator.SetTrigger("playerIdle");
        }

        if (Input.GetKey(KeyCode.UpArrow) && grounded) {
            jump();
        }

        if (Input.GetKey(KeyCode.L)) {
            shoot();
        }

        if (x > 0) {
            flipCharacter(true);
        }

        if (x < 0) {
            flipCharacter(false);
        }

        transform.Translate(x, 0, 0);
    }

    void jump() {
        myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        SoundManager.instance.RandomizeSfx(jumpSound1, jumpSound2, jumpSound3);
    }

    void shoot() {

        ballRigidbody.velocity = Vector2.zero;

        Vector2 v = new Vector2(0.1f, 0.1f);

        if (Input.GetKey(KeyCode.UpArrow)) {
            //Debug.Log("u shoot");                        
            v.y = 1f;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            //Debug.Log("d shoot");
            v.y = -0.5f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            //Debug.Log("l shoot");
            v.x = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            //Debug.Log("r shoot");
            v.x = 1f;
        }

        v.x = v.x * shootForce;
        v.y = v.y * shootForce;

        Debug.Log("v" + v);
        Debug.Log("vx" + v.x);
        Debug.Log("vy" + v.y);

        ballRigidbody.AddForce(v, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(myCollider, ballCollider, true);
        SoundManager.instance.RandomizeSfx(shootSound);
    }

    void flipCharacter(bool facingRight) {
        mySprite.flipX = facingRight;
    }
}
