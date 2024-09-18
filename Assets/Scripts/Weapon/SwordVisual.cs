using UnityEngine;

public class SwordVisual : MonoBehaviour {
    [SerializeField] private Sword Sword;

    private Animator Animator;
    private const string ATTACK = "Attack";

    private void Awake() {
        Animator = GetComponent<Animator>();
    }
    private void Start() {
        Sword.OnSwordSwing += Sword_OnSwordSwing;
    }

    private void Sword_OnSwordSwing(object sender, System.EventArgs e) {
        Animator.SetTrigger(ATTACK);
    }
}
