using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    GameController _gameController;
    PlayerController _playerController;
    public AudioSource _fxGame_efects;
    public AudioClip _explosion;
    private float velocityHit;
    public bool isHit;
    private bool invulnerable;
    public Transform[] point;
    private bool returning;
    public int idTarget;
    private Transform playerPositionDefault;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fxGame_efects.clip = _explosion;
        _fxGame_efects.time = 0.4f;
        
        _gameController = FindAnyObjectByType<GameController>();
        _playerController = FindAnyObjectByType<PlayerController>();

        idTarget = 0;
        velocityHit = 20;
        isHit = false;
        returning = false;

    }

    // Update is called once per frame
    void Update()
    {
        playerPositionDefault = _playerController.Position[_playerController.idTarget];
        if (isHit) {
            movingToTarget();
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        collision();
    }
    private void collision() {
        
        
        if (gameObject.transform.position.y > 0 ) {
            idTarget = 0;
        }
        else {
            idTarget = 1;
        }

        isHit = true;

    }

    private void movingToTarget() {
        Debug.Log("Antes: " + transform.position);
        
        if (transform.position == point[idTarget].position) {
            returning = true;
        }

        if (returning) {
            transform.position = Vector3.MoveTowards(transform.position, playerPositionDefault.position, velocityHit * Time.deltaTime);
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, point[idTarget].position, velocityHit * Time.deltaTime);
        }


        if (transform.position == playerPositionDefault.position) {
            isHit=false;
            returning=false;
        }
        Debug.Log("Depois: " + transform.position);
    }

}
