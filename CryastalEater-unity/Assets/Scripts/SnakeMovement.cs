﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*using Unity.Entities;
using Unity.Mathematics;
using Unity.Tiny.Core2D;
using Unity.Tiny.Input;*/

public class SnakeMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public List<Transform> BodyParts = new List<Transform>();
    public float mindistance = 0.25f;
    public int beginsize;
    public float speed = 1;
    public float rotationspeed = 50;
    public GameObject bodyprefab;
    private float dis;
    private Transform curBodyPart;
    private Transform PrevBodypart;
    public GameObject leftButton;
    public GameObject RightButton;
    bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < beginsize - 1; i++)
        {
            AddBodyPart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (isPressed && leftButton)
        {
            RotateLeft();
        }

        if (isPressed && RightButton)
        {
            RotateRight();
        }

        if (Input.GetKey(KeyCode.Q))
            AddBodyPart();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void RotateLeft()
    {
        if (Input.GetMouseButton(0))
            BodyParts[0].Rotate(Vector3.back * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    public void RotateRight()
    {
        if (Input.GetMouseButton(0))
            BodyParts[0].Rotate(Vector3.back * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    public void Move()
    {
        float curspeed = speed;

        if (Input.GetKey(KeyCode.W))
            curspeed *= 2;

        BodyParts[0].Translate(BodyParts[0].up * curspeed * Time.smoothDeltaTime, Space.World);

        /*if (Input.GetKey(KeyCode.A))
            BodyParts[0].Rotate(new Vector3(0f, 0f, -1f) * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.D))
            BodyParts[0].Rotate(new Vector3(0f, 0f, 1f) * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));*/

        if (Input.GetKey(KeyCode.A))
            BodyParts[0].Rotate(Vector3.back * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.D))
            BodyParts[0].Rotate(Vector3.back * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        /*if (Input.GetMouseButton(0))
            BodyParts[0].Rotate(Vector3.back * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));*/

        for (int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            PrevBodypart = BodyParts[i - 1];

            dis = Vector3.Distance(PrevBodypart.position, curBodyPart.position);

            Vector3 newpos = PrevBodypart.position;

            newpos.z = BodyParts[0].position.z;

            float T = Time.deltaTime * dis / mindistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PrevBodypart.rotation, T);

        }
    }

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        BodyParts.Add(newpart);
    }

    public void WithoutTail()
    {
        for (int i = 1; i < BodyParts.Count; i++)
        {
            BodyParts[0] = BodyParts[i];
        }
    }
}
