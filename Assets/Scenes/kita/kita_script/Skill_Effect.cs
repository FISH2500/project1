using UnityEngine;

public class Skill_Effect : MonoBehaviour
{
    public SkillDataBase skilldata;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkillCheck(int id) 
    {
        Debug.Log(skilldata.data[id].SkillName);
    }
}
