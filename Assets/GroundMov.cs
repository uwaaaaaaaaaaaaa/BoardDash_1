using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMov : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float endPos = -2.4f;
    public float startPos = 1.2f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        if(transform.position.x < endPos)
        {
            transform.position = new Vector3(startPos, startPosition.y, startPosition.z);
        }
    }
}
