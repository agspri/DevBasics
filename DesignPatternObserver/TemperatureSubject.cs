using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternObserver
{
    class TemperatureSubject
    {
        IList<IObserver> registeredObservers = new List<IObserver>();

        float _temp;
        public float Temperature
        {
            get => _temp;
            set
            {
                if (_temp != value)
                {
                    _temp = value;
                    Update();
                }
            }
        }

        public void Register(IObserver observer)
        {
            if (observer != null)
                lock (registeredObservers)
                {
                    registeredObservers.Add(observer);
                }
        }

        public void UnRegister(IObserver observer)
        {
            if (observer != null)
                lock (registeredObservers)
                {
                    registeredObservers.Remove(observer);
                }
        }

        void Update()
        {
            //// Variante 1:
            //lock (registeredObservers)
            //{
            //    foreach (IObserver observer in registeredObservers) // kann länger dauern
            //        observer.Update(this.Temperature);
            //}

            //// Variante 2:
            List<IObserver> workingList = new List<IObserver>(registeredObservers.Count);
            lock (registeredObservers)
            {
                workingList.AddRange(registeredObservers);
            }

            foreach (IObserver observer in workingList)  // kann länger dauern
                    observer.Update(this.Temperature);

        }
    }
}
