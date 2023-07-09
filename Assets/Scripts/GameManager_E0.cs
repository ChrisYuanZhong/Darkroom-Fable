using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

public class GameManager_E0 : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public GameObject hand;
    public GameObject plunger;
    public GameObject ghost;
    public SpriteRenderer background3;
    public SpriteRenderer background4;
    public Sprite background3NoHand;
    private Sprite background4Original;
    public Sprite background4WithPlunger;

    public GameObject bubbleWithShit;
    public GameObject anim_success1;
    public GameObject anim_success2;
    public GameObject anim_failed;

    public GameObject tip_paper;
    public GameObject tip_plunge;

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

    public GameObject toiletPaper;
    public List<ScriptPerFrame> toiletPaperScripts = new List<ScriptPerFrame>(alwaysOnScripts);

    // Start is called before the first frame update
    void Start()
    {
        background4Original = background4.sprite;

        Destroy(bubbleWithShit, 2f);
        Invoke("EnableInput", 2f);

        //leftTrigger.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, 1);
        //rightTrigger.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, 1);
        //floor.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(floorScripts, frameLength, 1);
        //backGround.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(backGroundScripts, frameLength, 1);
        toiletPaper.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(toiletPaperScripts, frameLength, 1);
        ghost.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(ghostScripts, frameLength, 1);
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

    public void PickUpToiletPaper()
    {
        if (player.GetComponent<PlayerMovement>().holdingPaper)
            return;
        toiletPaper.GetComponent<SceneComponentAutoGen>().DestroyFollowingFrames(currentFrame);
        player.GetComponent<PlayerMovement>().holdingPaper = true;

        // Change posture to holding paper
        player.GetComponent<PlayerMovement>().anim.SetBool("withTissue", true);

        tip_paper.gameObject.SetActive(true);
        Invoke("Tip_disappear", 2f);
    }

    public void GiveToiletPaper()
    {
        if (player.GetComponent<PlayerMovement>().holdingPaper)
        {
            Destroy(hand);
            background3.sprite = background3NoHand;
            background4.sprite = background4WithPlunger;
        }

        // Change posture to normal
        player.GetComponent<PlayerMovement>().anim.SetBool("withTissue", false);

    }

    public void PickUpPlunger()
    {
        if (background4.sprite == background4WithPlunger)
        {
            player.GetComponent<PlayerMovement>().holdingPlunger = true;
            Destroy(plunger);
            background4.sprite = background4Original;

            // Change posture to holding plunger
            player.GetComponent<PlayerMovement>().anim.SetBool("withPlunge", true);
            tip_plunge.gameObject.SetActive(true);

            Invoke("Tip_disappear", 2f);
        }
    }

    public void Plunge()
    {
        if (player.GetComponent<PlayerMovement>().holdingPlunger)
        {
            ghost.GetComponent<SceneComponentAutoGen>().DestroyFollowingFrames(currentFrame);


            // The End
            if (currentFrame == 0)
                anim_success1.gameObject.SetActive(true);
            else if (currentFrame == 1)
                anim_success2.gameObject.SetActive(true);

            Destroy(player);
            ended = true;

        }
    }

    void Tip_disappear()
    {
        tip_plunge.gameObject.SetActive(false);
        tip_paper.gameObject.SetActive(false);

    }

    public void Death()
    {
        //animator.Failure();
        anim_failed.gameObject.SetActive(true); 
        Destroy(player);
        ended = true;
    }
}
