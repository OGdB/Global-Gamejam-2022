using System.Collections;
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

    public bool Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Kill();
            return true;
        }
        return false;
    }
    public void Kill()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
    }

    public void ChangeMaxHealth(int changeAmount)
    {
        if (maxHealth + changeAmount >= 1)
            maxHealth += changeAmount;
    }
}
