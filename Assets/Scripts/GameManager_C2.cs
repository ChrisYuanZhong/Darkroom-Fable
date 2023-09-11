using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Derive from GameManager
public class GameManager_C2 : GameManager
{
    public GameObject cart;
    public bool holdingCart = false;
    public bool loadedCart = false;

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

    public void PickUpCart()
    {
        holdingCart = true;

         // Change posture to holding cart
        //player.GetComponent<PlayerMovement>().anim.SetBool("withCart", true);

        // Play sound
        //source1.PlayOneShot(sound_itemPick, 2f);
    }

    public void PutDownCart()
    {
        holdingCart = false;

        // Change posture to normal
        //player.GetComponent<PlayerMovement>().anim.SetBool("withCart", false);

        // Play sound
        //source1.PlayOneShot(sound_itemPick, 2f);

        // Create cart
        cart = Instantiate(cart, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + 0.5f, player.transform.position.z), Quaternion.identity);
        cart.GetComponent<SceneComponentAutoGen>().GenerateNextFrame(totalFrames - currentFrame - 1, frameLength);
    }
}
