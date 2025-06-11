using UnityEngine;

public class WallDestroySystem : MonoBehaviour
{
    public float timer;//この時間が長いほど優先される
    private float MaxTime = 10;//10秒が上限
    public string TagName = "Untagged";//かぶったらダメなタグ。
    public GameObject DestroyObj;//かぶったら消すオブジェ
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MaxTime < timer) return;
        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTrigger!!");
        if(other.gameObject.tag == TagName){
            Debug.Log("OnTrigger" + TagName + "!!");
            WallDestroySystem WallDestroySystem_scr = other.gameObject.GetComponent<WallDestroySystem>();
            if(WallDestroySystem_scr.timer > timer){
                Destroy(DestroyObj);
            }
        }
    }
}
