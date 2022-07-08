using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public int Speed;
    private float dirX = 0f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
        //transform.position += new Vector3(0, 45, 0) * Time.deltaTime * Speed;
        FlipCharacter();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
    }

    public void FlipCharacter()
    {
        if (dirX > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (dirX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}