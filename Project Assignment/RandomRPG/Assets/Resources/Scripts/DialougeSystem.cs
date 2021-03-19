using System.Collections.Generic;
using UnityEngine;

public class DialougeSystem : MonoBehaviour
{
    private Queue<string> sentences;

    // Start is called before the first frame update
    private void Start()
    {
        sentences = new Queue<string>();
    }
}