using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlight : MonoBehaviour
{
    // Start is called before the first frame update
    private Color originalColor;
    public Vector2 item_pos, player_pos;
    private float range = 1f;

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = originalColor;

    }

    // Update is called once per frame
    void Update()
    {
        item_pos = transform.position;
        player_pos = GameObject.Find("Body").transform.position;

        if (Vector2.Distance(item_pos, player_pos) <= range)
        { //Checking if player is near enough
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = originalColor;
        }
    }

}
