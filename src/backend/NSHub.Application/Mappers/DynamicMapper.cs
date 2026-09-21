// <copyright file="DynamicMapper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Mappers;

public static class DynamicMapper
{
    public static void MapDynamic<TSource, TDest>(TSource source, TDest dest)
    {
        var props = typeof(TSource).GetProperties();

        foreach (var prop in props)
        {
            var target = typeof(TDest).GetProperty(prop.Name);
            if (target != null && target.CanWrite)
            {
                target.SetValue(dest, prop.GetValue(source));
            }
        }
    }
}
