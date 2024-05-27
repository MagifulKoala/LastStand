using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    private void Update()
    {
        PlayerMoveControl();
    }

    void PlayerMoveControl()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * moveSpeed;
        
        Vector3 moveVector = new Vector3(horizontal, vertical,0 );

        rb.velocity = moveVector;
    }

}
