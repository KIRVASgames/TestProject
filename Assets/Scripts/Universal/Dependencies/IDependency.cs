﻿namespace Dependencies
{
    public interface IDependency<T>
    {
        void Construct(T obj);
    }
}