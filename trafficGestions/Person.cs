using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnovationStrategies
{
    public class Person
    {
        private string name;
        private string surname;
        private string error;
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Error { get => error; set => error = value; }
    }

    public class Polisman : Person
    {
        private string polismanId;
        private int numberOfViolations = 0;
        public string PolismanId { get => polismanId; set => polismanId = value; }
        public int NumberOfViolations { get => numberOfViolations; set => numberOfViolations = value; }

        public Polisman(string polismanId, string name, string surname)
        {
            PolismanId = polismanId;
            Name = name;
            Surname = surname;
        }

        public Polisman(string error)
        {
            this.Error = error;
        }
        public override string ToString()
        {

            return $"polismanId: {this.polismanId}" +
                        $"name: {this.Name}" +
                        $"surname: {this.Surname}" +
                        $"number of trafficViolations: {this.numberOfViolations}";
        }
    }

    public class Polismen : IEnumerable
    {
        private List<Polisman> _polismen;
        public Polismen(List<Polisman> polismen)
        {
            _polismen = polismen;
        }
        public Polismen(List<Polisman> polismenList, bool top)
        {
            polismenList = polismenList.Where(x => x.NumberOfViolations > 0).OrderByDescending(x => x.NumberOfViolations).ToList();
            _polismen = polismenList;
            foreach (Polisman polisman in polismenList)
            {
                
                Console.Write($"polismanId: {polisman.PolismanId}{System.Environment.NewLine}" +
                                 $"name: {polisman.Name}{System.Environment.NewLine}" +
                                 $"surname: {polisman.Surname}{System.Environment.NewLine}" +
                                 $"number of trafficViolations: {polisman.NumberOfViolations}{ System.Environment.NewLine}" +
                                 $"{System.Environment.NewLine}");
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public PolismenEnum GetEnumerator()
        {
            return new PolismenEnum(_polismen);
        }
        public class PolismenEnum : IEnumerator
        {
            public List<Polisman> _polismen;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public PolismenEnum(List<Polisman> list)
            {
                _polismen = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _polismen.Count);
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
                        if (position == -1) return "ERROR: There are no polismen";
                        return _polismen[position].ToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }

    public class Driver : Person
    {
        private string id;
        private int numOfCars = 0;
        private int points = 14;
        private string error;

        public string Id { get => id; set => id = value; }
        public int NumOfCars { get => numOfCars; set => numOfCars = value; }
        public int Points { get => points; set => points = value; }
        public string Error { get => error; set => error = value; }

        public Driver(string error)
        {
            this.Error = error;
        }

        public Driver(string id, string name, string surname, int points)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Points = points;
        }

        public override string ToString()
        {
            return $"id: {this.Id}" +
                             $"name: {this.Name}" +
                             $"surname: {this.Surname}" +
                             $"numOfCars: {this.NumOfCars}" +
                             $"points: {this.Points}";
        }
    }

    public class Drivers : IEnumerable
    {
        internal List<Driver> driversList = new List<Driver>();
        public Drivers(List<Driver> listDrivers)
        {
            driversList = listDrivers;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public DriversEnum GetEnumerator()
        {
            return new DriversEnum(driversList);
        }
        public class DriversEnum : IEnumerator
        {
            public List<Driver> _drivers;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public DriversEnum(List<Driver> list)
            {
                _drivers = list;
            }

            public bool MoveNext()
            {
                if (_drivers != null)
                {
                    position++;
                    return (position < _drivers.Count);
                }
                return false;
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
                        if (position == -1) return "ERROR: There are no drivers";
                        return _drivers[position].ToString();
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
