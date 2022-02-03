using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectibleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Time.frameCount % 314 / 100f;
        Vector3 prev = transform.position;
        transform.position = new Vector3(prev.x, Mathf.Sin(angle) + 2, prev.z);
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
