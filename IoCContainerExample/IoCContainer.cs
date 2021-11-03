using System;
using System.Collections.Generic;
using System.Text;

namespace IoCContainerExample
{
    public enum Lifetimes
    {
        Singleton,
        Instance
    }

    /// <summary>
    /// Die Aufgabe eines IoC-Container ist es (vereinfacht)
    /// eine entsprechende Implementierung (Object) zu liefern, auf 
    /// Basis eines Interface, das ich ihm gebe.
    /// Damit der IoC-Container "weiss" welche Implementierung bei welchem
    /// Interface geliefert werden soll, werden diese über die 
    /// Register-Methode registriert.
    /// </summary>
    class IoCContainer
    {
        /// <summary>
        /// Der Datentype Type beschreibt einen Datentyp.
        /// Mittels typeof(int) oder int x = 3; x.GezType()
        /// erhält man dann ein entsprechendes Type-Objekt
        /// von int.
        /// </summary>
        ////IDictionary<Type, Type> storage = new Dictionary<Type, Type>();
        //// IDictionary<Type, Lifetimes> LifetimeContainer = new Dictionary<Type, Lifetimes>();
        IDictionary<Type, Tuple<Type, Lifetimes>> storage = new Dictionary<Type, Tuple<Type, Lifetimes>>();
        IDictionary<Type, object> singletonContainer = new Dictionary<Type, object>();

        public void Register<TInterface, TImplementation>(Lifetimes lifetime = Lifetimes.Instance)
                    where TImplementation:TInterface, new()   // constraints
        {
            //// Wird lesbarer wenn man folgendes benutzt!?
            //Type interfaceType = typeof(TInterface);
            //Type implementationType = typeof(TImplementation);

            if (storage.ContainsKey(typeof(TInterface)))
            {    // Registrierung aktualisieren
                storage[typeof(TInterface)] = new Tuple<Type, Lifetimes>(typeof(TImplementation), lifetime);
            } else
            {   // neue Registrierung
                storage.Add( new KeyValuePair<Type, Tuple<Type, Lifetimes>>( typeof(TInterface),
                             new Tuple<Type, Lifetimes>(typeof(TImplementation), lifetime) ));
            }
        }

        public TInterface Resolve<TInterface>()
        {
            if (!storage.ContainsKey(typeof(TInterface)))
            {
                throw new InvalidOperationException($"{ typeof(TInterface)} is not yet registered.");
            }

            var implTypeAndLifeTime = storage[typeof(TInterface)];
            if (implTypeAndLifeTime.Item2 == Lifetimes.Singleton)
            {
               
                if (!singletonContainer.ContainsKey(implTypeAndLifeTime.Item1))  // singleton does not exists
                {
                    singletonContainer.Add(
                        new KeyValuePair<Type, object>(
                            implTypeAndLifeTime.Item1,
                            Activator.CreateInstance(implTypeAndLifeTime.Item1)
                        ));
                }

                // Der Container enthält Objkte des Typs onject. Daher muss zu TInterface ge-castest werden.
                return (TInterface)singletonContainer[implTypeAndLifeTime.Item1];
            }

            return (TInterface)Activator.CreateInstance(implTypeAndLifeTime.Item1);
        }
    }
}
