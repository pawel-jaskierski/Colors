using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using CLR.UI;
namespace CLR.Gameplay{
    public class InputSystem{
        private UnityAction onCorrectGuess;
        private UnityAction onWrongGuess;
        private ColorMenager colorMenager;
        private bool isActive = true;
        public InputSystem(ColorMenager colorMenager){
            this.colorMenager = colorMenager;
        }

        public void OnButonHit(){
            if(isActive){
                isActive = false;
                GameObject clcikedButton = EventSystem.current.currentSelectedGameObject;
                Image buttonImage = clcikedButton.GetComponent<Image>();
                if(colorMenager.ColorCheck(buttonImage.color)) onCorrectGuess.Invoke();
                else onWrongGuess.Invoke();
            }
        }
        public void Init(UnityAction onCorrectGuess, UnityAction onWrongGuess){
            isActive = true;
            this.onCorrectGuess += onCorrectGuess;
            this.onWrongGuess += onWrongGuess;
        }
        public void RemoveListiners(){
            onCorrectGuess = null;
            onWrongGuess = null;
        }
        public void SetActive(bool active){
            isActive = active;
        }
        
    }
}