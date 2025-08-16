using UnityEngine;
using UnityEngine.InputSystem;

public class player_con : MonoBehaviour
{
    private Rigidbody rb;//リジッドボディ。
    public float MoveSpeed;//動くスピード。
    public Animator Ani;//アニメーター。
    bool isCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //リジッドボディを取得
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
       // VendingCheck();
    }

    void PlayerMove()
    {
        if (Time.timeScale == 1)
        {
            //WASD操作
            if (Keyboard.current.wKey.isPressed)
            {
                rb.AddForce(transform.forward * MoveSpeed);
                Ani.SetBool("W", true);
            }
            else
            {
                Ani.SetBool("W", false);
            }
            if (Keyboard.current.sKey.isPressed)
            {
                rb.AddForce(transform.forward * -MoveSpeed);
                Ani.SetBool("S", true);
            }
            else
            {
                Ani.SetBool("S", false);
            }
            if (Keyboard.current.dKey.isPressed)
            {
                rb.AddForce(transform.right * MoveSpeed);
                Ani.SetBool("D", true);
            }
            else
            {
                Ani.SetBool("D", false);
            }
            if (Keyboard.current.aKey.isPressed)
            {
                rb.AddForce(transform.right * -MoveSpeed);
                Ani.SetBool("A", true);
            }
            else
            {
                Ani.SetBool("A", false);
            }
        }
        else
        {
            Debug.Log("時間停止中");
        }
    }

    void VendingCheck()//自販機を調べた場合
    {
        if (Eventcatch.Instance.isHit&& Keyboard.current.bKey.wasPressedThisFrame)
        {

            Time.timeScale = BooltoInt(isCheck);


            isCheck = !isCheck;


            UIManager.Instance.ShowVending(isCheck);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    int BooltoInt(bool toInt)
    {
        return toInt ? 1 : 0;
    }
}
