using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class RayCastGunScript : MonoBehaviour
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
    void Update()
    {
        UIManager.Instance.BulletOutPut(bulletNum);
        UIManager.Instance.AllBulletOutPut(AllBulletNum);
        if (Mouse.current.leftButton.isPressed && Time.time >= nextTimeFire && bulletNum > 0)
        {

            nextTimeFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Keyboard.current.rKey.isPressed) BulleteSet();

        CheckBullete();

        //if(bulletNum<=0) StartCoroutine(BulleteSetWait());
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

        //StartCoroutine(BulleteSet());

    }

    IEnumerator BulleteSetWait()
    {


        yield return new WaitForSeconds(3);

        isReload = true;
        Debug.Log("リロード完了");
        bulletNum = 20;


        Debug.Log("3s後のフラグ" + isReload);



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
}

