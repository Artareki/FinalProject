using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public int Speed;
    private float dirX = 0f;
    private float dirY = 0f;
    public Rigidbody2D rb;
    public Animator MyAnimator;
    public int Health;
    public Collider2D MyCollider;
    public float TimeToExit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnMouseDown();
    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }

    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Health == 0)
            {
                MyAnimator.SetTrigger("Shoot");
                Speed = 0;
            }
            else
            {
                Health--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Vertical"))
        {
            transform.rotation = Quaternion.Euler(Random.Range(0, 0), Random.Range(0, -45), Random.Range(0, 45));
        }
        if (collision.gameObject.tag.Contains("Horizontal"))
        {
            transform.rotation = Quaternion.Euler(-180, 0, 0);
        }
        if (collision.gameObject.tag.Contains("HorizontalDown"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        FlipCharacter();
    }

    public IEnumerator ExitFirework()
    {
        yield return new WaitForSeconds(TimeToExit);
        MyCollider.enabled = false;
        Destroy(gameObject, 8);
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

        if (dirY > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (dirY < 0)
        {
            transform.rotation = Quaternion.Euler(180, 0, 0);
        }
    }
}