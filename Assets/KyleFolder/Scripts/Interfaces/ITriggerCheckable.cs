using UnityEngine;

public interface ITriggerCheckable
{
   
    bool IsInRangeToChase { get; set; }
    bool ObjectInWay { get; set; }
    void ChasePlayer(bool isInRangeToChase);
    void ObjectInTheWay(bool objectInWay);
}
