using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starter : MonoBehaviour
{
    [SerializeField] CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.alpha = 1;
    }

    
}
