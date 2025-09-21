using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoivement : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 InputKey;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = InputKey * moveSpeed;
    }
}
