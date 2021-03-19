using UnityEngine;

public class WorldMapBG : MonoBehaviour
{
    private SpriteRenderer rend;

    // Start is called before the first frame update
    private void Start()
    {
        rend = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ChangeSprite(Environment enviro)
    {
        Sprite toTurnTo = Enviroments.EnvironmentToSprite(enviro);

        rend.sprite = toTurnTo;
    }
}