using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float sencivity;
    public Camera cam;


    private void Start()
    {
        cam = this.GetComponent<Camera>();
        player = this.GetComponentInParent<Transform>();


    }
    private void Update()
    {
        
    }
}
