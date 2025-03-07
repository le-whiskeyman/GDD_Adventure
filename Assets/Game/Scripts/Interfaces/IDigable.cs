using UnityEngine;

namespace Game
{
    public interface IDigable
    {
        public void OnStartDigging();
        public void OnEndDigging();
    }
}