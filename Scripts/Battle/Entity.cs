public enum Stats {
	HP,
	Attack,
	Defense,
}

public struct StatModifier {
	Stats Stat {get;}
	int Modifier {get;}

	public StatModifier (Stats stat, int modifier) {
		Stat = stat;
		Modifier = modifier;
	}
}

public abstract class Entity {
	private string Name {get;}
	int Dictionary<Stats, int> StatTable = new Dictionary<Stats, int>() {get;}
	StatModifier[] Modifiers = new StatModifier[];
	boolean IsDead = false {get;}	

	public int getModifierTotalForStat(Stats stat) {//get all modifiers to a stat for things like damage calculations
		int total = 0;
		
		for (StatModifier statModifier in Modifiers) {
			if (statModifier.GetStat() == stat) {
				total += statModifier.getModifier();	
			}
		} 

		return total;
	}
	
	public virtual void damageEntity(int damage){
		int defenseWithModifiers = StatTable[Stats.Defense] + getModifierTotalForStat(Stats.Defense);
		if (damage > defenseWithModifiers){
			StatTable[HP] -= (damage - StatTable[Defense]);
		}
		else {
			StatTable[HP] -= 0;
		}

		if (StatTable[HP] <= 0){
			StatTable[HP] = 0;
			IsDead = true;
		}
	}

	public virtual attackOtherEntity(Entity entity) {
		int attackWithModifiers = StatTable[Stats.Attack] + getModifierTotalForStat(Stats.Attack);
		entity.damageEntity(attackWithModifiers);
	}

}

public class PlayerEntity : Entity {
	
	Item Potion {get; set;}
	Item Armor {get; set;}
	Item Weapon {get; set;}
	private boolean goesFirst = false; //in every battle the enemy will go first unless the player has a Potion of Getting Schwifty

	public PlayerEntity() {
		Name = "Player";
		StatTable.Add(HP, 10);
		StatTable.Add(Attack, 0);
		StatTable.Add(Defense, 0);
	}
}

public class GenericSlimeEnemyEntity : Entity {
	
	public GenericSlimeEnemyEntity() {
		Name = "Generic Slime Enemy";
		StatTable.Add(HP, 20);
		StatTable.Add(Attack, 10);
		StatTable.Add(Defense, 0);
	}
}

public class WeebBaitEntity : Entity {
	public WeebBaitEntity() {
		Name = "Weeb Bait";
		StatTable.Add(HP, 25);
		StatTable.Add(Attack, 20);
		StatTable.Add(Defense, 5);
	}
}

public class TheTankEntity : Entity {
	
	public TheTankEntity() {
		Name = "The Tank";
		StatTable.Add(HP, 25);
		StatTable.Add(Attack, 30);
		StatTable.Add(Defense, 420); 
	}

	public damageEntity(int damage) {
		StatTable[HP] -= 1; //The Tank takes 1 damage from every attack
		
		if (StatTable[HP] <= 0){
			StatTable[HP] = 0;
			isDead = true;
		}
	}
}
