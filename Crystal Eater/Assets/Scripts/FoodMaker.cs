using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMaker : MonoBehaviour
{
    public GameObject food, poison;
    public float maxPoisonChance;
    public float poisonChance;
    public float poisonChanceAdder;

    Field field;

    float time = 0f;
    float maxTime = 5f;

    void Start()
    {
        field = FindObjectOfType<Field>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= maxTime || transform.childCount == 0)
        {
            time = 0f;
        }
        if (time == 0)
        {
            if (transform.childCount == 1)
                Destroy(transform.GetChild(0).gameObject);
            Make();
        }
        time += Time.deltaTime;
    }

    void Make()
    {
        var chance = Random.Range(0f, 1f);
        GameObject item;

        if (chance > poisonChance)
        {
            item = food;
        }
        else
        {
            item = poison;
        }

        var randomCell = field.emptyCells[Random.Range(0, field.emptyCells.Count - 1)];

        var position = randomCell.position;

        Instantiate(item, position, Quaternion.identity, transform);

        if (poisonChance < maxPoisonChance)
        {
            poisonChance += poisonChanceAdder;
        }
    }
}