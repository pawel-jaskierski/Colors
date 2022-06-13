using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CLR.Architectur{
    public interface BaseState{
        public void Init();
        public void Update();
        public void Destroy();
    }
}