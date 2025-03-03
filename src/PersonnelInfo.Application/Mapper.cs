namespace PersonnelInfo.Application;
public static class Mapper
{
    public static TDto MapToDto<T, TDto>(T entity, TDto dto)
    where T : class
    where TDto : class
    {
        var dtoProperties = typeof(TDto).GetProperties();
        var entityProperties = typeof(T).GetProperties();

        foreach (var property in entityProperties)
        {
            var dtoProperty = dtoProperties.FirstOrDefault(p => p.Name == property.Name);
            if (dtoProperty != null && dtoProperty.CanWrite)
            {
                var value = property.GetValue(entity);
                dtoProperty.SetValue(dto, value);
            }
        }
        return dto;
    }

    //public static TDto MapToDto<T,TDto>(T entity) where TDto : class,new()
    //{
    //    var dto = new TDto();
    //    MapToDto(entity, dto);
    //    return dto;
    //}

    public static T MapToEntity<TDto, T>(TDto dto, T entity) where T : class
    {
        var dtoProperties = typeof(TDto).GetProperties();
        var entityProperties = typeof(T).GetProperties();

        foreach (var dtoProperty in dtoProperties)
        {
            var entityProperty = entityProperties.FirstOrDefault(p => p.Name == dtoProperty.Name && p.PropertyType == dtoProperty.PropertyType);
            if (entityProperty != null && entityProperty.CanWrite)
            {
                var value = dtoProperty.GetValue(dto); // Get value from DTO
                entityProperty.SetValue(entity, value); // Set value to Entity
            }
        }

        return entity;
    }

    public static T MapToEntity<TDto,T>(TDto dto) where T : class,new()
    {
        var entity = new T();
        MapToEntity(dto, entity);
        return entity;
    }
}
