using UnityEngine;

public class Layer_n04 : MonoBehaviour
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
        velocity = 1f * _gameController.velocity;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size.x;
        Debug.Log("tamanho layer 4:" + spriteSize);

    }

    // Update is called once per frame
    void Update() {
        moverLayer();
        velocity = 1f * _gameController.velocity;
        if (transform.position.x <= -50) {
            Debug.Log("layer 4 saiu da camera");
            GameObject layerTemporaria4 = Instantiate(_parallaxControler.bg_layer_n04);
            layerTemporaria4.transform.position = new Vector3(transform.position.x + (2 * spriteSize), transform.position.y, transform.position.z);
            Destroy(gameObject);
        }

    }
    private void FixedUpdate() {

    }

    private void moverLayer() {
        transform.Translate(Vector2.left * velocity * Time.deltaTime);
    }

}
