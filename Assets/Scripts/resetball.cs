using UnityEngine;

public class resetball : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.resetBall();
            Debug.Log("Ball Reset");
        }
    }
}

  
