using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatCollisionHandler : MonoBehaviour
{
    public GameObject signLanguagePopupPrefab;
    private GameObject activePopup;
    public string wordToDisplay = "Careful";
    public HealthManager healthManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shark") && activePopup == null)
        {
            if (healthManager != null)
            {
                healthManager.LoseHeart();
            }
            
            SceneManager.LoadScene("BeachSide");

            // Time.timeScale = 0f;

            // if (signLanguagePopupPrefab != null)
            // {
            //     activePopup = Instantiate(signLanguagePopupPrefab, Vector3.zero, Quaternion.identity);
            //     Canvas popupCanvas = activePopup.GetComponentInChildren<Canvas>();
            //     if (popupCanvas != null)
            //         popupCanvas.sortingOrder = 100;

            //     SimpleExecutionEngine engine = activePopup.GetComponent<SimpleExecutionEngine>();
            //     if (engine != null)
            //     {
            //         engine.DisplayManualWord(wordToDisplay);
            //         engine.Poll();
            //     }
            // }
        }
    }

    public void ResumeGame()
    {
        if (activePopup != null)
        {
            Destroy(activePopup);
            activePopup = null;
        }

        Time.timeScale = 1f;
    }
}
