using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
    Snake snake;
    Field field;

    void Start()
    {
        snake = transform.parent.GetComponent<Snake>();
        field = FindObjectOfType<Field>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("food"))
        {
            var lastPart = snake.bodyParts[snake.bodyParts.Count - 1];

            var newPart = Instantiate(lastPart.gameObject, lastPart.position - lastPart.up * snake.step, lastPart.rotation, transform.parent);
            snake.bodyParts.Add(newPart.transform);

            if (snake.stepTime > snake.minStepTime)
                snake.stepTime -= snake.stepTimeAdder;
        }
        else
        {
            snake.Die();
            return;
        }

        Destroy(coll.gameObject);
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x) > field.width / 2f * field.cellSize + 1f ||
            Mathf.Abs(transform.position.y) > field.height / 2f * field.cellSize)
            snake.Die();
    }
}