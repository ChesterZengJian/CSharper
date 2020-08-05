namespace Behavior.DesignPatterns
{
    public enum State
    {
        Small,
        Super,
        Cape,
        Fire
    }

    #region 分支逻辑法

    //public class MarioStateMachine
    //{
    //    public int Scope { get; set; }
    //    public State CurrentState { get; private set; }

    //    public MarioStateMachine()
    //    {
    //        Scope = 0;
    //        CurrentState = State.Small;
    //    }

    //    public void EatMushroom()
    //    {
    //        if (CurrentState != State.Small) return;
    //        Scope += 100;
    //        CurrentState = State.Super;
    //    }

    //    public void PickCape()
    //    {
    //        if (CurrentState != State.Small && CurrentState != State.Super) return;
    //        Scope += 200;
    //        CurrentState = State.Cape;
    //    }

    //    public void EatFire()
    //    {
    //        if (CurrentState != State.Small || CurrentState != State.Super) return;
    //        Scope += 300;
    //        CurrentState = State.Fire;
    //    }

    //    public void MeetMonster()
    //    {
    //        switch (CurrentState)
    //        {
    //            case State.Small:
    //                break;
    //            case State.Super:
    //                Scope -= 100;
    //                CurrentState = State.Small;
    //                break;
    //            case State.Cape:
    //                Scope -= 200;
    //                CurrentState = State.Small;
    //                break;
    //            case State.Fire:
    //                Scope -= 300;
    //                CurrentState = State.Small;
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException();
    //        }
    //    }
    //}

    #endregion

    #region 状态模式

    public interface IMario
    {
        void EatMushroom();
        void PickCape();
        void EatFire();
        void MeetMonster();
    }

    public class SmallMario : IMario
    {
        private readonly MarioStateMachine m_marioStateMachine;

        public SmallMario(MarioStateMachine marioStateMachine)
        {
            m_marioStateMachine = marioStateMachine;
        }

        public void EatMushroom()
        {
            m_marioStateMachine.Scope += 100;
            m_marioStateMachine.CurrentState = new SuperMario(m_marioStateMachine);
        }

        public void PickCape()
        {
            m_marioStateMachine.Scope += 200;
            m_marioStateMachine.CurrentState = new CapeMario(m_marioStateMachine);
        }

        public void EatFire()
        {
            m_marioStateMachine.Scope += 300;
            m_marioStateMachine.CurrentState = new FireMario(m_marioStateMachine);
        }

        public void MeetMonster()
        {

        }
    }
    public class SuperMario : IMario
    {
        private readonly MarioStateMachine m_marioStateMachine;

        public SuperMario(MarioStateMachine marioStateMachine)
        {
            m_marioStateMachine = marioStateMachine;
        }
        public void EatMushroom()
        {

        }

        public void PickCape()
        {
            m_marioStateMachine.Scope += 200;
            m_marioStateMachine.CurrentState = new CapeMario(m_marioStateMachine);
        }

        public void EatFire()
        {
            m_marioStateMachine.Scope += 300;
            m_marioStateMachine.CurrentState = new FireMario(m_marioStateMachine);
        }

        public void MeetMonster()
        {
            m_marioStateMachine.Scope -= 100;
            m_marioStateMachine.CurrentState = new SmallMario(m_marioStateMachine);
        }
    }
    public class CapeMario : IMario
    {
        private readonly MarioStateMachine m_marioStateMachine;

        public CapeMario(MarioStateMachine marioStateMachine)
        {
            m_marioStateMachine = marioStateMachine;
        }

        public void EatMushroom()
        {
        }

        public void PickCape()
        {
        }

        public void EatFire()
        {
            m_marioStateMachine.Scope += 300;
            m_marioStateMachine.CurrentState = new FireMario(m_marioStateMachine);
        }

        public void MeetMonster()
        {
            m_marioStateMachine.Scope -= 200;
            m_marioStateMachine.CurrentState = new SmallMario(m_marioStateMachine);
        }
    }
    public class FireMario : IMario
    {
        private readonly MarioStateMachine m_marioStateMachine;

        public FireMario(MarioStateMachine marioStateMachine)
        {
            m_marioStateMachine = marioStateMachine;
        }

        public void EatMushroom()
        {
        }

        public void PickCape()
        {
        }

        public void EatFire()
        {
        }

        public void MeetMonster()
        {
            m_marioStateMachine.Scope -= 300;
            m_marioStateMachine.CurrentState = new SmallMario(m_marioStateMachine);
        }
    }

    public class MarioStateMachine
    {
        public MarioStateMachine()
        {
            Scope = 0;
            CurrentState = new SmallMario(this);
        }

        public int Scope { get; set; }
        public IMario CurrentState { get; set; }
        public void EatMushroom()
        {
            CurrentState.EatMushroom();
        }

        public void PickCape()
        {
            CurrentState.PickCape();
        }

        public void EatFire()
        {
            CurrentState.EatFire();
        }

        public void MeetMonster()
        {
            CurrentState.MeetMonster();
        }
    }

    #endregion
}