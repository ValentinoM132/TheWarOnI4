using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    [Header("Unity Objects")]
    public Rigidbody2D rb;
    public Rigidbody2D ballRb;
    [SerializeField] private Transform paddle;

    [Header("Game paramaters")]
    [SerializeField] private float paddleSpeed = 4f;
    [SerializeField] private Vector2 initialballvelocity = new Vector2(2f, 4f);


    public float move;
    private bool isBallinPlay = false;


    void Start()
    {
        
    }

    // This is finding the input from the player and assigining it a valuable
    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>().x;
    }
   
    // This is using previous value and turning it to movement
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * paddleSpeed * Time.deltaTime, rb.linearVelocity.y);
    }
    // Update is called once per frame
    void Update()
    {
       if (!isBallinPlay)
        {
            ballRb.transform.position = paddle.position + (Vector3.up * 0.2f);
        }

       rb.freezeRotation = true;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed && !isBallinPlay)
        {
            isBallinPlay = true;
            ballRb.AddForce(initialballvelocity, ForceMode2D.Impulse);
        }
    }




}
