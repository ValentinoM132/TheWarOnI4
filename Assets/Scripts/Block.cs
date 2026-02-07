using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] private int hitsToDestroy = 3;
    [SerializeField] private bool isDestructible = true;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite newSprite;

    [Header("References")]

    public GameManager gameManager;
    public SceneManager sceneManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        sceneManager = FindFirstObjectByType<SceneManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestructible)
        {
            hitsToDestroy--;
            if (spriteRenderer == null)
            {
                gameManager.score += 10;
                sceneManager.RemoveBlock(gameObject);
                Destroy(gameObject);
            }
            else
                {spriteRenderer.sprite = newSprite;
                if (hitsToDestroy <= 0)
                {

                    Destroy(gameObject);
                }
            }
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
