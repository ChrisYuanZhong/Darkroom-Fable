using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// The game scene is a roll film, so we will put all the components into the first frame and let them generate themselves after each length of the roll film block.
public class SceneComponentAutoGen : MonoBehaviour
{
    private List<GameObject> objectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // The first frame is the original game object itself.
        objectList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DestroyFollowingFrames(int firstFrameNumber)
    {
        // Delete all the generated game objects after this frame.
        for (int i = firstFrameNumber; i < objectList.Count;)
        {
            Destroy(objectList[i]);
            // Delete the game object from the list.
            objectList.RemoveAt(i);
        }
    }

    public void GenerateFollowingFrames(List<ScriptPerFrame> scriptsPerFrame, float frameLength, int firstFrameNumber)
    {
        DestroyFollowingFrames(firstFrameNumber);

        // Regenerate all the game objects after this frame.
        for (int i = firstFrameNumber; i < scriptsPerFrame.Count; i++)
        {
            if (scriptsPerFrame[i].render)
            {
                // Duplicate this game object itself after i * frameLength pixels along x axis.
                GameObject generatedGameObject = Instantiate(this.gameObject, new Vector3(transform.position.x + i * frameLength, transform.position.y, transform.position.z), transform.rotation);
                objectList.Add(generatedGameObject);
            }
        }
    }
}
