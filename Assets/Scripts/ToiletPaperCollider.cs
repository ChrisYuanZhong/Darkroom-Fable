using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaperCollider : MonoBehaviour
{
    public GameManager_C1 gameManager;

    public bool isOverlapping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOverlapping)
            {
                gameManager.PickUpToiletPaper();
                GetComponent<SceneComponentAutoGen>().DestroySelf();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isOverlapping = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOverlapping = false;
    }
}