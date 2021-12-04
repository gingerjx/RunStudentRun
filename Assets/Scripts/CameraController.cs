using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float height = 2f * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        Camera.main.transform.position = new Vector3(width / 2, height / 2, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
