using Spine.Unity;
using UnityEngine;

public class CircleAnimation : AbstractAnimation
{
    [SerializeField] private AnimationReferenceAsset _idle, _circleEnemy, _circleOur, _circleSpell, _circleEnemyTurn;

    public void SetCaracterState(CircleAnimationEnum state)
    {
        if (state == CircleAnimationEnum.idle) SetAnimation(_idle, true, 1f, "circle");
        else if (state == CircleAnimationEnum.enemy) SetAnimation(_circleEnemy, true, 1f, "circle");
        else if (state == CircleAnimationEnum.our) SetAnimation(_circleOur, true, 1f, "circle");
        else if (state == CircleAnimationEnum.spell) SetAnimation(_circleSpell, true, 1f, "circle");
        else if (state == CircleAnimationEnum.enemyTurn) SetAnimation(_circleEnemyTurn, true, 1f, "circle");
    }
}

public enum CircleAnimationEnum
{
    idle,
    enemy,
    our,
    spell,
    enemyTurn
}