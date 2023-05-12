using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    public GameObject player;

    public GameManager gameManager;
    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        CheckLoseCondition();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.WinCondition();
            Destroy(this.gameObject);
        }
    }

    private void CheckLoseCondition()
    {
        float maxRange = 35;

        if (Vector3.Distance(transform.position, player.transform.position) > maxRange)
        {
            gameManager.LoseCondition();
        }
    }
}
