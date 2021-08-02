using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{

    public Slider sliderr;

    void Start()
    {
        if (GameManager.Instance.cnt <= 0)
        {
            sliderr.value = 0.3f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
