using UnityEngine;
using UnityEngine.SceneManagement;

public class Bobber : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fish hit!");
        SceneManager.LoadScene("SignPrompt");

    }
}