using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CLR.UI;
using CLR.Score;
namespace CLR.Architectur{

    public class StartState : BaseState
    {
        private UnityAction toGameState;
        private MenuView menuView;

        public StartState(UnityAction toGameState, MenuView menuView, ScoreKeeper scoreKeeper){
            this.toGameState = toGameState;
            this.menuView = menuView;
        }
        public void Destroy(){
            menuView.HideView();
        }

        public void Init(){
            menuView.AddOnStartButton(toGameState);
            menuView.ShowView();
        }

        public void Update(){
        }
    }
}
