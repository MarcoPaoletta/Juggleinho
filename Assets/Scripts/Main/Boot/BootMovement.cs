using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootMovement : MonoBehaviour
{
    private float speed = 5f;
    private bool isDragging = false;
    private Vector3 targetPosition;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            isDragging = true;
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition.z = 10; // Set a z value for the touch position
            Vector3 worldTouchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            Vector3 offset = worldTouchPosition - transform.position;
            targetPosition = worldTouchPosition - offset.normalized * GetComponent<Renderer>().bounds.extents.magnitude;
        }

        if (isDragging)
        {
            OnMouseDrag();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z));
            isDragging = true;
        }
        else if (Input.GetMouseButton(0))
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            isDragging = true;
        }
    }

    void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition.z = 10; // Set a z value for the touch position
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(touchPosition) + offset;
            transform.position = curPosition;
            
            // Rotate the object based on the touch movement
            float rotateSpeed = 10f;
            float rotateAmount = Input.GetTouch(0).deltaPosition.x * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotateAmount, Space.World);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            
            // Rotate the object based on the mouse movement
            float rotateSpeed = 10f;
            float rotateAmount = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotateAmount, Space.World);
        }
    }

}
