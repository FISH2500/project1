using UnityEngine;

public class FlashEnemy : MonoBehaviour
{
    private FlashByEnemy flashByEnemy_;//目つぶしをするときに参照するPlayrについているスクリプト。
    public float FlashTime = 1.0f;//目つぶしの時間
    public GameObject FlashBanObj;//目つぶしの際、爆発するエフェクト。
    public float LifeTime = 5.0f;//爆発した際残る時間。

    void Start()
    {
        FlashBanObj.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flashByEnemy_ = other.GetComponent<FlashByEnemy>();
            if (flashByEnemy_ != null)
            {
                flashByEnemy_.FlashPlayer(FlashTime);
                FlashBanObj.SetActive(true);
                Destroy(gameObject, LifeTime);
            }
            else
            {
                Debug.LogWarning("FlashByEnemyが見つかりません:" + other.name);
            }
        }
    }
}
