using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskHighLight : MonoBehaviour
{
    // Start is called before the first frame update
    private Color originalColor;
    public Vector2 item_pos, player_pos;
    private float range = 2.4f;

    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = originalColor;

    }

    // Update is called once per frame
    /*void Update()
    {
        item_pos = transform.position;
        player_pos = GameObject.Find("Body").transform.position;

        if (Vector2.Distance(item_pos, player_pos) <= range)
        { //Checking if player is near enough
            GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 4f);
        }
        else
        {
            GetComponent<Renderer>().material.color = originalColor;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 4f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

}
