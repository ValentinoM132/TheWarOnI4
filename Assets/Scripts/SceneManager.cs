using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();

    public int nextSceneIndex;
    private bool hasTriggeredWin = false;

    [Header("References")]

    public GameObject winScreen;

    public GameManager player;

    public void Start()
    {
        nextSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;

        foreach (var obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
        {
            if (obj.CompareTag("Block"))
            {
                blocks.Add(obj);
            }
        }
        winScreen.SetActive(false);
    }

    public void RemoveBlock(GameObject block)
    {
        blocks.Remove(block);

        if (blocks.Count == 0 && !hasTriggeredWin)
        {
            hasTriggeredWin = true;
            winScreen.SetActive(true);
            player.playerHasWon = true;
            StartCoroutine(delayWinScreen());
        }
    }


    public void ResetLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator delayWinScreen()
    {
        yield return new WaitForSeconds(5);
        if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex); 
        }
        else
        {
            // Handle end-of-game logic, e.g., load the main menu (index 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
        }
    }
}
