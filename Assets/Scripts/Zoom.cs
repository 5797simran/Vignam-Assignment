using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    public Camera targetCamera; // Reference to your camera
    public Slider sizeSlider;   // Reference to your UI Slider
    public float minOrthoSize = 1f; // Minimum orthographic size
    public float maxOrthoSize = 10f; // Maximum orthographic size

    private void Start()
    {
        if (targetCamera != null && sizeSlider != null)
        {
            // Initialize the slider's min and max values
            sizeSlider.minValue = minOrthoSize;
            sizeSlider.maxValue = maxOrthoSize;

            // Set the initial orthographic size and slider value
            float initialOrthoSize = Mathf.Clamp(targetCamera.orthographicSize, minOrthoSize, maxOrthoSize);
            targetCamera.orthographicSize = initialOrthoSize;
            sizeSlider.value = initialOrthoSize;

            // Subscribe to the slider's value change event
            sizeSlider.onValueChanged.AddListener(ChangeOrthographicSize);
        }
    }

    public void ChangeOrthographicSize(float newSize)
    {
        // Update the camera's orthographic size based on the slider value
        if (targetCamera != null)
        {
            float clampedSize = Mathf.Clamp(newSize, minOrthoSize, maxOrthoSize);
            targetCamera.orthographicSize = clampedSize;
        }
    }
}
