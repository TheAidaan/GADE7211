using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenBackgroundScroll : MonoBehaviour
{
    const float speed= 0.005f;
    Renderer _rend;
    void Start()
    {
        _rend = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 offset = new Vector2(speed, speed);

        _rend.material.mainTextureOffset += offset;
        
    }
}
