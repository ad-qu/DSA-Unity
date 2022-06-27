using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCoolDown;
    private float horizontalInput;
    public static int numberCoins;

    public GameObject infoMenuScreen;
    public GameObject pauseMenuScreen;

    private void Awake() {
        
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        pauseMenuScreen.SetActive(false);
    }

    private void Update() {

        Debug.Log(numberCoins);

        horizontalInput = SimpleInput.GetAxis("Horizontal");
        //horizontalInput = Input.GetAxis("Horizontal"); //TO USE AWSD

        //Flip player when moving left or right
        if (horizontalInput > 0.01f) { transform.localScale = Vector3.one; }
        else if(horizontalInput < -0.01f) { transform. localScale = new Vector3(-1, 1, 1); }

        //Set animator parameters
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //Wall jump logic
        if (wallJumpCoolDown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero; 
            }
            else
                body.gravityScale = 7;
            
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCoolDown += Time.deltaTime;
    }

    public void Jump() {

        anim.SetTrigger("jump");

        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            AudioManager.instance.Play("Jump");
        }
        else if (onWall() && !isGrounded())
        {
            AudioManager.instance.Play("Jump");

            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);//?? min 16:47
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }

            wallJumpCoolDown = 0;
        }

    }

    //to wall jumping
     private bool isGrounded() 
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null; //si esta en el cielo
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null; //si esta en el cielo
    }
    public void Pause() //Pause the entire movement of the player and the game if it's equal to 0. Default is equal to 1.
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void Resume() 
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void Quit() 
    {
        //ENVIAR COSAS ¿?
        Application.Quit();
        Debug.Log("Quit");
    }
}
