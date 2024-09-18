using UnityEngine;

public class ActiveWeapon : MonoBehaviour {

    public static ActiveWeapon Instance { get; private set; }
    [SerializeField] private Sword Sword;

    private void Awake() {
        Instance = this;
    }

    public Sword GetActiveWeapon() {

        return Sword;
    }
}
