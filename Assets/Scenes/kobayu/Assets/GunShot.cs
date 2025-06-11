using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GunShot : MonoBehaviour
{
    //弾丸を飛ばすのみ（クリックか、また別のキーにすることもできる。）
    //弾丸オブジェクトにrigidbodyを付ける必要あり
    public GameObject Dangan;//弾丸。
    public KeyCode ShotKey = KeyCode.Mouse0;
    public float ShotSpeed = 10;//弾丸を発射するスピード。
    public float CoolTime;//クールタイム。
    private float Timer;//タイマー。
    public GameObject ShotEx;//撃った時のフラッシュ。
    public Animator Ani;//撃った時のアニメーター。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = CoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Mouse.current.leftButton.isPressed){
            if(CoolTime < Timer){
                Shot();
                Timer = 0;
                Ani.SetBool("Shot",true);
            }
            Ani.SetBool("Shot",true);
        }else{
            Ani.SetBool("Shot",false);
        }
    }

    void Shot(){
        GameObject Dangan2 = Instantiate(Dangan,transform.position,transform.rotation);
        Dangan2.SetActive(true);
        Rigidbody rb = Dangan2.GetComponent<Rigidbody>();
        rb.AddForce(ShotSpeed * Dangan2.transform.forward);
        GameObject ShotEx2 = Instantiate(ShotEx,ShotEx.transform.position,ShotEx.transform.rotation);
        ShotEx2.SetActive(true);
    }
}
