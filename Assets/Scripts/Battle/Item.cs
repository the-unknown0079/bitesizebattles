using System;
using System.ComponentModel;

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
//armor
public class NormieArmor : Item {//no special effect
	
	public NormieArmor() {
		Name = "Normie Armor";
		Description = "Doesn't do anything special. Your dad might wear this armor in a desperate attempt to seem up to date with what 'the kids are doing.'";
		Type = ItemType.Armor;
		modifiers.Add(new StatModifier(Stats.Defense, 5));
	}
}
public class NinjaOutfit : Item
{
		Name = "Ninja Outfit";
		Description = "Sneaky sneaky sneaky with this outfit. Adds 'dodge' to your stats.";
		Type = ItemType.Armor;
		modifiers.Add(Stats.Defense, 25);
}
public class TurtleArmor : Item
{
		Name = "Turtle Armor"
		Description = "Provides heavy protection against heavy projectiles."
		Type = ItemType.Armor;
		modifiers.Add(Stats, 20)
}
public class TShirt : Item
{
		Name = "T-Shirt";
		Description = "Basic plain white t-shirt. Protects against the elements. Nothing more.";
		Type = ItemType.Armor;
		modifiers.Add(Stats.Defense, 1);
}
//weapons 
public class NormieSword : Item
{
		Name = "Normie Sword"
		Description = "Just your basic blacksmith sword, no smoke and mirrors";
		Type = ItemType.Weapon;
		modifiers.Add(Stats.Attack, 15);
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
public class PlasticSword : Item
{
		Name = "Potion Of Getting Schwifty";
		Description = "A basic supermarket off the shelf toy sword.";
		Type = ItemType.Weapon;
		modifiers.Add(Stats.Attack, 0);
}
//potions
public class PotionPayback : Item
{
		Name = "Potion of PayBack";
		Description = "Provides damage taken as attack power";
		Type = ItemType.Potion;
		modfiers.Add()
}
public class PotionCocaine : Item
{
		Name = "Potion Of Just Straight Up Cocaine";
		Description = "Attack your opponent twice!"
		Type = ItemType.Potion;
		modifiers.Add();
}
public class PotionLacroix :Item
{
		Name = "Potion of Flat Lacroix"
		Description = "take and deal 1.5x normal amount of damage"
		Type = ItemType.Potion;
		modifiers.Add(new StatModifier(Stats.Attack, 1);
	public StatModifier[] applyModifiersOnAttack(Entity entity, int damage)
	{
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

