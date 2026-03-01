using System;
using System.Collections.Generic;
using Common;
using Mediapipe.Tasks.Vision.HandLandmarker;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SLR_Controller : MonoBehaviour
{
    [SerializeField] private SimpleExecutionEngine engine;

    private bool init;
    private readonly List<string> signs = new() { "boat", "bucket", "catch", "fish", "water" };
    private string curr;

    void Awake()
    {
        if (engine == null) engine = GetComponent<SimpleExecutionEngine>();
    }

    void Update()
    {
        // Diagnose which reference is missing (first time only helps a ton)
        if (engine == null)
        {
            Debug.LogError("SLR_Controller: engine is NULL (assign it in Inspector or add SimpleExecutionEngine to this GameObject).");
            return;
        }
        if (engine.buffer == null)
        {
            Debug.LogWarning("SLR_Controller: engine.buffer is NULL (engine not initialized yet?).");
            return;
        }
        if (engine.recognizer == null)
        {
            Debug.LogWarning("SLR_Controller: engine.recognizer is NULL (engine not initialized yet?).");
            return;
        }

        // One-time initialization once everything exists
        if (!init)
        {
            engine.recognizer.outputFilters.Clear();
            engine.recognizer.outputFilters.Add(new Thresholder<string>(0.1f));
            engine.recognizer.outputFilters.Add(new FocusSublistFilter<string>(signs));

            engine.recognizer.AddCallback("print", sign =>
            {
                curr = sign;
                Debug.Log("Got sign: " + curr);

                if (curr.Equals("boat", StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log("Transitioning to OpenOcean scene...");
                    SceneManager.LoadScene("Ocean");
                }
            });

            // Set trigger once, not every frame
            engine.buffer.trigger = new NoTrigger<HandLandmarkerResult>();

            init = true;
        }

        // Manual trigger via click (optional)
        if (Input.GetMouseButtonDown(0))
            engine.buffer.TriggerCallbacks();
    }
}