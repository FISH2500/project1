using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float Health = 50f;

    public void TakeDamage(float amount) 
    {
        Health -= amount;
        if(Health <= 0f) 
        {
            Die();
        }
    }

    void Die() 
    { 
        Destroy(gameObject);
    }
}
