using JetBrains.Annotations;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] private int hitsToDestroy = 3;
    [SerializeField] private bool isDestructible = true;
    public float dropChance = 0.7f;

    private SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite newSprite;
    public Sprite defaultSprite;

    [Header("References")]

    public GameManager gameManager;
    public SceneManager sceneManager;
    public GameObject backgroundAudio;


    public AudioSource audioSource;
    public AudioClip soundClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        foreach (var obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            if (obj.CompareTag("Background"))
            {
                backgroundAudio = obj;
                audioSource = backgroundAudio.GetComponent<AudioSource>();
                audioSource.clip = soundClip;
            }
        }
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
                if (Random.value <= dropChance)
                {
                    Debug.Log("Item Dropped!");
                }
                    gameManager.score += 10;
                audioSource.Play();
                sceneManager.RemoveBlock(gameObject);
                Destroy(gameObject);
            }
        }
    }



}
    


  