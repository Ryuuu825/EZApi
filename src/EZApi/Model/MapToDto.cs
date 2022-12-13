
namespace EZApi.Model
{
    public static class MapToDto 
    {
        public static System.Collections.Hashtable ToODto(this object entity) 
        {
            System.Collections.Hashtable map = new System.Collections.Hashtable();

            foreach (var item in entity.GetType().GetProperties())
            {
                if (
                    IsFeildMappable(item) ||
                    Attribute.IsDefined(item, typeof(EZApi.Attributes.NotMapToODtoAttribute))
                )
                    continue;
                map.Add(item.Name, item.GetValue(entity));
            }
            return map;
        }


        
        public static ICollection<System.Collections.Hashtable> ToODto(this IEnumerable<object?> entity) 
        {

            ICollection<System.Collections.Hashtable> map = new List<System.Collections.Hashtable>();

            foreach (var item in entity)
            {
                if (item == null)
                    continue;
                map.Add(item.ToODto());
            }
            return map;
        }


        public static TODto ToODto<TODto>(this object entity) 
            where TODto : class
        {
            TODto map = System.Activator.CreateInstance<TODto>();

            foreach (var item in entity.GetType().GetProperties())
            {
                if (
                    Attribute.IsDefined(item, typeof(EZApi.Attributes.NotMapToODtoAttribute)) ||
                    // entity's property is not in TODto
                    typeof(TODto).GetProperty(item.Name) == null
                )
                    continue;
                
                typeof(TODto).GetProperty(item.Name)?.SetValue(map, item.GetValue(entity));
            }
            return map;
        }


        public static ICollection<TODto> ToODto<TODto>(this IEnumerable<object?> entity) 
            where TODto : class
        {

            ICollection<TODto> map = new List<TODto>();

            foreach (var item in entity)
            {
                if (item == null)
                    continue;
                map.Add(item.ToODto<TODto>());
            }
            return map;
        }

        

        public static System.Collections.Hashtable ToIDto(this object entity) 
        {
            System.Collections.Hashtable map = new System.Collections.Hashtable();

            foreach (var item in entity.GetType().GetProperties())
            {
                if (
                    IsFeildMappable(item) ||
                    Attribute.IsDefined(item, typeof(EZApi.Attributes.NotMapToIDtoAttribute))
                )
                    continue;
                map.Add(item.Name, item.GetValue(entity));
            }
            return map;
        }

        public static ICollection<System.Collections.Hashtable> ToIDto(this IEnumerable<object?> entity) 
        {

            ICollection<System.Collections.Hashtable> map = new List<System.Collections.Hashtable>();

            foreach (var item in entity)
            {
                if (item == null)
                    continue;
                map.Add(item.ToIDto());
            }
            return map;
        }

        public static TIDto ToIDto<TIDto>(this object entity) 
            where TIDto : class
        {

            TIDto map = System.Activator.CreateInstance<TIDto>();

            foreach (var item in entity.GetType().GetProperties())
            {
                if (
                    Attribute.IsDefined(item, typeof(EZApi.Attributes.NotMapToIDtoAttribute)) ||
                    // entity's property is not in TIDto
                    typeof(TIDto).GetProperty(item.Name) == null
                )
                    continue;
                
                typeof(TIDto).GetProperty(item.Name)?.SetValue(map, item.GetValue(entity));
            }
            return map;
        }

        public static ICollection<TIDto> ToIDto<TIDto>(this IEnumerable<object?> entity) 
            where TIDto : class
        {

            ICollection<TIDto> map = new List<TIDto>();

            foreach (var item in entity)
            {
                if (item == null)
                    continue;
                map.Add(item.ToIDto<TIDto>());
            }
            return map;
        }



        private static bool IsFeildMappable(System.Reflection.PropertyInfo item)
        {
            // 
            return  item.PropertyType.IsInterface || 
                    item.PropertyType.IsAbstract || 
                    Attribute.IsDefined(item, typeof(EZApi.Attributes.NotMapToDtoAttribute)) ||
                    item.GetMethod.IsVirtual ;

        }


    }
}