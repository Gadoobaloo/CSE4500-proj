using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject myWorldMap;
    private WorldMap myWorldMapScript;

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