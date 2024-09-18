using UnityEngine;

public class PlayerVisual : MonoBehaviour {

    private Animator animator;
    private SpriteRenderer spriteRender;

    private const string IS_RUN = "isRun";
    private void Awake() {

        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        animator.SetBool(IS_RUN, Player.Instance.isRunning());
        PlayerFaceDirect();
    }

    private void PlayerFaceDirect() {

        Vector3 mPos = GameInput.Instance.GetMousePosition();
        Vector3 playerPos = Player.Instance.GetPlayerPosition();

        if (mPos.x < playerPos.x) {
            spriteRender.flipX = true;
        } else {
            spriteRender.flipX = false;
        }
    }
}
