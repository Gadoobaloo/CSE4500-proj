using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject myWorldMap;
    WorldMap myWorldMapScript;
    
    // should only be "left", "middle", or "right"
    public string id;

    private void Start()
    {
        myWorldMapScript = myWorldMap.GetComponent<WorldMap>();
    }

    private void OnMouseDown()
    {
        myWorldMapScript.getClick(id);
    }
}
