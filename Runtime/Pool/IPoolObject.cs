namespace Arj2D
{
    public interface IPoolObject
    {
        public PoolObject poolContainer { set; }

        // Called when is spawned, you can activate here the gameObject
        public void Spawned();

        // Just call poolContainer.ReturnGameObjectToPool(gameObject);
        public void Despawn();
    }
}


