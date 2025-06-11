using UnityEngine;
using System.Collections.Generic;

public class tuiseki_obj : MonoBehaviour
{
    public Transform TuisekiTarget;//追跡するターゲット。
    private bool Hit;//オブジェクトにカメラが当たってるか？
    private List<GameObject> HitObj = new List<GameObject>();
    public string HitTagName;//当たっちゃいけないオブジェのタグ。
    private float ZOffset;//当たった場合、加算するZオフセット。
    public float MoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HitObj.Count > 0){
            Hit = true;
        }else{
            Hit = false;
        }
        /*if(Hit){
            ZOffset += 0.05f;
        }else{
            ZOffset -= 0.05f;
            if(ZOffset <= 0){
                ZOffset = 0;
            }
        }*/
        Vector3 EndV3 = TuisekiTarget.position;
        EndV3.z += ZOffset;
        Vector3 StartV3 = transform.position;
        transform.position = Vector3.Lerp(StartV3, EndV3, MoveSpeed);

        HitObj.RemoveAll(obj => obj == null);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == HitTagName){
            HitObj.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == HitTagName){
            HitObj.Remove(other.gameObject);
        }
    }
}
