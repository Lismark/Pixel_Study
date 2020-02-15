using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _5lesson : MonoBehaviour
{
    public void Start()
    {
        Cat Default = new Cat();
        Cat Tilda = new Cat("Тильда", 3, 5.0f, 40, 20);
        Tilda.Age = 50;
        Tilda.Mew();
        Default.Mew();

        Vehicle Bus = new Bus();
        Vehicle Car = new Automobile();
        Vehicle Tractor = new Tractor();
        Vehicle Truck = new Truck();
        Bus.Beep();
        Car.Beep();
        Tractor.Beep();
        Truck.Beep();
    }
    public class Cat
    {

        public string name = "Default";
        private int age;
        public float weight;
        public int height;
        public int tailLong;

        public void Mew()
        {
            Debug.Log($"Имя: {name}, возраст: {age}, вес: {weight}, рост: {height}, длинна хвоста: {tailLong}");

        }

        public Cat(string name, int age, float weight, int height, int tailLong)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.tailLong = tailLong;
        }

        #region DefaultConstructor
        public Cat() 
        {
        // Конструктор по умолчанию
        }
        #endregion

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

    }
}

public abstract class Vehicle
{
    public string name;
    //public abstract void Beep()
    public virtual void Beep()
    {
        Debug.Log("Кря!");
    }
}

public class Bus : Vehicle
{
    public override void Beep()
    {
        Debug.Log("Beep!");
    }
}

public class Tractor : Vehicle
{
    public override void Beep()
    {
        Debug.Log("Beep-Beep!");
    }
}

public class Automobile : Vehicle
{
    public override void Beep()
    {
        Debug.Log("Beep-Beep-Beep!");
    }
}

public class Truck : Vehicle
{
    public override void Beep()
    {
        base.Beep();
    }
}
