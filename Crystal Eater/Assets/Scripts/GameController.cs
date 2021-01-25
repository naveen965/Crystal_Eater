using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject snakePrefab;
    public Snake head;
    public Snake tail;
    public int NESW;
    public Vector2 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimerInvoke", 0, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TimerInvoke()
    {
        Movement();
    }

    void Movement()
    {
        GameObject temp;
        nextPos = head.transform.position;

        if(head.transform == null)
        {
            return;
        }

        switch (NESW)
        {
            case 0:
                nextPos = new Vector2(nextPos.x, nextPos.y + 1);
                break;
            case 1:
                nextPos = new Vector2(nextPos.x + 1, nextPos.y);
                break;
            case 2:
                nextPos = new Vector2(nextPos.x, nextPos.y - 1);
                break;
            case 3:
                nextPos = new Vector2(nextPos.x - 1, nextPos.y);
                break;
        }
        temp = (GameObject)Instantiate(snakePrefab, nextPos, transform.rotation);
        head.Setnext(temp.GetComponent<Snake>());
        head = temp.GetComponent<Snake>();

        return;
    }
}
