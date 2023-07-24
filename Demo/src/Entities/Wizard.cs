namespace src.Entities
{
    public class Wizard : Hero
    {

        public override string Attack()
        {
            return this.Name + "Atacou com o seu cajado";
        }
    }
}