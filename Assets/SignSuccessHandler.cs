using UnityEngine;
using UnityEngine.SceneManagement;

public class SignSuccessHandler : MonoBehaviour
{
    [Header("Link to Sign Recognizer")]
    [SerializeField] private SimpleExecutionEngine engine;

    [Header("Sign Settings")]
    [SerializeField] private string targetSign;
    [SerializeField] private string nextScene;

    private void Start()
    {
        if (engine != null)
        {
            engine.signRecognized.AddListener(SignRecognized);
        }
        else
        {
            Debug.LogError("SimpleExecutionEngine reference not set on SignSuccessHandler!");
        }
    }

    private void OnDestroy()
    {
        if (engine != null)
        {
            engine.signRecognized.RemoveListener(SignRecognized);
        }
    }

    private void SignRecognized(string sign)
    {
        if (string.IsNullOrEmpty(sign)) return;

        sign = sign.ToLower().Trim();
        Debug.Log("SignSuccessHandler received: " + sign);

        if (sign == targetSign.ToLower().Trim())
        {
            Debug.Log("Correct sign recognized! Loading scene: " + nextScene);
            SceneManager.LoadScene(nextScene);
        }
    }
}
