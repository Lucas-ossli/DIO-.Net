namespace src.Entities
{
    public class Hero
    {
        public string Name { get; set; }
        public int Level{get;set;}
        public string HeroType{get;set;}

        public Hero(string name, int level)
        {
            this.Name = name;
            this.Level = level;

            if(level > 29)
            {
                HeroType = "Mago";
            }
            else
            {
                HeroType="Guerreiro";
            }
        }

        public Hero()
        {

        }

        public override string ToString()
        {
            return this.Name + " " + this.Level.ToString() + " " + this.HeroType;
        }

        public virtual string Attack(){
            if(Level >= 29)
            {
                return this.Name + "Atacou com o seu cajado";
            }
            return this.Name + "Atacou com a sua espada";
        }
    }
}