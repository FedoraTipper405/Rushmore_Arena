using UnityEngine;

public interface IEnemyMoveable
{
    Rigidbody2D RB { get; set; }
    bool IsFacingRight { get; set; }
    void MoveEnemy(Vector2 velocity);
    void CheckFacing(Vector2 velocity);
}
