using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Animator playerAnimator;

    public void LeftAttack()
    {
        playerAnimator.SetTrigger("LeftAttack");
    }
    public void RightAttack()
    {
        playerAnimator.SetTrigger("RightAttack");
    }
}
