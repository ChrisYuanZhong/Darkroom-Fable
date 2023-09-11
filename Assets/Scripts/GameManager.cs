using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScriptPerFrame
{
    public ScriptPerFrame(bool i_render = true, int i_xPositionOffset = 0, int i_yPositionOffset = 0)
    {
        render = i_render;
        positionOffset = new Vector2(i_xPositionOffset, i_yPositionOffset);
    }

    public bool render;
    public Vector2 positionOffset;

}

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;

    public int totalFrames = 0;
    public int currentFrame = 0;
    public float frameLength = 2.4f;
    public bool ended = false;

    public static List<ScriptPerFrame> alwaysOnScripts = new List<ScriptPerFrame>()
    {
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Move the camera smoothly using Lerp.
    public void MoveLeft()
    {
        currentFrame--;
        mainCamera.GetComponent<CameraMovement>().MoveCamera(mainCamera.transform.position, new Vector3(mainCamera.transform.position.x - frameLength, mainCamera.transform.position.y, mainCamera.transform.position.z), 0.5f);

    }

    public void MoveRight()
    {
        currentFrame++;
        mainCamera.GetComponent<CameraMovement>().MoveCamera(mainCamera.transform.position, new Vector3(mainCamera.transform.position.x + frameLength, mainCamera.transform.position.y, mainCamera.transform.position.z), 0.5f);


        //floor.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, currentFrame);
        //backGround.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, currentFrame);
        //toiletPaper.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, currentFrame);
    }

    // Override this function in child classes.
    public virtual void Death()
    {
    }
}
