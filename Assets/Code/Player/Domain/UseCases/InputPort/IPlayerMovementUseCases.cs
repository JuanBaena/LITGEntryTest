using UnityEngine;
public interface IPlayerMovementUseCases
{
    void movePlayer(Vector3 motion);
    void rotatePlayer(Vector3 eulers);
}
