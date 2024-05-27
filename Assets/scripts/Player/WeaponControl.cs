using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public float weaponDamage = 10;
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "enemy")
        {
            StatsControl enemyStats = otherObject.GetComponent<StatsControl>();
            enemyStats.ReceieveDamage(weaponDamage);
        }
    }
}
