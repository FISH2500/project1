using UnityEngine;

public class ExObj : MonoBehaviour
{
    //爆発エフェクトを消すためだけのスクリプト。
    public float LifeTime = 5.0f;//寿命。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }
}
