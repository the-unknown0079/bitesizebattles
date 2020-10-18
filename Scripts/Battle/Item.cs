enum ItemType
{
	Weapon,
	Armor,
	Potion
}

public abstract class Item{
	private string Name {get;}
	private string Description {get;}
	private ItemType Type {get;}
	private List<StatModifier> modifiers {get;}


	public virtual List<StatModifier> applyModifiersOnAttack(Entity entity, int damage) {//this is used for weapons and items that affect attack damage mostly
		return modifiers;	
	}
	public virtual List<StatModifier> applyModifiersOnDamage(EntityPlayer player, int damage) {//used when the player takes damage from an attack, use only for special effects e.g. effects that trigger based on the amount of damage taken
		return null;
	}
	public virtual List<StatModifier> applyModifiersPassive(EntityPlayer player) {//used for stat modifiers that are just always on, use this for normal calculuation of armor defense modifiers and stuff
		return modifiers;
	}
}

public class NormieArmor : Item {//no special effect
	
	public NormieArmor() {
		Name = "Normie Armor";
		Description = "Doesn't do anything special. Your dad might wear this armor in a desperate attempt to seem up to date with what 'the kids are doing.'";
		Type = ItemType.Armor;
		modifiers.Add(new StatModifier(Stats.Defense, 5));
	}
}

public class SneakyBastardSword : Item {//applies an attack modifier equal to the defense of the opposing monster, essentially bypassing all defense
	
	public SneakyBastardSword() {
		Name = "Sneaky Bastard Sword";
		Description = "Makes you a sneaky bastard. As a sneaky bastard, you are able to ignore the enemy's defense entirely, gaining an attack boost equal to the enemy's defense.";
		Type = ItemType.Armor;
		modifiers.Add(new StatModifier(Stats.Attack, 10));
	}
	
	public StatModifier[] applyModifiersOnAttack(Entity entity, int damage) {
		StatModifier[] modifiersToApply = modifiers;
		modifiersToApply.Add(new StatModifier(Stats.Attack, entity.GetStatTable[Stats.Defense]));
		return modifiersToApply;
	}
}

public class PotionOfGettingSchwifty : Item {//just makes the player go first instead of enemy

	public PotionOfGettingSchwifty() {
		Name = "Potion Of Getting Schwifty";
		Description = "Lets you go before enemies, and also gets you about 25 Reddit karma";
		Type = ItemType.Potion;
	}
}
