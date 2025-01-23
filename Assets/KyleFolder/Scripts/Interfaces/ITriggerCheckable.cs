using UnityEngine;

public interface ITriggerCheckable
{
    bool IsInRange { get; set; }
    void AttackPlayer(bool isInRange);
}
