﻿using System.Collections.Generic;

namespace Vavatech.Shop.IServices
{
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
