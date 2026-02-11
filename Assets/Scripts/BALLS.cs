using UnityEngine;

public class BALLS : MonoBehaviour
{
    public bool collission;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("knight"))
        {
            gameObject.SetActive(false);
            GameManager player = FindFirstObjectByType<GameManager>();
            player.Lives = player.Lives + 1;
        }
    }
}