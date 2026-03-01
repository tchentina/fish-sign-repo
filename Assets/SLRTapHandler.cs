using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupTapHandler : MonoBehaviour
{
    private SimpleExecutionEngine engine;
    private BoatCollisionHandler collisionHandler;

    [Header("Sign Settings")]
    public string targetSign = "careful";
    public string validScene = "Ocean";

    void Start()
    {
        engine = GetComponent<SimpleExecutionEngine>();
        collisionHandler = FindFirstObjectByType<BoatCollisionHandler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || 
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (SceneManager.GetActiveScene().name != validScene) return;

            if (engine != null && !string.IsNullOrEmpty(engine.lastRecognizedSign))
            {
                if (engine.lastRecognizedSign.ToLower() == targetSign.ToLower())
                {
                    Debug.Log($"Correct sign '{targetSign}' recognized! Resuming game.");

                    if (collisionHandler != null)
                        collisionHandler.ResumeGame();
                }
                else
                {
                    Debug.Log($"Wrong sign ('{engine.lastRecognizedSign}'), try again!");
                }
            }
        }
    }
}
