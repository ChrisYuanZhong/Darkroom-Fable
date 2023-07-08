using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrigger : MonoBehaviour
{
    public GameManager_E0 gameManager;
    public BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerMovement>().isShifting)
            {
                other.gameObject.GetComponent<PlayerMovement>().isInTwoTriggers = true;
            }
            else
            {
                if (gameManager.currentFrame > 0)
                {
                    other.gameObject.GetComponent<PlayerMovement>().isShifting = true;
                    gameManager.MoveLeft();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerMovement>().isInTwoTriggers == true)
        {
            collision.gameObject.GetComponent<PlayerMovement>().isInTwoTriggers = false;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().isShifting = false;
        }
    }
}
