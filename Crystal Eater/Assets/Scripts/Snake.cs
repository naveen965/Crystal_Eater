using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake : MonoBehaviour
{
    public Snake next;
    static public Action<string> hit;

    public void Setnext(Snake IN)
    {
        next = IN;
    }

    public Snake GetNext()
    {
        return next;
    }

    public void RemoveTail()
    {
        Destroy(this.gameObject);
    }

    void onTriggerEnter(Collider other)
    {
        if(hit != null)
        {
            hit(other.transform.tag);
        }
        if(other.tag == "Food")
        {
            Destroy(other.gameObject);
        }
    }
}
