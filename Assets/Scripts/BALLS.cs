using UnityEngine;

public class BALLS : MonoBehaviour
{
    public bool collission;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("knight"))
        {
            gameObject.SetActive(false);
        }
    }
}