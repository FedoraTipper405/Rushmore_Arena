using UnityEngine;

public interface ITriggerCheckable
{
   
    bool IsInRangeToChase { get; set; }
    void ChasePlayer(bool isInRangeToChase);
}
