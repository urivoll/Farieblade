using Core.InGame.DTO;
using Events;
using Spine.Unity;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Core.InGame.View
{
    public class CirclesView : EventBehaviour
    {
        [SerializeField] private CircleAnimation[] _leftCircles;
        [SerializeField] private CircleAnimation[] _rightCircles;
        [SerializeField] private GameObject[] _plank;

        public void Open()
        {
            HandlerSetViewEvent(0);
        }

        public CirclePosition GetCirclePosition(int position, TurnSide turnSide)
        {
            CirclePosition circlePosition = new();
            CircleAnimation circleAnimation = (turnSide == TurnSide.left) ? _leftCircles[position] : _rightCircles[position];
            circlePosition.Position = circleAnimation.transform.position;
            circlePosition.SortingOrder = circleAnimation.GetComponent<SkeletonPartsRenderer>().MeshRenderer.sortingOrder;
            circlePosition.Size = circleAnimation.transform.localScale;
            return circlePosition;
        }
        
        public void HightlightCircles(List<int> listIndex, HeroDTO turnUnit, TurnSide enemySide, TurnSide mySide)
        {
            CircleAnimationEnum turnHeroColor = CircleAnimationEnum.enemyTurn;
            if (mySide != enemySide)
            {
                CircleAnimation[] circleAnimations;
                circleAnimations = (enemySide == TurnSide.left) ? _leftCircles : _rightCircles;
                for (int i = 0; i < listIndex.Count; i++)
                {
                    circleAnimations[listIndex[i]].SetCaracterState(CircleAnimationEnum.enemy);
                }
                turnHeroColor = CircleAnimationEnum.our;
            }
            if(turnUnit.TurnSide == TurnSide.left) _leftCircles[turnUnit.Position].SetCaracterState(turnHeroColor);
            else _rightCircles[turnUnit.Position].SetCaracterState(turnHeroColor);
        }

        public void HandlerRefreshEvent()
        {
            for (int i = 0; i < _leftCircles.Length; i++)
            {
                _leftCircles[i].SetCaracterState(CircleAnimationEnum.idle);
                _rightCircles[i].SetCaracterState(CircleAnimationEnum.idle);
            }
        }

        public void HandlerSetViewEvent(int index)
        {
            if (index == 0)
            {
                _plank[0].SetActive(false);
                _plank[1].SetActive(true);
                _leftCircles[1].transform.position = new Vector2(-4.5f, 1.53f);
                _leftCircles[0].transform.position = new Vector2(-1.5f, 1.53f);
                _rightCircles[0].transform.position = new Vector2(1.5f, 1.53f);
                _rightCircles[1].transform.position = new Vector2(4.5f, 1.53f);

                _leftCircles[3].transform.position = new Vector2(-6, -1.16f);
                _leftCircles[2].transform.position = new Vector2(-2, -1.16f);
                _rightCircles[2].transform.position = new Vector2(2, -1.16f);
                _rightCircles[3].transform.position = new Vector2(6, -1.16f);

                _leftCircles[5].transform.position = new Vector2(-7.5f, -4.61f);
                _leftCircles[4].transform.position = new Vector2(-2.5f, -4.61f);
                _rightCircles[4].transform.position = new Vector2(2.5f, -4.61f);
                _rightCircles[5].transform.position = new Vector2(7.5f, -4.61f);
            }
            else if (index == 1)
            {
                _plank[0].SetActive(true);
                _plank[1].SetActive(false);
                _leftCircles[1].transform.position = new Vector2(-3.87f, 1.53f);
                _leftCircles[0].transform.position = new Vector2(0.29f, 1.53f);
                _rightCircles[0].transform.position = new Vector2(4.44f, 1.53f);
                _rightCircles[1].transform.position = new Vector2(8.63f, 1.53f);

                _leftCircles[3].transform.position = new Vector2(-6.56f, -1.16f);
                _leftCircles[2].transform.position = new Vector2(-2.04f, -1.16f);
                _rightCircles[2].transform.position = new Vector2(2.51f, -1.16f);
                _rightCircles[3].transform.position = new Vector2(6.95f, -1.16f);

                _leftCircles[5].transform.position = new Vector2(-8.93f, -4.61f);
                _leftCircles[4].transform.position = new Vector2(-4.35f, -4.61f);
                _rightCircles[4].transform.position = new Vector2(0.33f, -4.61f);
                _rightCircles[5].transform.position = new Vector2(4.82f, -4.61f);
            }
        }
    }
}