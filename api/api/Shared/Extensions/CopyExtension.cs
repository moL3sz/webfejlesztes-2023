namespace api.Shared.Extensions {
    public static class CopyExtension {

        public static object Copy(this object source, Type targetType) { 
            var sourceType = source.GetType();
            var target = Activator.CreateInstance(targetType);
            foreach(var prop in sourceType.GetProperties()) {

                var targetProp = targetType.GetProperty(prop.Name);
                if (targetType.GetProperty(prop.Name) == null) {
                    continue;
                }
                if (targetProp?.SetMethod == null) {
                    continue;
                }
                targetProp.SetValue(target, prop.GetValue(source));

            }
            return target;
        }
    }
}
