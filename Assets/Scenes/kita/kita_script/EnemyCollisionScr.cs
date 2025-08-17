using UnityEngine;

public class EnemyCollisionScr : MonoBehaviour
{
    public TargetScript target;

    public void Send_Damage(float damage) 
    {
        target.TakeDamage(damage);
    }
}
