using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKing : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameEnvironment.Singleton.AddBotter(this.gameObject);
    }
}
