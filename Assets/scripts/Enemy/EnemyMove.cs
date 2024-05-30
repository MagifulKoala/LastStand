using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    public Transform playerTransform;
    Rigidbody2D rb;
    public float moveSpeed = 1;
    float random;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        int randomInt = Random.Range(2, 9);
        random = randomInt / 10f;
        try
        {
            playerTransform = PlayerSingleton.Instance.getTransform();
        }
        catch (System.Exception)
        {
        }
    }

    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        if(playerTransform == null)
        {
            playerTransform = PlayerSingleton.Instance.transform;
        }
        Vector3 moveDir = playerTransform.position - transform.position;
        moveDir = Vector3.Normalize(moveDir);

        rb.velocity = moveDir * (moveSpeed + random);
    }
}
