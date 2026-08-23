using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMov : MonoBehaviour
{
    public float moveSpeed = 0.7f;
    private float endx = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if(transform.position.x < endx)
        {
            Destroy(gameObject);
        }
    }
}
