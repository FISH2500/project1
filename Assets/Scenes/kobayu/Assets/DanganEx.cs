using UnityEngine;

public class DanganEx : MonoBehaviour
{
    //弾丸の爆発を再現
    public GameObject ExObj;//爆発エフェクト。
    public float LifeTime = 5.0f;//弾丸の寿命。
    private float Timer = 0;//弾丸の消える時間を測るタイマー。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= LifeTime){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Dangan"){
            GameObject ExObj2 = Instantiate(ExObj,transform.position,transform.rotation);
            ExObj2.SetActive(true);
            Destroy(gameObject);
            Debug.Log("CollisionDangan!!");
        }
    }
}
