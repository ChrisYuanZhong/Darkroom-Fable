using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Move the camera.
    public void MoveCamera(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        if (!isMoving)
        {
            StartCoroutine(MoveCameraCoroutine(startPosition, endPosition, duration));
        }
    }

    // Coroutine to move the camera.
    private IEnumerator MoveCameraCoroutine(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        isMoving = true;

        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / duration);

            yield return null;
        }

        isMoving = false;
    }
}
