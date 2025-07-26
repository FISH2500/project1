using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class RayCastGunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate=15f;
    public int BulletNum;
    public int MaxBulletNum;
    public int AllBulletNum;
    public Camera Fpscam; 
    private float nextTimeFire;
    private int bulletNum=20;
    public bool isReload=true;
    private bool isbullets;
    void Update()
    {
        UIManager.Instance.BulletOutPut(bulletNum);
        UIManager.Instance.AllBulletOutPut(AllBulletNum);
        if (Mouse.current.leftButton.isPressed && Time.time>=nextTimeFire&&bulletNum>0)
        {
            
            nextTimeFire = Time.time+1f/fireRate;
            Shoot();
        }

        if(Keyboard.current.rKey.isPressed) BulleteSet();

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
        if(Physics.Raycast(Fpscam.transform.position, Fpscam.transform.forward,out hit, range)) 
        {
            Debug.Log(hit.transform.name);
            TargetScript target=hit.transform.GetComponent<TargetScript>();

            if (target!=null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void Reload() 
    {

            Debug.Log("�����[�h��");

            //StartCoroutine(BulleteSet());

    }

    IEnumerator BulleteSetWait()
    {


        yield return new WaitForSeconds(3);

        isReload = true;
        Debug.Log("�����[�h����");
        bulletNum = 20;


        Debug.Log("3s��̃t���O" + isReload);



    }

    public void BulleteSet()
    {
        if (bulletNum >= 0&&bulletNum<20)
        {
            int needbullete = MaxBulletNum - bulletNum;//�����[�h�����Ƃ��ɕ�[�����e��
            Debug.Log("�K�v�Ȓe��" + needbullete + "���ׂĂ̒e��" + AllBulletNum);
            if (AllBulletNum <= needbullete)//�e��������Ȃ��ꍇ
            {
                bulletNum += AllBulletNum;

                AllBulletNum = 0;
            }
            else
            {
                AllBulletNum -= needbullete;//���ׂĂ̒e������K�v�Ȓe��������
                Debug.Log("�����[�h����" + bulletNum);

                bulletNum += needbullete;
            }


        }
        
    }
    void CheckBullete()
    {
        if (AllBulletNum <= 0 && bulletNum <= 0)
        {
            isbullets = true;
            Debug.Log("�e�؂�");
        }
    }
}

