using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStop : MonoBehaviour
{
    public playerMovement PlayerMovement;
    public CameraFollow smartCamera;
    public ObstacleBehaviour[] ObstacleBehaviour;
    public RotatingObstacle[] RotatingObstacle;
    private cubeMechanic CubeMechanic;
    public MovingEnemySoldier[] MovingSoldier;
    
    private void OnCollisionEnter(Collision other)
    {
        smartCamera.enabled = false;
        PlayerMovement.enabled = false;
        //MovingEnemy.enabled = false;You need to close soldiers movement
        foreach (var obs in ObstacleBehaviour)
        {
            obs.enabled = false;
        }

        foreach (var ro in RotatingObstacle)
        {
            ro.enabled = false;
        }
        
        foreach (var mes in MovingSoldier)
        {
            mes.enabled = false;
        }
        
    }
}
