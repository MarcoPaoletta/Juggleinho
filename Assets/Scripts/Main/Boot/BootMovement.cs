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
            touchPosition.z = 10;
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
            touchPosition.z = 10;
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(touchPosition) + offset;
            transform.position = curPosition;
        }
    }

}
