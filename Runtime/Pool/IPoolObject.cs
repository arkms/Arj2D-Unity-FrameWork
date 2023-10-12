namespace Arj2D
{
    public interface IPoolObject
    {
        public PoolObject poolContainer { set; }

        // Just call poolContainer.ReturnGameObjectToPool(gameObject);
        public void Despawn();
    }
}


