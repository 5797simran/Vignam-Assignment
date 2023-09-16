using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectScaler : MonoBehaviour
{
       
    
    private Vector3 lastMousePosition;  // for rotation
    private bool isDragging = false; // for rotation
    public float rotationSpeed = 5.0f; // rotation speed

    public GameObject objectToScale; // The object you want to scale
    public Slider heightSlider;      // Slider for controlling height
    public Slider widthSlider;       // Slider for controlling width
    public Slider depthSlider;       // Slider for controlling depth
   

    public float minHeight = 1f;    // Minimum height value
    public float maxHeight = 5f;   // Maximum height value
    public float minWidth = 1f;     // Minimum width value
    public float maxWidth = 5f;    // Maximum width value
    public float minDepth = 1f;    // Minimum depth value
    public float maxDepth = 5f;   // Maximum depth value

    private Vector3 initialScale;   // The initial scale of the object

    private void Start()
    {
        // Store the initial scale of the object
        initialScale = objectToScale.transform.localScale;

        // Set the slider values to the initial scale
        heightSlider.value = initialScale.y;
        widthSlider.value = initialScale.x;
        depthSlider.value = initialScale.z;

        // Add listeners to the sliders
        heightSlider.onValueChanged.AddListener(ChangeHeight);
        widthSlider.onValueChanged.AddListener(ChangeWidth);
        depthSlider.onValueChanged.AddListener(ChangeDepth);        
    }

    private void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == objectToScale)
            {
                isDragging = true;
                lastMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 rotation = new Vector3(-delta.y, delta.x, 0) * rotationSpeed * Time.deltaTime;
            objectToScale.transform.Rotate(rotation, Space.World);
            lastMousePosition = Input.mousePosition;
        }
    }


    private void ChangeHeight(float newHeight)
    {
        // Clamp the new height value within the specified range
        newHeight = Mathf.Clamp(newHeight, minHeight, maxHeight);

        // Update the object's scale with the new height
        Vector3 newScale = objectToScale.transform.localScale;
        newScale.y = newHeight;
        objectToScale.transform.localScale = newScale;
    }

    private void ChangeWidth(float newWidth)
    {
        // Clamp the new width value within the specified range
        newWidth = Mathf.Clamp(newWidth, minWidth, maxWidth);

        // Update the object's scale with the new width
        Vector3 newScale = objectToScale.transform.localScale;
        newScale.x = newWidth;
        objectToScale.transform.localScale = newScale;
    }

    private void ChangeDepth(float newDepth)
    {
        // Clamp the new depth value within the specified range
        newDepth = Mathf.Clamp(newDepth, minDepth, maxDepth);

        // Update the object's scale with the new depth
        Vector3 newScale = objectToScale.transform.localScale;
        newScale.z = newDepth;
        objectToScale.transform.localScale = newScale;
    }


    
}
