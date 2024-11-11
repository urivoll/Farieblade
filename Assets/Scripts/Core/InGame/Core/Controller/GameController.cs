using Core.InGame.UI.Controller;
using Core.InGame.Utils;
using UnityEngine;
using Zenject;

namespace Core.InGame.Controller
{
    public class GameController : MonoBehaviour
    {
        //Core
        [Inject] private TurnController _turnController;
        [Inject] private BGController _bgController;
        [Inject] private CirclesController _circlesController;
        [Inject] private UnitCoordinatorController _unitCoordinatorController;
        [Inject] private PlayerController _playerController;
        [Inject] private AiController _aiController;

        //UI
        [Inject] private SettingsController _settingsController;
        [Inject] private BotSideController _botSideController;

        //Utils
        [Inject] private MeleeAttack _meleeAttack;
        [Inject] private ShooterAttack _shooterAttack;



        public void Start()
        {
            //Core
            _bgController.Open();
            _circlesController.Open();
            _playerController.Open();
            _aiController.Open(TurnSide.right);
            _aiController.AiOn(false);

            //Utils
            _meleeAttack.Open();
            _shooterAttack.Open();

            //UI
            _settingsController.Open(false, 0);
            _botSideController.Open("ArNix");

            //Start the game!
            _turnController.StartStep();
        }

        public void Close()
        {
            _turnController.Close();
        }
    }
}
