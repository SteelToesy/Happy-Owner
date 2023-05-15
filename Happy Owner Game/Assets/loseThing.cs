using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseThing : MonoBehaviour
{
    public Collider2D thing;
    public GameManager gameManager;
    void Start()
    {
        thing = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.LoseCondition();
        }
    }
}
