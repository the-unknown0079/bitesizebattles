public struct BattleLayout {
	private Entity EnemyEntity {get;} //enemy for this battle

	//following code says what items are allowed for the player to use. 3 per type of item per battle for now
	private Item[] Potions {get;}
	private Item[] Armors {get;}
	private Item[] Weapons {get;}

	public BattleLayout(Entity enemyEntity, Item[] potions, Item[] armors, Item[] weapons){
		EnemyEntity = enemyEntity;
		Potions = potions;
		Armors = armors;
		Weapons = weapons;
	}
}
