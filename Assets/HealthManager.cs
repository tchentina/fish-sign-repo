using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("UI Heart Image")]
    public Image heartImage;

    [Header("Heart Sprites by State")]
    // 0-->0 hearts, 1-->1 heart, 2-->2 hearts, 3-->max health
    public Sprite[] heartStates;

    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartUI();
    }

    public void LoseHeart()
    {
        currentHealth = Mathf.Max(currentHealth - 1, 0);
        UpdateHeartUI();

        if (currentHealth == 0)
        {
            Debug.Log("Game Over!");
        }
    }

    public void GainHeart()
    {
        currentHealth = Mathf.Min(currentHealth + 1, maxHealth);
        UpdateHeartUI();
    }

    private void UpdateHeartUI()
    {
        if (heartImage != null && heartStates.Length > 0)
        {
            int index = Mathf.Clamp(currentHealth, 0, heartStates.Length - 1);
            heartImage.sprite = heartStates[index];
        }
    }
}
