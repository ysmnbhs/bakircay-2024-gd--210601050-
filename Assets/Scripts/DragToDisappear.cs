using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToDisappear : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject selectedObject;
    private Vector3 offset;
    private bool isDragging = false;

    private Vector3 previousPosition;  
    private Vector3 currentPosition;   

    public float throwForce = 10f;  

    void Start()
    {
        mainCamera = Camera.main; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.collider.CompareTag("DynamicItem")) 
                {
                    selectedObject = hit.collider.gameObject;
                    offset = selectedObject.transform.position - hit.point + Vector3.up * 10f; 
                    isDragging = true; 

                    
                    previousPosition = selectedObject.transform.position;
                }
            }
        }

        if (isDragging && selectedObject != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPos = ray.GetPoint(20); 
            selectedObject.transform.position = worldPos + offset; 
            currentPosition = selectedObject.transform.position;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; 
            }

            isDragging = false;
            selectedObject = null; 
        }
    }
}
