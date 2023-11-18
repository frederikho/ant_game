using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class MainPlayerMovement : MonoBehaviour
{
    [SerializeField ]private float playerSpeed;
    private Camera camera;
    private Vector3 screenPosition;
    private Vector3 clickPosition;
    private Vector3 targetPosition;
    private Vector3 direction;

    public NavMeshAgent agent;

    private void Update()
    {
        float step = playerSpeed * Time.deltaTime;




        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Click!");
            /*clickPosition = Input.mousePosition;
            targetPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            targetPosition.z = 1;*/
            
            Ray ray = Camera.main.ScreenPointToRay(clickPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit));
            {
                agent.SetDestination(hit.point);
            }
            
        }
        
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

    }


}
