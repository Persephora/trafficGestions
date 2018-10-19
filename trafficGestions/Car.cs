using System;
using System.Collections;
using System.Collections.Generic;

namespace InnovationStrategies
{
    public class Car
    {
        private string carPlate;
        private string brand;
        private string model;
        private string driver;

        public string CarPlate { get => carPlate; set => carPlate = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Driver { get => driver; set => driver = value; }

        public Car(string carPlate, string brand, string model, string driver)
        {
            CarPlate = carPlate;
            Brand = brand;
            Model = model;
            Driver = driver;
        }
        public Car() { }
        public string Error(string typeError)
        {
            string error = string.Empty;
            switch (typeError)
            {
                case "car":
                    error = "ERROR: Car alredy exists";
                    break;
                case "noDriver":
                    error = "ERROR: Driver not found";
                    break;
                case "max":
                    error = "ERROR: Max number of cars";
                    break;
            }
            return error;
        }
        public override string ToString()
        {
            return $"carPlate: {this.CarPlate}" +
                             $"brand: {this.Brand}" +
                             $"model: {this.Model}" +
                             $"driver: {this.Driver}";
        }
    }
    public class Cars : IEnumerable
    {
        private List<Car> _cars = new List<Car>();
        public Cars(List<Car> cars)
        {
            _cars = cars;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public CarsEnum GetEnumerator()
        {
            return new CarsEnum(_cars);
        }
        public class CarsEnum : IEnumerator
        {
            public List<Car> _cars;

            int position = -1;

            public CarsEnum(List<Car> list)
            {
                _cars = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _cars.Count);
            }
            public void GoToLast()
            {
                position = _cars.Count - 1;
            }
            public bool MovePrevious()
            {
                position--;
                return (position > 0);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public string Current
            {
                get
                {
                    try
                    {
                        if (position == -1) return "ERROR: There are no cars";
                        return _cars[position].ToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}

