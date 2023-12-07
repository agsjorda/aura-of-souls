using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;

    [SerializeField] private float parallaxEffect;

    private float startPos;
    private float length;
    void Start()
    {
        cam = GameObject.Find("PlayerCamera");

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;
    }

    void Update()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect; //distance the background has moved
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect); //distance needed to reach camera position

        transform.position = new Vector3(startPos + distanceToMove, transform.position.y);

        if (distanceMoved > startPos + length) startPos += length;
        else if (distanceMoved < startPos - length) startPos -= length;
    }
}
