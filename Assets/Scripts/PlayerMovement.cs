using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    [Header("Unity Objects")]
    public Rigidbody2D rb;
    public Rigidbody2D ballRb;
    [SerializeField] private Transform paddle;

    [Header("Game paramaters")]
    [SerializeField] private float paddleSpeed = 4f;
    [SerializeField] private Vector2 initialballvelocity = new Vector2(0f, 0f);
    [SerializeField] private Vector2 velocity = new Vector2(2f, 4f);
    public float maxSpeed = 5f;

    public float move;
    private bool isBallinPlay = false;

    public int score = 0;

    public float VelocityX;
    public float VelocityY;

    // This is finding the input from the player and assigining it a valuable
    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>().x;
    }
   
    // This is using previous value and turning it to movement
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * paddleSpeed * Time.deltaTime, rb.linearVelocity.y);
        if (ballRb.linearVelocity.magnitude > maxSpeed)
        {
            ballRb.linearVelocity = ballRb.linearVelocity.normalized * maxSpeed;
        }
        VelocityX = rb.linearVelocity.x * 1;
        VelocityY = 10f;
    }

    // this sticks the ball to the paddle before the game starts
    void Update()
    {
       if (!isBallinPlay)
        {
            ballRb.transform.position = paddle.position + (Vector3.up * 0.2f);
        }

       rb.freezeRotation = true;
    }
    // this starts the game by adding force to the ball
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed && !isBallinPlay)
        {
            isBallinPlay = true;
            ballRb.AddForce(new Vector2(VelocityX, VelocityY), ForceMode2D.Impulse);
        }
    }
    // This is adding force to the ball when it collides with the paddle as a work around for friction slowing the ball down
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballRb.AddForce(initialballvelocity, ForceMode2D.Impulse);
        }
    }

    public void resetBall()
    {
        isBallinPlay = false;
        ballRb.linearVelocity = Vector2.zero; 
    }

}
