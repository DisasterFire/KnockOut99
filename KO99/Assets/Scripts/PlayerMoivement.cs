using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoivement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform tf;
    public Animator anim;
    public Vector3 InputKey;
    public float moveSpeed = 10;
    public bool facingRight = true;
    public float punchCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();

        anim.SetBool("IsPunching", false);
    }

    // Update is called once per frame
    void Update()
    {
        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = InputKey * moveSpeed;

        if (InputKey.x > 0 || InputKey.x < 0 || InputKey.z > 0 || InputKey.z < 0) { anim.SetBool("IsWalking", true); }
        else { anim.SetBool("IsWalking", false); }

        if ((InputKey.x > 0 || InputKey.z > 0) && !facingRight)
        {
            FlipSprite();
        }
        else if ((InputKey.x < 0 || InputKey.y < 0) && facingRight)
        {
            FlipSprite();
        }

        Punch();
    }

    void FlipSprite() 
    {
        // Rotate 180 degrees around the local y-axis
        transform.Rotate(0f, 180f, 0f);

        // Update the facing direction flag
        facingRight = !facingRight;
    }

    void Punch()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Punch");
            anim.SetBool("IsPunching", true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("IsKicking", true);
                Combo();
            }
        }
    }

    void Combo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (anim.GetBool("IsPunching"))
            {
                anim.Play("Kick");
                anim.SetBool("IsPunching", false);
                anim.SetBool("IsKicking", false);
            }
        }
    }
}
