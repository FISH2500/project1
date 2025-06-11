using UnityEngine;
using UnityEngine.InputSystem;

public class player_con : MonoBehaviour
{
    private Rigidbody rb;//リジッドボディ。
    public float MoveSpeed;//動くスピード。
    public Animator Ani;//アニメーター。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //リジッドボディを取得
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //WASD操作
        if(Keyboard.current.wKey.isPressed){
            rb.AddForce(transform.forward * MoveSpeed);
            Ani.SetBool("W",true);
        }else{
            Ani.SetBool("W",false);
        }
        if(Keyboard.current.sKey.isPressed){
            rb.AddForce(transform.forward * -MoveSpeed);
            Ani.SetBool("S",true);
        }else{
            Ani.SetBool("S",false);
        }
        if(Keyboard.current.dKey.isPressed){
            rb.AddForce(transform.right * MoveSpeed);
            Ani.SetBool("D",true);
        }else{
            Ani.SetBool("D",false);
        }
        if(Keyboard.current.aKey.isPressed){
            rb.AddForce(transform.right * -MoveSpeed);
            Ani.SetBool("A",true);
        }else{
            Ani.SetBool("A",false);
        }
    }
}
