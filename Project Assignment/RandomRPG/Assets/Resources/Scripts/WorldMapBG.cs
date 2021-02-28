using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapBG : MonoBehaviour
{
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(Environment enviro)
    {
        Sprite toTurnTo = Enviroments.EnvironmentToSprite(enviro);

        rend.sprite = toTurnTo;
        Debug.Log("I'm Here");
    }

}
