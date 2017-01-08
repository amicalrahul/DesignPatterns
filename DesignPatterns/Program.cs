﻿using DesignPatterns.BehaviorDesign;
using DesignPatterns.DecoratorDesign;
using DesignPatterns.DecoratorDesign.Decorators;
using DesignPatterns.ObserverDesign;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            DecoderDesignTest();
            BehaviorDesignTest();
            ObserverDesignTest();

            #region Commented Code

            //Doer doer = new Doer();

            //ConcurrentDictionary<int, int> cc = new ConcurrentDictionary<int, int>();
            //Dictionary<int, int> nm = new Dictionary<int, int>();
            ////nm.TryGetValue()
            ////cc.TryGetValue
            ////Maybe
            //UserInterface rr = new UserInterface();
            //doer.NotiLog += rr.Doer_NotiLog1;

            //doer.DoSomeWork("data"); 
            #endregion
            Console.ReadKey();
        }

        private static void DecoderDesignTest()
        {
            Console.WriteLine("Decorator Design Test Start");
            Beverage bevrage = new Espresso();
            bevrage = new Mocha(bevrage);
            bevrage = new Mocha(bevrage);
            bevrage = new Whip(bevrage);
            bevrage = new Soy(bevrage);

            Console.WriteLine($"Description: {bevrage.GetDescription()}, Cost: {bevrage.Cost()}");
            Console.WriteLine("Decorator Design Test End\n");
        }

        #region Observer Design Test
        private static void ObserverDesignTest()
        {
            Console.WriteLine("Observer Design Test Start");
            WeatherData wd = new WeatherData();

            CurentConditionsDisplay cc = new CurentConditionsDisplay(wd);

            wd.SetMeasurements(10, 12, 11);


            Console.WriteLine("Observer Design Test End\n");
        }
        #endregion

        #region Behavior Design Test
        private static void BehaviorDesignTest()
        {
            Console.WriteLine("Behavior Design Test Start");
            Duck duck = new MallardDuck();
            DuckOperations(duck);
            Console.WriteLine();

            duck = new MallardDuck();
            duck.SetFlyBehavior(new FlyNoWay());
            duck.SetQuackBehavior(new MuteQuack());
            DuckOperations(duck);
            Console.WriteLine("Behavior Design Test End\n");
        }

        private static void DuckOperations(Duck duck)
        {
            duck.Display();
            duck.PerformFly();
            duck.PerformQuack();
            duck.Swim();
        }
        #endregion
    }
    class UserInterface
    {

        public void Doer_NotiLog1(object sender, string e)
        {
            Console.WriteLine("Doer_NotiLog");
        }

    }
    public class asdf : IObserver<Int16>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(short value)
        {
            throw new NotImplementedException();
        }
    }
    public class abc : IObservable<Int16>
    {
        public IDisposable Subscribe(IObserver<short> observer)
        {
            throw new NotImplementedException();
        }
    }
    class Doer
    {
        //public event delegate NotifySo;


        public event EventHandler<string> NotiLog;
        public event EventHandler<string> NotiLog1;

        //private void Notify()
        //{
        //    if(NotiLog != null)
        //    {
        //    }

        //   Console.WriteLine("Notify");
        //}
        //private void Notify1()
        //{
        //    Console.WriteLine("Notify1");
        //}

        public void DoSomeWork(string data)
        {
            Console.WriteLine("Write");
            if (NotiLog != null)
            {
                this.NotiLog(this, data);
            }

        }
        public void DoMore(string data)
        {
            Console.WriteLine("Write");

            if (NotiLog1 != null)
            {
                this.NotiLog1(this, data);
            }

        }
    }
}
