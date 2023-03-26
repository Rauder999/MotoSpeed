using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistaceController : MonoBehaviour
{
    [SerializeField] private Text distanceText;

    private float distance;
    private float previousX;

    void Start()
    {
        previousX = transform.position.x; 
    }

    
    void Update()
    {
        if(transform.position.x > previousX)
        {
            distance += transform.position.x - previousX;
            previousX = transform.position.x;
        }
        distanceText.text = distance.ToString("0.00");
    }
}
