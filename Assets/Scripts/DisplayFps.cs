using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayFps : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;
    int fps;

    private void Awake()
    {
        InvokeRepeating(nameof(UpdateFps), 1, 1);
    }

    private void UpdateFps()
    {
        fps = Mathf.RoundToInt(1.0f / Time.unscaledDeltaTime);
        fpsText.text = fps.ToString() + " FPS";
    }
}
