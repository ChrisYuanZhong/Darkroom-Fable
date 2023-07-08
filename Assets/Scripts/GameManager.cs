using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
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
    public GameObject backGround;
    public List<ScriptPerFrame> backGroundScripts = new List<ScriptPerFrame>()
    {
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
        new ScriptPerFrame(true, 0, 0),
    };

    // Start is called before the first frame update
    void Start()
    {
        backGround.GetComponent<SceneComponentAutoGen>().GenerateFollowingFrames(backGroundScripts, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
