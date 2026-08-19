using UnityEngine;

public class Layer_n06 : MonoBehaviour
{
    private ParalaxController _parallaxControler;
    private float velocity;
    private SpriteRenderer spriteRenderer;
    private float spriteSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _parallaxControler = FindAnyObjectByType<ParalaxController>();
        velocity = 0.5f * _parallaxControler._overrallSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size.x;

    }

    // Update is called once per frame
    void Update() {
        moverLayer();

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
