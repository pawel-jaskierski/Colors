using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using CLR.UI;
using CLR.Score;
using CLR.TimeMenagmnet;
using CLR.Gameplay;
using CLR.Animation;

namespace CLR.Architectur{

    public class GameController : MonoBehaviour{
        #region STATES
        private BaseState currentState; 
        private StartState startState;
        private GameState gameState;
        private EndState endState;
        private AnimationState animationState;
        #endregion
        #region TRANSITIONS
        private UnityAction toGameState;
        private UnityAction toLoseState;
        private UnityAction toMenuState;
        private UnityAction toAnimationState;
        #endregion

        #region GAMEPLAY
        private ColorMenager colorMenager;
        private InputSystem inputSystem;
        #endregion
        #region VIEWS
        [SerializeField]MenuView menuView;
        [SerializeField]GameView gameView;
        [SerializeField]EndView endView;
        #endregion
        #region SOUNDS
        [SerializeField] private AudioSource click;
        #endregion
        [SerializeField]List<Color> colors;
        [SerializeField] TimeMenager timeMenager;
        private ScoreKeeper scoreKeeper;
        private ButtonAnimation buttonAnimation;
        private void Start(){
            toMenuState = () => ChangeState(startState);
            toGameState = () => ChangeState(gameState);
            toLoseState = () => ChangeState(endState);

            colorMenager = new ColorMenager(gameView,colors);
            inputSystem = new InputSystem(colorMenager);
            scoreKeeper = new ScoreKeeper();
            buttonAnimation = new ButtonAnimation(colorMenager,gameView);

            gameState = new GameState(gameView, colorMenager, inputSystem, toLoseState, timeMenager, scoreKeeper, buttonAnimation,click);
            startState =  new StartState(toGameState,menuView, scoreKeeper);
            endState = new EndState(endView, toGameState, toMenuState, scoreKeeper);
            ChangeState(startState);
        }
        private void Update(){
            currentState.Update();
        }
        
        private void ChangeState(BaseState state){
            currentState?.Destroy();
            currentState = state;
            currentState.Init();
        }
    }
}
