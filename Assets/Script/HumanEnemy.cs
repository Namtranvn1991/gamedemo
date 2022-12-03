using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanEnemy : Enemy
{
    private Animator enemyAnimator;
    [SerializeField]
    private LayerMask blocks;

    private FSM_State currentState = null;
    private FSM_State state_idle = new FSM_State();
    private FSM_State state_walk = new FSM_State();

    void Start()
    {
        _movement = GetComponent<EnemyMovement>();
        enemyAnimator = GetComponent<Animator>();
        state_walk.Enter = WalkEnter;
        state_walk.Update = WalkUpdate;
        state_walk.HandleInput = WalkInput;
        currentState = state_walk;
        currentState.Enter();
    }

    void Update()
    {
        currentState.Update(Time.deltaTime);
        FSM_State fSM_State = currentState.HandleInput(); 
        if (fSM_State != null)
        {
            currentState = fSM_State;
            currentState.Enter();
        }
    }

    private void IdleEnter()
    {
        _movement.Stop();
    }

    private void WalkEnter()
    {
        _movement.Move(2);
        enemyAnimator.SetFloat("Speed_f", 1.0f);
    }

    private void WalkUpdate(float delta)
    {
        
    }

    private FSM_State WalkInput()
    {
        if (Check(blocks, _movement.direction))
        {
            if (!ChangeDirectionCollision())
            {
                return state_idle;
            }
        }
        return null;
    }

    public bool ChangeDirectionCollision()
    {
        List<Direction> list = new List<Direction>();
        if (Overlap(blocks, _movement.direction.Flip()).Length == 0)
        {
            list.Add(_movement.direction.Flip());
        }
        if (Overlap(blocks, _movement.direction.RotateLeft()).Length == 0)
        {
            list.Add(_movement.direction.RotateLeft());
        }
        if (Overlap(blocks, _movement.direction.RotateRight()).Length == 0)
        {
            list.Add(_movement.direction.RotateRight());
        }
        if (list.Count > 0)
        {
            int index = Random.Range(0, list.Count);
            _movement.TurnTo(list[index]);
            return true;
        }
        return false;
    }

}
