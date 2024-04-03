﻿namespace SchoolManagement.EntityFramework.Contracts
{
    public interface IUserRepository<T> 
    {
        T? GetById(int id);
        bool Update(T entity);
        bool Delete(int id);
    }
}