using Game.Utils;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private State startState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamingPosition;
    private Vector3 startPosition;


    private enum State {
        //Idle,
        Roaming
    }
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startState;
    }

    private void Update() {
        switch (state) {
            default:

            //case State.Idle:

            //    break;
            case State.Roaming:

                roamingTime -= Time.deltaTime;
                if (roamingTime < 0) {
                    Roaming();
                    roamingTime = roamingTimerMax;
                }
                break;
        }

    }
    private void Roaming() {

        startPosition = transform.position;
        roamingPosition = GetRoamingPosition();
        PlayerFaceDirect(startPosition, roamingPosition);
        navMeshAgent.SetDestination(roamingPosition);

    }

    private Vector3 GetRoamingPosition() {
        return startPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }

    private void PlayerFaceDirect(Vector3 sourcePosition, Vector3 targetPosition) {


        if (sourcePosition.x > targetPosition.x) {

            transform.rotation = Quaternion.Euler(0, -180, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

