using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashMov : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    private float endx = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (transform.position.x < endx)
        {
            Destroy(gameObject);
            UISys.score += 10;
        }else if (UISys.GameOver)
        {
            Destroy(gameObject);
        }
    }
}
