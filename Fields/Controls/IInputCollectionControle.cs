using App.WinForm.Entities;
using System.Collections.Generic;

namespace App.WinForm
{
    public interface IInputCollectionControle
    {
       List<BaseEntity> Value { get; }
    }
}