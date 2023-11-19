using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class MainPlayerMovement : MonoBehaviour
{
    [SerializeField ]private float speed = 10f;
    private Camera mainCamera;
    private Vector3 screenPosition;
    private Vector3 clickPosition;
    private Vector3 targetPosition;
    private Vector3 direction;
    public LayerMask collisionMask;
    public float rotationSpeed = 360f;
    public Transform target;
    public AntSettings settings;
    PerceptionMap.Entry[] pheromoneEntries;
    public enum State {Following}
    Vector2 lastPheromonePos;
    AntColony colony;
    float leftFollowingTime ;

    private void Start()
    {
        mainCamera = Camera.main;
        lastPheromonePos = transform.position;


        const int maxPerceivedPheromones = 1024;
        pheromoneEntries = new PerceptionMap.Entry[maxPerceivedPheromones];
        leftFollowingTime = Time.time;
    }

    private void Update()
    {
        //float step = playerSpeed * Time.deltaTime;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        
        float distance = Vector3.Distance(transform.position, mousePosition);
        float speed = CalculateSpeed(distance);
        
        RotateTowardsMouse(mousePosition);
        MoveToPosition(mousePosition, speed);
        UpdateCameraPosition();
        // HandlePheromonePlacement();
        
       
    }

    void RotateTowardsMouse(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, targetRotation, 20*rotationSpeed * Time.deltaTime);
    }
    void MoveToPosition(Vector3 targetPosition, float speed)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Check for collisions before moving
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, speed * Time.deltaTime);

        if (hit.collider == null || hit.collider.CompareTag("Boundary"))
        {
            // No collision or collided with a boundary
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        // You can add additional conditions for different types of colliders (e.g., collectibles, enemies, etc.).
    }
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        
        void UpdateCameraPosition()
        {
            // Update the camera position to follow the player
            Vector3 playerPos = transform.position;
            playerPos.z = mainCamera.transform.position.z; // Maintain the same camera depth
            mainCamera.transform.position = playerPos;
        }
        float CalculateSpeed(float distance)
        {
            // You can customize the speed calculation based on your requirements
            // Here, I'm using a simple linear function, but you can experiment with other formulas
            float maxDistance = 10f; // Adjust this value based on your game's requirements
            float minSpeed = 0f; // Adjust this value based on your game's requirements
            float maxSpeed = 10f; // Adjust this value based on your game's requirements

            // Calculate speed as a function of distance
            float speed = Mathf.Lerp(minSpeed, maxSpeed, distance / maxDistance);

            return speed;
        }
        
    void HandlePheromonePlacement()
    {
            float t = 1 - (Time.time - leftFollowingTime) / settings.pheromoneRunOutTime;
            t = Mathf.Lerp(0.5f, 1, t);
            colony.followMarkers.Add(transform.position, t);
            lastPheromonePos = transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * settings.dstBetweenMarkers * 0.2f;
            Debug.Log(lastPheromonePos );
    }

    // TODO:
    // - Check for click
    // - Add raycast from player to click location
    // - Save ant 
    /*Ray ray = Camera.main.ScreenPointToRay(clickPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit));
            {
                agent.SetDestination(hit.point);
            }*/
}




