using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    GameController _gameController;
    PlayerController _playerController;
    SpriteRenderer spriteRenderer;
    Color colorSprite;
    public AudioSource _fxGameEfects;
    public AudioClip _explosion;
    float velocityHit;
    public bool isHit;
    bool invulnerable;
    public Transform[] positionHit;
    bool returning;
    public int idTarget;
    Transform playerPositionDefault;
    bool isVulnerable;
    float timeInvulnerable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _fxGameEfects.clip = _explosion;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        _gameController = FindAnyObjectByType<GameController>();
        _playerController = FindAnyObjectByType<PlayerController>();
        colorSprite = spriteRenderer.color;
        colorSprite.a = 1f;

        idTarget = 0;
        velocityHit = 15;
        isHit = false;
        returning = false;
        isVulnerable = true;
        timeInvulnerable = 5f;

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
            InvokeRepeating("spriteInvunerable", 1f, 0.1f);
            Invoke(nameof(cancelSpriteInvunerable), timeInvulnerable);
        }
        
    }

    private void spriteInvunerable() {
        
            if(colorSprite.a >= 0.5) {
                colorSprite.a = 0f;
            }
            else {
                colorSprite.a = 0.5f;
            }
            spriteRenderer.color = colorSprite;
        
    }

    private void collision() {
        isVulnerable = false;
        Invoke(nameof(vulnerable), timeInvulnerable);
        _fxGameEfects.Play();
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
        
        if (transform.position == positionHit[idTarget].position) {
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
            transform.position = Vector3.MoveTowards(transform.position, positionHit[idTarget].position, velocityHit * Time.deltaTime);
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
    private void cancelSpriteInvunerable() {
        colorSprite.a = 1f;
        spriteRenderer.color = colorSprite;
        CancelInvoke("spriteInvunerable");
    }

}
