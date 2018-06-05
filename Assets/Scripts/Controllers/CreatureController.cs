using UnityEngine;
using System.Collections;

public class CreatureController : MonoBehaviour {
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _runSpeed = 3f;

    private bool _isFacingLeft = true;
    private CreatureState _state = CreatureState.IDLE;
    private Vector2 _targettedPosition;
    private Vector2 _dir;
    private Vector3 _moveDir;

    private void Start() {
        StartCoroutine(UpdateStateCoroutine());
    }

    private void Update() {
        UpdateState();
        UpdateAnimator();

        // debug code
        if (Input.GetKeyDown(KeyCode.Space)) {
            _animator.Play("Hit");
        }
    }

    private void UpdateAnimator() {
        _isFacingLeft = _dir.x <= 0;
        _spriteRenderer.flipX = _isFacingLeft;
    }

    private void UpdateState() {
        if (_state == CreatureState.IDLE) {

        }
        else if (_state == CreatureState.WALK) {
            MoveTowardTargettedPosition();
        }
        else if (_state == CreatureState.RUN) {
            MoveTowardTargettedPosition();
        }
    }

    private void MoveTowardTargettedPosition() {
        if (IsNearTargettedPosition()) {
            SetState(CreatureState.IDLE);
            return;
        }

        _dir = (_targettedPosition - (Vector2)transform.position).normalized;
        _moveDir = _dir * GetSpeed() * Time.deltaTime;
        transform.position += _moveDir;
    }

    private float GetSpeed() {
        return _state == CreatureState.RUN ? _runSpeed : _walkSpeed;
    }

    private bool IsNearTargettedPosition() {
        return Vector2.Distance(transform.position, _targettedPosition) < 0.2f;
    }

    private IEnumerator UpdateStateCoroutine() {
        while (true) {
            float waitTime = Random.Range(0.5f, 3f);
            yield return new WaitForSeconds(waitTime);
            GoToRandomPosition();
        }
    }

    private void GoToRandomPosition() {
        // Random Walk or Run
        SetState((CreatureState)Random.Range(1, 3));
        _targettedPosition = Random.insideUnitCircle * 4f;
    }

    private void SetState(CreatureState state) {
        _state = state;
        _animator.SetInteger("State", (int)_state);
    }

    private enum CreatureState {
        IDLE,
        WALK,
        RUN
    }
}
