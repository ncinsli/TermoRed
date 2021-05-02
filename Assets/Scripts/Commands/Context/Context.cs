using UnityEngine;

namespace Commands
{
    public class Context : MonoBehaviour, IJumpContext, IMovementContext
    {
        [SerializeField] private MoveModule _movement = default;
        public MoveModule Movement => _movement;
        
        [SerializeField] private JumpModule _jump = default;
        public JumpModule Jump => _jump;
    }
}