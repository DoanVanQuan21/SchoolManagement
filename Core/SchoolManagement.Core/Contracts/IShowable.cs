﻿namespace SchoolManagement.Core.Contracts
{
    public interface IShowable
    {
        void ShowDialog(Type type);

        void Show(Type type);
    }
}