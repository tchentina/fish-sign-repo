using UnityEngine;

public class BoatClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject ASL_recognizer_prefab;
    private GameObject activeRecognizer;

    void OnMouseDown()
    {
        if (activeRecognizer == null)
        {
            activeRecognizer = Instantiate(ASL_recognizer_prefab);
        }
    }
}
