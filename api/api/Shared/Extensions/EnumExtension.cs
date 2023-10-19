using System.ComponentModel;
using System.Reflection;

namespace api.Shared.Extensions {
    public static class EnumExtension {

        public static string GetDiscription(this Enum value) {

            return value.ToString();
        }
    }
}
