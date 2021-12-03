using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpManager : MonoBehaviour
{
    public int currentHp = 100;
    public int maxHp = 100;
    public P_movement hp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hurtPlayer(int dmgToGive)
    {
        currentHp -= dmgToGive;
        if(currentHp <= 0)
        {
            hp.isDead = true;
        }
    }
}
