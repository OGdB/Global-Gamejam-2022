using UnityEngine;

// Made it a monobehaviour so that you can Destroy whatever destroys it.
public class Health : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth = 100;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ChangeMaxHealth(int changeAmount) => maxHealth += changeAmount;

    private void Die()
    {
        print("Die!");
        Destroy(gameObject);
    }
}
