using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Derive from GameManager
public class GameManager_C1 : GameManager
{
    private bool holdingPaper = false;
    private bool holdingPlunger = false;

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

    //��Ч
    private AudioSource source1;
    public AudioClip sound_itemPick;
    public AudioClip sound_doorShut;
    public AudioClip sound_ghost;
    public AudioClip sound_splash;


    //public GameObject leftTrigger;
    //public GameObject rightTrigger;

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
        source1 = GetComponent<AudioSource>();

        background4Original = background4.sprite;

        Destroy(bubbleWithShit, 1f);
        Invoke("EnableInput", 1f);

        //leftTrigger.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, 1);
        //rightTrigger.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(alwaysOnScripts, frameLength, 1);
        //floor.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(floorScripts, frameLength, 1);
        //backGround.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(backGroundScripts, frameLength, 1);
        //toiletPaper.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(toiletPaperScripts, frameLength, 1);
        //ghost.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(ghostScripts, frameLength, 1);
        toiletPaper.GetComponent<SceneComponentAutoGen>().GenerateNextFrame(totalFrames - 1, frameLength);
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

    public void EnableInput()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void PickUpToiletPaper()
    {
        if (holdingPaper)
            return;
        //toiletPaper.GetComponent<SceneComponentAutoGen>().DestroySelf();
        holdingPaper = true;

        // Change posture to holding paper
        player.GetComponent<PlayerMovement>().anim.SetBool("withTissue", true);

        source1.PlayOneShot(sound_itemPick, 2f);

        tip_paper.gameObject.SetActive(true);
        Invoke("Tip_disappear", 2f);
    }

    public void GiveToiletPaper()
    {
        if (holdingPaper)
        {
            Destroy(hand);
            background3.sprite = background3NoHand;
            background4.sprite = background4WithPlunger;
        }

        source1.PlayOneShot(sound_doorShut, 2f);

        // Change posture to normal
        player.GetComponent<PlayerMovement>().anim.SetBool("withTissue", false);

    }

    public void PickUpPlunger()
    {
        if (background4.sprite == background4WithPlunger)
        {
            holdingPlunger = true;
            Destroy(plunger);
            background4.sprite = background4Original;

            // Change posture to holding plunger
            player.GetComponent<PlayerMovement>().anim.SetBool("withPlunge", true);
            source1.PlayOneShot(sound_itemPick, 2f);
            source1.PlayOneShot(sound_doorShut, 2f);
            tip_plunge.gameObject.SetActive(true);

            Invoke("Tip_disappear", 2f);
        }
    }

    public void Plunge()
    {
        if (holdingPlunger)
        {
            ghost.GetComponent<SceneComponentAutoGen>().DestroySelf();


            // The End
            if (currentFrame == 0)
                anim_success1.gameObject.SetActive(true);
            else if (currentFrame == 1)
                anim_success2.gameObject.SetActive(true);

            source1.PlayOneShot(sound_splash);
            Destroy(player);
            ended = true;

        }
    }

    void Tip_disappear()
    {
        tip_plunge.gameObject.SetActive(false);
        tip_paper.gameObject.SetActive(false);

    }

    // Override Death() in GameManager
    public override void Death()
    {
        //animator.Failure();
        source1.PlayOneShot(sound_ghost, 3f);
        anim_failed.gameObject.SetActive(true); 
        Destroy(player);
        ended = true;
    }
}
