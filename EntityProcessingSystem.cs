using System;
namespace Artemis
{
	public abstract class EntityProcessingSystem : EntitySystem {
		
		/**
		 * Create a new EntityProcessingSystem. It requires at least one component.
		 * @param requiredType the required component type.
		 * @param otherTypes other component types.
		 */
		public EntityProcessingSystem(Component requiredType,params Component[] otherTypes) : base(GetMergedTypes(requiredType, otherTypes)) {
		}
		
		/**
		 * Process a entity this system is interested in.
		 * @param e the entity to process.
		 */
		public abstract void Process(Entity e);
	
		public override void ProcessEntities(Bag<Entity> entities) {
			for (int i = 0, s = entities.Size(); s > i; i++) {
				Process(entities.Get(i));
			}
		}
		
		public override bool CheckProcessing() {
			return true;
		}
		
	}
}

