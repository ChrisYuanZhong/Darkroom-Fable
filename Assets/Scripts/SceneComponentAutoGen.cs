using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// The game scene is a roll film, so we will put all the components into the first frame and let them generate themselves after each length of the roll film block.
public class SceneComponentAutoGen : MonoBehaviour
{
    public float frameLength = 2.4f;
    
    private List<GameObject> generatedGameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DestroyFollowingFrames(int firstFrameNumber)
    {
        // Delete all the generated game objects after this frame.
        for (int i = firstFrameNumber; i < generatedGameObjects.Count; i++)
        {
            Destroy(generatedGameObjects[i]);
            // Delete the game object from the list.
            generatedGameObjects.RemoveAt(i);
        }
    }

    public void GenerateFollowingFrames(List<ScriptPerFrame> scriptsPerFrame, int firstFrameNumber)
    {
        DestroyFollowingFrames(firstFrameNumber);

        // Regenerate all the game objects after this frame.
        for (int i = firstFrameNumber; i < scriptsPerFrame.Count; i++)
        {
            if (scriptsPerFrame[i].render)
            {
                // Duplicate this game object itself after i * frameLength pixels along x axis.
                GameObject generatedGameObject = Instantiate(this.gameObject, new Vector3(transform.position.x + i * frameLength, transform.position.y, transform.position.z), transform.rotation);
                generatedGameObjects.Add(generatedGameObject);
            }
        }
    }
}
