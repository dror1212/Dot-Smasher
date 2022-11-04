using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    Player player;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (active)
        {
            if (other.tag == "Hole")
            {
                player.AddScore();
                Destroy(gameObject);
            }
            else if (other.tag == "Player" || other.tag == "Enemy")
            {
                if (other.tag == "Enemy" && other.transform.parent != player.transform)
                {
                    float distance_other = Vector2.Distance(other.transform.position, player.transform.position);
                    float distance = Vector2.Distance(transform.position, player.transform.position);

                    if (distance > distance_other)
                    {
                        Destroy(gameObject);

                    }
                }
                else
                {
                    player.TakeDamage();
                    speed = 0;
                    transform.parent = player.transform;
                    active = false;
                }
            }
        }
    }
}
