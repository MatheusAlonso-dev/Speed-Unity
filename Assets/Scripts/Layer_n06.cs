using UnityEngine;

public class Layer_n06 : MonoBehaviour
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
        velocity = 0.7f * _gameController.velocity;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size.x;
        Debug.Log("tamanho layer 6:" + spriteSize);

    }

    // Update is called once per frame
    void Update() {
        moverLayer();
        velocity = 0.7f * _gameController.velocity;

    }
    private void FixedUpdate() {

    }

    private void moverLayer() {
        transform.Translate(Vector2.left * velocity * Time.deltaTime);
    }
    private void OnBecameInvisible() {
        GameObject layerTemporaria6 = Instantiate(_parallaxControler.bg_layer_n06);
        layerTemporaria6.transform.position = new Vector3(transform.position.x + (2 * spriteSize), transform.position.y, transform.position.z);
        Destroy(gameObject);
    }
}
