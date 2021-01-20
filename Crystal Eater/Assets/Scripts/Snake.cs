using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();

    public float minStepTime;
    public float maxStepTime;

    public float stepTimeAdder;


    [HideInInspector]
    public float stepTime;
    [HideInInspector]
    public float step;
    [HideInInspector]
    public float delta = 0f;

    Transform head;
    Vector2 moveDirection = Vector2.up;

    // Start is called before the first frame update
    void Start()
    {
        head = bodyParts[0];
        stepTime = maxStepTime;
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        if (delta >= stepTime)
        {
            Move();
            delta = 0f;
        }
        delta += Time.deltaTime;
    }

    void Control()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right;
        }

        if (moveDirection == -(Vector2)head.up)
        {
            moveDirection = head.up;
        }
    }

    void Move()
    {
        for (int i = bodyParts.Count - 1; i >= 1; i--)
        {
            var part = bodyParts[i];
            var nextPart = bodyParts[i - 1];
            part.rotation = nextPart.rotation;
            part.position = nextPart.position;
        }

        head.up = moveDirection;
        head.position += head.up * step;
    }

    public void Die()
    {
        SceneManager.LoadScene(0);
    }
}