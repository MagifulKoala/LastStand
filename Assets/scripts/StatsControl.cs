using UnityEngine;
using UnityEngine.Events;

public class StatsControl : MonoBehaviour
{
    public float totalHealth = 10;
    public float currentHealth = 10f;
    public float pointsOnKill = 1;

    public UnityEvent playerDied;

    private void Start()
    {
        currentHealth = totalHealth;   
    }

    public void ReceieveDamage(float pIncomingDamage)
    {
        currentHealth -= pIncomingDamage;
        if (this.gameObject.tag == "Player")
        {
            UIControl.Instance.UpdateHealthBar((float)currentHealth/(float)totalHealth, totalHealth);
        }
        if (currentHealth <= 0)
        {
            Debug.Log($"{this.gameObject.name} has died !");
            if(this.gameObject.tag == "Player")
            {
                playerDied?.Invoke();
            }
            Destroy(this.gameObject, 0.3f);
        }
    }


}
