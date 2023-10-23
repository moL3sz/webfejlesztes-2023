namespace ESZD.Shared.Helpers
{
    public class TypeHelper
    {


        /// <summary>
        ///  T->J típus konverzió, T minden mezőjének értéke átkerül J - be!
        /// </summary>
        /// <param name="T">Milyen típúsból</param>
        /// <param name="J">Mibe</param>
        /// <param name="obj"></param>
        public static object ChangeType(Type T, Type J, object obj)
        {
            var correctInstance = Activator.CreateInstance(J);
            T.GetProperties().ToList().ForEach(x =>
            {

                var correntInstanceProp = correctInstance.GetType().GetProperty(x.Name);
                if (J.GetProperty(x.Name) == null)
                {
                    return;
                }
                if (correntInstanceProp?.SetMethod == null)
                {
                    return;
                }
                correntInstanceProp.SetValue(correctInstance, x.GetValue(obj));

            });
            return correctInstance;
        }
    }
}
