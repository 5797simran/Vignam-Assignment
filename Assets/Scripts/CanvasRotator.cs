using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasRotator : MonoBehaviour
{
    public Transform targetObject; // The object whose rotation you want to mimic
    public TextMeshProUGUI xText;
    public TextMeshProUGUI yText;
    public TextMeshProUGUI zText;

    private Vector3 initialRotation;

    private void Start()
    {
        // Store the initial rotation of the attached object
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if (targetObject != null)
        {
            // Rotate the attached object to match the rotation of the target object
            transform.rotation = targetObject.rotation;

            // Calculate and display the size of each axis of the target object
            Vector3 targetScale = targetObject.localScale;
            xText.text = targetScale.x.ToString("F0");
            yText.text = targetScale.y.ToString("F0");
            zText.text = targetScale.z.ToString("F0");
        }
        else
        {
            // Handle the case where the targetObject is not assigned
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
