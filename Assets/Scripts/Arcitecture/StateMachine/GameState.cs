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

    public class GameState : BaseState
    {
        private GameView gameView;
        private ColorMenager colorMenager;
        private InputSystem inputSystem;
        private UnityAction onWrongGuess;
        private UnityAction onRightGuess;
        private TimeMenager timeMenager;
        private ScoreKeeper scoreKeeper;
        private UnityAction toLoseState;
        private ButtonAnimation buttonAnimation;
        private AudioSource click;

        public GameState(GameView gameView, ColorMenager colorMenager, InputSystem inputSystem, UnityAction toEndState, TimeMenager timeMenager, ScoreKeeper scoreKeeper, ButtonAnimation buttonAnimation, AudioSource click){
            this.gameView = gameView;
            this.colorMenager = colorMenager;
            this.inputSystem = inputSystem;
            this.timeMenager = timeMenager;
            this.scoreKeeper =  scoreKeeper;
            this.buttonAnimation = buttonAnimation;
            this.click = click;
            onWrongGuess += toEndState;
            onRightGuess += timeMenager.OnButonHit;
            onRightGuess += scoreKeeper.IncreaseScore;
            onRightGuess += UpdateScoreUI;
            onRightGuess += () => buttonAnimation.DecreaseSize(() => inputSystem.SetActive(true));
        }

       

        public void Destroy(){
            inputSystem.RemoveListiners();
            gameView.HideView();
            timeMenager.OnButonHit();
            gameView.ChangeScore(0);
            scoreKeeper.SetHighScore();
        }

        public void Init(){
            scoreKeeper.Init();
            inputSystem.Init(onRightGuess,onWrongGuess);
            gameView.ShowView();
            gameView.AddListiners(inputSystem.OnButonHit);
            gameView.AddListiners(click.Play);
            colorMenager.OnCorrectGuess();
            timeMenager.SetOnLose(onWrongGuess);
            timeMenager.Init();
        }

        public void Update(){
            timeMenager.UpdateTimeIndicator();
        }

        private void UpdateScoreUI(){
            gameView.ChangeScore(scoreKeeper.Score());
        }
    }
}