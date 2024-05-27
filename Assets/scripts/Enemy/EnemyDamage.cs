using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float attackDamage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        int contactCount = other.GetContacts(other.contacts);

        for(int i = 0; i < contactCount; i++)
        {
            ContactPoint2D contact = other.contacts[i];
            GameObject contactObj = contact.collider.gameObject;
            Debug.Log("Collided with child: " + contactObj.name + " " + contactObj.tag);
            if(contactObj.tag == "Player")
            {
                Debug.Log("hit player");
                StatsControl otherObjectStats = contactObj.GetComponent<StatsControl>();
                otherObjectStats.ReceieveDamage(attackDamage);
            }
        }
   
    }

}
