using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    
    // how fast we want our player to move
    public float moveSpeed = 15f;
    // how fast we want our player to rotate
    public float rotateSpeed = 55f;

    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    private float VerInput;
    private float HorInput;
    private CapsuleCollider _col;
    private Rigidbody rb;

    // store the bullet prefab
    public GameObject bullet;

    // hold te bullet speed
    public float bulletSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        VerInput = Input.GetAxis("Vertical") * moveSpeed;
        HorInput = Input.GetAxis("Horizontal") * rotateSpeed;

        /*        this.transform.Translate(Vector3.forward * VerInput * Time.deltaTime);
                this.transform.Rotate(Vector3.up * HorInput * Time.deltaTime); */
    
    }

  

    void FixedUpdate()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        } 
        // store our left and right rotation
        Vector3 rotation = Vector3.up * HorInput;
        // Quaternion vs Euler
        Quaternion angleR = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        rb.MovePosition(this.transform.position + this.transform.forward
            * VerInput * Time.deltaTime);
        rb.MoveRotation(rb.rotation * angleR);

        // For mouse click , GetMouseButtonDown
        // 0 for left click
        // 1 for right click
        // 2 for middle button
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position,
                this.transform.rotation) as GameObject;
            // return and store rigidbody component on newBullet
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            // Velocity
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }

    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
            _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom,
            distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

}
