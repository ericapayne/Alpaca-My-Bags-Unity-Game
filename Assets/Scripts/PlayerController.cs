using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;  // Our current focus: Item, Enemy etc.

    public Animator animator;

    //public LayerMask movementMask; // Filter out everything not walkable

    Camera cam;
    //PlayerMotor motor; // Reference to our motor

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        // motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // if we press left mouse
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // motor.MoveToPoint(hit.point);
                // Move our player to what we hit
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                // stop focusing any objects;
                // RemoveFocus();
                SetFocus(interactable);
            }
        }
        */
        // If we press right mouse
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            animator.SetBool("IsEating", true);
            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit and interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                
                // If we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }        
        }else
            {
                animator.SetBool("IsEating", false);
            } 
       
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
           // motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);


    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        //motor.StopFollowingTarget();
    }
}

