using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class RayCastGunScript2 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public int BulletNum;
    public int MaxBulletNum;
    public int AllBulletNum;
    public Camera Fpscam;
    private float nextTimeFire;
    private int bulletNum = 20;
    public bool isReload = true;
    private bool isbullets;
    public bool CanShot;//アニメーターで制御し、これがtrueになったら撃つ
    public Animator GunAni;
    public bool SemiAuto = true;//セミオートかフルオートか
    private int MouseFrameTime = 10;
    private int MouseFrameTimer = 0;
    public bool ShotNow = false;
    private float isADS = 0.0f;//ADSしてるか？
    public bool ReloadNow = false;//リロードしてるか？アニメーターで管理
    void Update()
    {
        //UIManager.Instance.BulletOutPut(bulletNum);
        //UIManager.Instance.AllBulletOutPut(AllBulletNum);
        MouseFrameTimer++;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            MouseFrameTimer = 0;
        }
        bool isCanShot = false;
        if (SemiAuto)
        {
            isCanShot = MouseFrameTimer < MouseFrameTime && Time.time >= nextTimeFire/* && bulletNum > 0*/;
        }
        else
        {
            isCanShot = Mouse.current.leftButton.isPressed && Time.time >= nextTimeFire/* && bulletNum > 0*/;
        }
        if (isCanShot)
        {
            nextTimeFire = Time.time + 1f / fireRate;
            GunAni.SetBool("Shot", true);
            Debug.Log("Shot");
        }
        else if (!ShotNow)
        {
            GunAni.SetBool("Shot", false);
        }

        if (Keyboard.current.rKey.isPressed)
        {
            BulleteSet();
            Reload();//リロードモーション再生　きたはらにBulletSetと同時に行わせるのを任せる。
        }else if (!ReloadNow)
        {
            GunAni.SetBool("Reload", false);//リロードモーション終了
        }

        CheckBullete();

        if (CanShot)
        {
            Shoot();
        }

        //if(bulletNum<=0) StartCoroutine(BulleteSetWait());

        Debug.Log("残弾:" + bulletNum);

        if (Mouse.current.rightButton.isPressed)
        {
            if (isADS < 1.0f)
            {
                isADS += 10 * Time.deltaTime;
            }
        }
        else
        {
            if (isADS > 0.0f)
            {
                isADS -= 10 * Time.deltaTime;
            }
        }
        if (isADS > 0.99f)
        {
            ADS();
        }
        GunAni.SetFloat("IsADS", isADS);
        Debug.Log("isADS = " + isADS);
    }

    void Shoot()
    {

        if (bulletNum <= 0)
        {
            return;
        }
        Debug.Log("Fire!!");
        bulletNum--;

        RaycastHit hit;
        if (Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            //TargetScript target = hit.transform.GetComponent<TargetScript>();
            EnemyCollisionScr enemycol = hit.transform.GetComponent<EnemyCollisionScr>();
            if (enemycol != null)
            {
                switch (hit.transform.tag)
                {
                    case "Head": Debug.Log("頭"); enemycol.Send_Damage(20); break;

                    case "Body": Debug.Log("体"); enemycol.Send_Damage(10); break;

                    case "Leg": Debug.Log("足"); enemycol.Send_Damage(5); break;
                }
            }
        }
    }

    void Reload()
    {

        Debug.Log("リロード中");
        GunAni.SetBool("Reload", true);

        //StartCoroutine(BulleteSet());

    }

    public void BulleteSet()
    {
        if (bulletNum >= 0 && bulletNum < 20)
        {
            int needbullete = MaxBulletNum - bulletNum;//リロードしたときに補充される弾数
            Debug.Log("必要な弾数" + needbullete + "すべての弾数" + AllBulletNum);
            if (AllBulletNum <= needbullete)//弾数が足りない場合
            {
                bulletNum += AllBulletNum;

                AllBulletNum = 0;
            }
            else
            {
                AllBulletNum -= needbullete;//すべての弾数から必要な弾数分引く
                Debug.Log("リロード完了" + bulletNum);

                bulletNum += needbullete;
            }


        }

    }
    void CheckBullete()
    {
        if (AllBulletNum <= 0 && bulletNum <= 0)
        {
            isbullets = true;
            Debug.Log("弾切れ");
        }
    }
    void ADS()
    {
        
    }
}

