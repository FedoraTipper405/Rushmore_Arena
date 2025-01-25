using UnityEngine;

public interface ITriggerCheckable
{
   
    bool IsInRangeToChase { get; set; }
    bool IsInRangeOfAttack { get; set; }
    void ChasePlayer(bool isInRangeToChase);
    void AttackPlayer(bool isInRangeOfAttack);
}
