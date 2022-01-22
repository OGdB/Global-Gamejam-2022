using UnityEngine;

// Made it a monobehaviour so that you can Destroy whatever destroys it.
public class Health : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;

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

    public void ChangeMaxHealth(int changeAmount)
    {
        if (maxHealth + changeAmount >= 1)
            maxHealth += changeAmount;
    }

    private void Die()
    {
        print("Die!");
        Destroy(gameObject);
    }
}
