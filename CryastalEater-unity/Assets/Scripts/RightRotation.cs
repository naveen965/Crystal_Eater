using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightRotatioin : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public List<Transform> BodyParts = new List<Transform>();
    public float rotationspeed = 50;
    bool isPressed = false;
    public GameObject Snake;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            BodyParts[0].Rotate(Vector3.forward * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
