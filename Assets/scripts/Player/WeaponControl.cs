using UnityEngine;
using UnityEngine.Events;

public class WeaponControl : MonoBehaviour
{
    UnityEvent enemyKilled;
    public float weaponDamage = 10;
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "enemy")
        {
            StatsControl enemyStats = otherObject.GetComponent<StatsControl>();
            float pointsToAdd = enemyStats.pointsOnKill;
            PlayerSingleton.Instance.UpdateScore(pointsToAdd);
            enemyStats.ReceieveDamage(weaponDamage);
        }
    }
}
