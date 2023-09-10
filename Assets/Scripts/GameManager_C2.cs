using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public struct ScriptPerFrame
//{
//    public ScriptPerFrame(bool i_render = true, int i_xPositionOffset = 0, int i_yPositionOffset = 0)
//    {
//        render = i_render;
//        positionOffset = new Vector2(i_xPositionOffset, i_yPositionOffset);
//    }

//    public bool render;
//    public Vector2 positionOffset;

//}

public class GameManager_C2 : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public GameObject cart;

    public int totalFrames = 8;
    public int currentFrame = 0;
    public float frameLength = 2.4f;
    public bool ended = false;


    //public GameObject leftTrigger;
    //public GameObject rightTrigger;

    public static List<ScriptPerFrame> alwaysOnScripts = new List<ScriptPerFrame>()
    {
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
    };

    public static List<ScriptPerFrame> ghostScripts = new List<ScriptPerFrame>()
    {
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
    };

    //public GameObject floor;
    //public List<ScriptPerFrame> floorScripts = new List<ScriptPerFrame>(alwaysOnScripts);

    //public GameObject backGround;
    //public List<ScriptPerFrame> backGroundScripts = new List<ScriptPerFrame>(alwaysOnScripts);

    // Start is called before the first frame update
    void Start()
    {

        //Destroy(bubbleWithShit, 1f);
        Invoke("EnableInput", 1f);

        //leftTrigger.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, 1);
        //rightTrigger.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, 1);
        //floor.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(floorScripts, frameLength, 1);
        //backGround.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(backGroundScripts, frameLength, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            if (ended)
            {
                // Back to main menu
                SceneManager.LoadScene("Ningxuan_tes");

            }
        }
    }

    // Move the camera smoothly using Lerp.

    public void EnableInput()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
    }

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

    public void PickUpCart()
    {
        player.GetComponent<PlayerMovement>().PickUpCart();

         // Change posture to holding cart
        //player.GetComponent<PlayerMovement>().anim.SetBool("withCart", true);

        // Play sound
        //source1.PlayOneShot(sound_itemPick, 2f);


        // Destroy cart
        Destroy(cart);
    }

    public void PutDownCart()
    {
        player.GetComponent<PlayerMovement>().PutDownCart();

        // Change posture to normal
        //player.GetComponent<PlayerMovement>().anim.SetBool("withCart", false);

        // Play sound
        //source1.PlayOneShot(sound_itemPick, 2f);

        // Create cart
        cart = Instantiate(cart, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + 0.5f, player.transform.position.z), Quaternion.identity);
    }
}
