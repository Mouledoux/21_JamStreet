using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mouledoux.Mediation
{
    public static class CatalogueMediator
    {
        private static HashSet<Type> m_knownTypes = new HashSet<Type>() { typeof(object), typeof(Type) };
        private static readonly Catalogue<Type>.Subscription addTypeSub;
        private static readonly Catalogue<Type>.Subscription removeTypeSub;

        static CatalogueMediator()
        {
            string addTypeMessage = "AddTypeToTranslator";
            string removeTypeMessage = "RemoveTypeFromTranslator";

            addTypeSub = new Catalogue<Type>.Subscription(addTypeMessage,
                (Type t) => m_knownTypes.Add(t), 99).Subscribe();

            removeTypeSub = new Catalogue<Type>.Subscription(removeTypeMessage,
                (Type t) => m_knownTypes.Remove(t), 99).Subscribe();
        }


        public static void NotifySubscribersAsync<T>(string a_message, T a_arg, bool a_holdMessage = false)
        {
            Task notifyTask = Task.Run(() =>
               NotifyAllSubscribers(a_message, a_arg, a_holdMessage));
        }

        public static void NotifyAllSubscribers<T>(string a_message, T a_arg, bool a_holdMessage = false, bool a_excludeTypeT = false)
        {
            Type typeT = typeof(T);

            TryAddTypedSubscription<T>();
            
            foreach (Type type in m_knownTypes)
            {
                if (a_excludeTypeT && type == typeT)
                {
                    continue;
                }
            }
        }

        public static void TryAddTypedSubscription<T>()
        {
            Type type = typeof(T);
            if (!m_knownTypes.Contains(type))
            {
                m_knownTypes.Add(type);
                Catalogue<T>.OnCatalogueEmpty += () => m_knownTypes.Remove(type);
            }
        }
    }
}