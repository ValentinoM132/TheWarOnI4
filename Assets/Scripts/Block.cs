using JetBrains.Annotations;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] private int hitsToDestroy = 3;
    [SerializeField] private bool isDestructible = true;

    private SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite newSprite;
    public Sprite defaultSprite;

    [Header("References")]

    public GameManager gameManager;
    public SceneManager sceneManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        sceneManager = FindFirstObjectByType<SceneManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
    }
    public void ChangeToAlternateSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestructible)
        {
            hitsToDestroy--;
            ChangeToAlternateSprite();
            gameManager.score += 10;
            //  if (spriteRenderer == null)
            //  {
            //      gameManager.score += 10;
            //      sceneManager.RemoveBlock(gameObject);
            //      Destroy(gameObject);
            //  }
            //  else

            if (hitsToDestroy <= 0)
            {
                gameManager.score += 10;
                sceneManager.RemoveBlock(gameObject);
                Destroy(gameObject);
            }
        }
    }



}
    


  