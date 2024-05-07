using UnityEngine;

public class PetPlayerAttackMovement : PetPlayerMovement
{
    // TODO: implement change target when player hit an enemy
    // target and targetEntity is same as in PetPlayerAttackMovement
    public GameObject target;
    public Entity targetEntity;

    protected void Awake()
    {
        base.Awake();
    }
    
    protected void Update()
    {
        if (target is null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy");
            targetEntity = target is not null ? target.GetComponent<Entity>() : null;
        }
        if ((!ownerEntity.IsDead
             && Vector3.Distance(owner.transform.position, transform.position) > _distanceToOwner)
                ||
                target is null
            )
        {
            state = PetMovementState.Follow;
            target = null;

            var _random = Random.Range(0, 2);
            var destination = owner.transform.position + new Vector3(_random % 2 == 0 ? 1 : -1, 0, _random % 2 == 1 ? 1 : -1);

            _lastUpdate += Time.deltaTime;
            
            _lastUpdate = 0f;

            nav.SetDestination(destination);
        }
        else if (target is not null)
        {
            if (targetEntity.IsDead)
            {
                target = null;
                targetEntity = null;
            }
            else
            {
                targetEntity = target.GetComponent<Entity>();
                state = PetMovementState.Follow;
                var destination = target.transform.position;

                _lastUpdate += Time.deltaTime;
                
                _lastUpdate = 0f;

                nav.SetDestination(destination);
            }
        }
        else
        {
            target = null;
            state = PetMovementState.Idle;
            transform.rotation = owner.transform.rotation;
        }
        
        Animating();
    }

}