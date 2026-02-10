using System.Collections;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    
    public float speed = 50.0f;
    
    public Rigidbody2D rb;
    public float timeSwitch = 1f;

    void Start()
    {

        StartCoroutine(Wiggle());
        GetComponent<Rigidbody2D>();
    }

    IEnumerator Wiggle()
    {
        while (true)
        {
           
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
            yield return new WaitForSeconds(timeSwitch);
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
    }
}

