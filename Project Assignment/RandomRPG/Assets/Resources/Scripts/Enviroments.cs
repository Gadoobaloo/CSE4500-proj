using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Environment { None, Beach, Castle, City, Desert, Forest, Snow, Space, Underwater, Volcano }

public class Enviroments : MonoBehaviour
{
    static private List<Sprite> Backgrounds = new List<Sprite>();

    //private SpriteRenderer rend;

    static private int numOfEnvironments;

    private void Start()
    {
        if (Backgrounds.Capacity <= 0)
        {
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgcharchoice"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgbeach"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgcastle"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgcity"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgdesert"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgforest"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgsnow"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgspace"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgunderwater"));
            Backgrounds.Add(Resources.Load<Sprite>("Sprites/Backgrounds/bgvolcano"));
        }

        Backgrounds.TrimExcess();
        numOfEnvironments = Backgrounds.Capacity;
        Debug.Log("backgrounds list size = " + Backgrounds.Capacity);
    }

    static public int GetNumOfEnvironments()
    {
        return numOfEnvironments;
    }

    static public Sprite EnvironmentToSprite(Environment enviro)
    {
        switch (enviro)
        {
            case Environment.Beach:
                Debug.Log("Beach");
                return Backgrounds[1];
            case Environment.Castle:
                Debug.Log("Castle");
                return Backgrounds[2];
            case Environment.City:
                Debug.Log("City");
                return Backgrounds[3];
            case Environment.Desert:
                Debug.Log("Desert");
                return Backgrounds[4];
            case Environment.Forest:
                Debug.Log("Forest");
                return Backgrounds[5];
            case Environment.Snow:
                Debug.Log("Snow");
                return Backgrounds[6];
            case Environment.Space:
                Debug.Log("Space");
                return Backgrounds[7];
            case Environment.Underwater:
                Debug.Log("Underwater");
                return Backgrounds[8];
            case Environment.Volcano:
                Debug.Log("Volcano");
                return Backgrounds[9];
            default:
                return Backgrounds[0];
        }
    }

    static public Environment IntToEnvironment(int toConvert)
    {
        switch (toConvert)
        {
            case 1:
                return Environment.Beach;
            case 2:
                return Environment.Castle;
            case 3:
                return Environment.City;
            case 4:
                return Environment.Desert;
            case 5:
                return Environment.Forest;
            case 6:
                return Environment.Snow;
            case 7:
                return Environment.Space;
            case 8:
                return Environment.Underwater;
            case 9:
                return Environment.Volcano;
            default:
                return Environment.None;
        }
    }


}
