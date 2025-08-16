using UnityEngine;
using UnityEngine.UI;

public class PlayerHPCon : MonoBehaviour
{
    public HPClass HPCls;//HPを操作するために必要なクラス。
    private float timer = 0;//HPが再回復するために必要なタイマー。
    public float MedicStartTime;//回復し始めるまでの時間。
    public float MedicSpeed;//一秒にどのくらいのHPが回復するか？
    public Slider slider;//HPスライダー。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HPCls.HP = HPCls.MaxHP;
        slider.maxValue = HPCls.MaxHP;
        slider.value = HPCls.HP;
    }
    void Update()
    {
        if (HPCls.HP <= HPCls.MaxHP)
        {
            if (timer > MedicStartTime)
            {
                HPCls.HP += MedicSpeed * Time.deltaTime;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            timer = 0;
        }
    }
    public void HPUDPlayer(float D)
    {
        HPCls.HPUD(D);
        slider.value = HPCls.HP;
    }
}
