using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float Damage;//この攻撃判定の攻撃力
    private PlayerHPCon PHC;//プレイヤーのHPを操作するためのクラス。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PHC = other.GetComponent<PlayerHPCon>();
            if (PHC != null)
            {
                PHC.HPUDPlayer(Damage * -1);
            }
            else
            {
                Debug.LogError("Playerタグが付いているオブジェクトにPlayerHPConスクリプトが付与されていません。");
            }
           
        }
    }
}
