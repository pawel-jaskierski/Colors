using System.Collections;
using System.Collections.Generic;
using CLR.UI;
using CLR.Score;
using UnityEngine;
using UnityEngine.Events;

namespace CLR.Architectur{
    public class EndState : BaseState{
        private EndView endView;
        private UnityAction toGameState;
        private UnityAction toMenuState;

        private ScoreKeeper scoreKeeper;
        public EndState(EndView endView, UnityAction toGameState, UnityAction toMenuSate, ScoreKeeper scoreKeeper){
            this.endView = endView;
            this.toGameState = toGameState;
            this.toMenuState = toMenuSate;
            this.scoreKeeper = scoreKeeper;
        }

        public void Destroy(){
            endView.HideView();
            endView.RemoveListiners();
            scoreKeeper.Reset();
        }

        public void Init(){
            endView.AddListiners(toGameState, toMenuState);
            endView.ShowView();
            endView.SetScore(scoreKeeper.Score(), scoreKeeper.HighScore());
        }

        public void Update(){
        }
    }
}