using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }

    private Rigidbody2D Rigidbody2D;

    private Vector2 Vector;


    [SerializeField] private float speed = 5.0f;
    private float minSpeed = 0.1f;
    private bool isRun = false;

    private void Awake() {
        Instance = this;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        GameInput.Instance.OnPlayerAttack += Instance_OnPlayerAttack;
    }

    private void Instance_OnPlayerAttack(object sender, System.EventArgs e) {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();
    }

    private void FixedUpdate() {
        Move();
    }

    private void Update() {
        Vector = GameInput.Instance.GetVector();
    }

    private void Move() {

        Rigidbody2D.MovePosition(Rigidbody2D.position + Vector * (Time.fixedDeltaTime * speed));

        if (Mathf.Abs(Vector.x) > minSpeed || Mathf.Abs(Vector.y) > minSpeed) {
            isRun = true;
        } else {
            isRun = false;
        }
    }
    public bool isRunning() {
        return isRun;
    }
    public Vector3 GetPlayerPosition() {
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        return playerPos;
    }
}

