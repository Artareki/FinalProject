using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private Rigidbody2D rbFireworks;
    [SerializeField] private Animator MyAnimator;
    [SerializeField] private int Health;
    [SerializeField] private Collider2D MyCollider;
    public AudioSource Boom;
    public AudioSource Wow;
    public AudioSource Boo;

    [SerializeField] private float TimeToExit;

    [SerializeField]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 5f;

    private Vector3 lastFrameVelocity;

    private void Start()
    {
        rbFireworks = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        StartCoroutine(ExitFirework());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnMouseDown();
    }

    private void Update()
    {
        lastFrameVelocity = rbFireworks.velocity;
    }

    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1)
        {
            HanabiManager.Instance.Shots();

            if (Health == 0)
            {
                MyAnimator.SetTrigger("Shoot");
                rbFireworks.velocity = new Vector2(0, 0);
                Destroy(gameObject, 3);
                Boom.Play();
                Wow.Play();

                if (tag == "Firework")
                {
                    HanabiManager.Instance.AddScore();
                }
                else if (tag == "FireworkRed")
                {
                    HanabiManager.Instance.AddScoreRed();
                }
            }
            else
            {
                Health--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void OnEnable()
    {
        rbFireworks.velocity = initialVelocity;
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rbFireworks.velocity = direction * Mathf.Max(speed, minVelocity);
        FlipCharacter();
    }

    public IEnumerator ExitFirework()
    {
        yield return new WaitForSeconds(TimeToExit);
        MyCollider.enabled = false;
        Destroy(gameObject, 2);
        HanabiManager.Instance.Invoke("LivesLost", 1f);
        Boo.Play();
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