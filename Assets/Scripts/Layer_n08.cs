using UnityEngine;

public class Layer_n08 : MonoBehaviour
{
    private ParalaxController _parallaxControler;
    private GameController _gameController;
    private float velocity;
    private SpriteRenderer spriteRenderer;
    private float spriteSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _parallaxControler = FindAnyObjectByType<ParalaxController>();
        _gameController = FindAnyObjectByType<GameController>();
        velocity = 0.3f * _gameController.velocity;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size.x;

    }

    // Update is called once per frame
    void Update() {
        moverLayer();
        velocity = 0.3f * _gameController.velocity;
    }
    private void FixedUpdate() {

    }

    private void moverLayer() {
        transform.Translate(Vector2.left * velocity * Time.deltaTime);
    }
    private void OnBecameInvisible() {
        GameObject layerTemporaria5 = Instantiate(_parallaxControler.bg_layer_n08);
        layerTemporaria5.transform.position = new Vector3(transform.position.x + (2 * spriteSize), transform.position.y, transform.position.z);
        Destroy(gameObject);
    }
}
