The GameActor system uses the decorator pattern to create complex object with reusable components. The GameActorFeature components are divided by icon color in three types:
Yellow are GameActorFeature that doesn't need to be in a specific position inside the object, but have to be present in the GameActorFeature list in the GameActor.
Green are GameActorFeature that uses collision callbacks and they have to be in the same object as the collision components.
Cyan aren't GameActorFeature, so they don't need to be in the list, but they are used with the GameActor and uses their systems.
