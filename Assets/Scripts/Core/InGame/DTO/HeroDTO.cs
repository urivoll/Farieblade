using Core.InGame.Controller;

namespace Core.InGame.DTO
{
    public class HeroDTO
    {
        public SpellState AttackState;
        public int Position { get; set; }
        public TurnSide TurnSide { get; set; }
        public float HpBasic { get; set; }
        public float Hp { get; set; }
        public float HpPercentage { get; set; }
        public float DamageBasic { get; set; }
        public float Damage { get; set; }
        public int Times { get; set; }
        public float Mana { get; set; }
        public int Accuarcy { get; set; }
        public int Initiative { get; set; }
        public int DamageType { get; set; }
        public int Vulnerability { get; set; }
        public int ManaCon { get; set; }
        public HeroController HeroController { get; set; }

        public void Init(SOheroes soHeroes, HeroController heroController, TurnSide turnSide, int position)
        {
            HpBasic = soHeroes.Hp;
            Hp = soHeroes.Hp;
            HpPercentage = 100;
            DamageBasic = soHeroes.Damage;
            Damage = soHeroes.Damage;
            Times = soHeroes.Times;
            Mana = 0;
            Accuarcy = soHeroes.Accuarcy;
            Initiative = soHeroes.Initiative;
            DamageType = soHeroes.DamageType;
            Vulnerability = soHeroes.Vulnerability;
            ManaCon = soHeroes.ManaCon;
            HeroController = heroController;
            TurnSide = turnSide;
            Position = position;
            AttackState = soHeroes.AttackState;
        }
    }
}
