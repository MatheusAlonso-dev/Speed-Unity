using UnityEngine;
using UnityEngine.InputSystem;
using NUnit.Framework.Internal;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private InputSystem_Actions inputActions;

    public Transform Player;
    public Transform[] Position;
    public float velocity;

    private int idTarget;


    private void Awake() {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }

    void Start()    
    {
        Player.position = new Vector3(-25,Position[0].position.y,0);
        idTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

    }

    

    private void movePlayer() {
        if (Player != null) {

            if (inputActions.Player.Move.WasPressedThisFrame()) {
                Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();
                if(input.y > 0) {
                    idTarget = 0;
                }
                else {
                    idTarget = 1;
                }
            }

            if (Position[idTarget].position != Player.position) {
                Player.position = Vector3.MoveTowards(Player.position, Position[idTarget].position, velocity * Time.deltaTime);
                if (idTarget == 0) {
                    Player.transform.rotation = Quaternion.Euler(0, 0, 20);
                }
                else {
                    Player.transform.rotation = Quaternion.Euler(0, 0, -20);
                }
            }
            else {

                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
        }
    }

}
