using UnityEngine;

public class StatsControl : MonoBehaviour
{
    public float health = 10f;

    public void ReceieveDamage(float pIncomingDamage)
    {
        health -= pIncomingDamage;
        if(health <= 0)
        {
            Debug.Log($"{this.gameObject.name} has died !");
            
            //TODO: handle player case. when player dies nulls everywhere as it is destroyed
            Destroy(this.gameObject, 0.3f);
        }
    }


}
