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
    private bool isVulnerable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fxGame_efects.clip = _explosion;
        
        _gameController = FindAnyObjectByType<GameController>();
        _playerController = FindAnyObjectByType<PlayerController>();

        idTarget = 0;
        velocityHit = 15;
        isHit = false;
        returning = false;
        isVulnerable = true;

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
        if (isVulnerable) {
            collision();
        }
        
    }
    private void collision() {
        isVulnerable = false;
        Invoke(nameof(vulnerable), 5f);
        _fxGame_efects.Play();
        _gameController.life -= 1;

        
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
            if(_gameController.life <= 0) {
                Destroy(gameObject);
            }
            velocityHit = 35;
            transform.position = Vector3.MoveTowards(transform.position, playerPositionDefault.position, velocityHit * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
        else {
            velocityHit = 15;
            transform.position = Vector3.MoveTowards(transform.position, point[idTarget].position, velocityHit * Time.deltaTime);
            transform.Rotate(0f, 0f, -500f * Time.deltaTime);
        }


        if (transform.position == playerPositionDefault.position) {
            isHit=false;
            returning=false;
        }
        Debug.Log("Depois: " + transform.position);
    }

    void vulnerable() {
        isVulnerable = true;
    }

}
