using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameController _gameController;
    float velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
        velocity = 2;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Mathf.Pow(_gameController.velocity, 3); ;
        moverEnemy();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("TRIGGER DETECTADO(enemy): " + other.gameObject.name);
    }

    private void moverEnemy() {
        transform.Translate(Vector2.left * velocity * Time.deltaTime);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
