using UnityEngine;
using System.Collections;

public class animControlTurnip : MonoBehaviour {


    public Animator PlayerTurnip, TurnipV9;

   void Start()
    {
        TurnipV9 = GetComponent<Animator>();
        TurnipV9.SetBool("OnGround", true);
    }
    void Update()
    {
        CopiarAnimacoes();
    }
    void CopiarAnimacoes()
    {
        if(PlayerTurnip.GetBool("OnGround") == true)
        {
            TurnipV9.SetBool("OnGround", true);
            if (PlayerTurnip.GetFloat("Forward") >= 0.1)
            {
                TurnipV9.SetBool("Running", true);
                if (PlayerTurnip.GetBool("isAttacking") == true)
                {
                    TurnipV9.SetBool("Attack", true);
                }

                else
                {
                    TurnipV9.SetBool("Attack", false);
                }
            }
            else
            {
                TurnipV9.SetBool("Running", false);
                if (PlayerTurnip.GetBool("isAttacking") == true)
                {
                    TurnipV9.SetBool("Attack", true);
                }
                else
                {
                    TurnipV9.SetBool("Attack", false);
                }
                if (PlayerTurnip.GetBool("Hurt") == true)
                {
                    TurnipV9.SetBool("Death", true);
                }
                else TurnipV9.SetBool("Death", false);
            }

        }
        else
        {
            TurnipV9.SetBool("OnGround", false);
            TurnipV9.SetBool("Running", false);
            TurnipV9.SetFloat("Jump",(PlayerTurnip.GetFloat("Jump")));
        }
    }
}
