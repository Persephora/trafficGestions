using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace InnovationStrategies
{
    public class TrafficViolation
    {
        private string idTrafficViolation;
        private string polismanId;
        private DateTime date;
        private string description;
        private string type;
        private string car;
        private int points;

        public string IdTrafficViolation { get => idTrafficViolation; set => idTrafficViolation = value; }
        public string PolismanId { get => polismanId; set => polismanId = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Description { get => description; set => description = value; }
        public string Car { get => car; set => car = value; }
        public int Points { get => points; set => points = value; }
        public string Type { get => type; set => type = value; }

        public TrafficViolation() { }

        public TrafficViolation(string idTrafficViolation, string polismaId, string type, DateTime date, string description, string car, int points)
        {
            IdTrafficViolation = idTrafficViolation;
            PolismanId = polismaId;
            Type = type;
            Date = date;
            Description = description;
            Car = car;
            Points = points;
        }
        public override string ToString()
        {
            return $"idTrafficViolation: {this.IdTrafficViolation}" +
                             $"polismaId: {this.PolismanId}" +
                             $"type: {this.Type}" +
                             $"date: {this.Date}" +
                             $"description: {this.Description}" +
                             $"car: {this.Car}" +
                             $"points: {this.Points}";
        }
        public string driverToString()
        {
            return $"date: {this.Date}" +
                             $"description: {this.Description}" +
                             $"type: {this.IdTrafficViolation}" +
                             $"car: {this.Car}" +
                             $"points: {this.Points}";
        }
        public string policeTrafficToString()
        {
            return $"date: {this.Date}" +
                             $"date: {this.Date}" +
                             $"description: {this.Description}" +
                             $"type: {this.IdTrafficViolation}" +
                             $"car: {this.Car}" +
                             $"points: {this.Points}";
        }
    }

    public class TrafficViolations : IEnumerable
    {
        private TrafficViolation[] _trafficViolations;
        public TrafficViolations(TrafficViolation[] tvArray)
        {
            _trafficViolations = new TrafficViolation[tvArray.Length];
            for (int i = 0; i < tvArray.Length; i++)
            {
                _trafficViolations[i] = tvArray[i];
                Console.Write($"date: {_trafficViolations[i].Date}{System.Environment.NewLine}" +
                                 $"description: {_trafficViolations[i].Description}{System.Environment.NewLine}" +
                                 $"type: {_trafficViolations[i].IdTrafficViolation}{System.Environment.NewLine}" +
                                 $"car: {_trafficViolations[i].Car}{System.Environment.NewLine}" +
                                 $"points: {_trafficViolations[i].Points}" +
                                 $"{System.Environment.NewLine}");
            }
        }

        public TrafficViolations(List<TrafficViolation> trafficViolations, string polismanId)
        {
            trafficViolations = trafficViolations.Where(x => x.PolismanId.Equals(polismanId)).ToList();
            _trafficViolations = trafficViolations.ToArray();
            foreach (TrafficViolation t in trafficViolations)
                Console.Write($"date: {t.Date}{System.Environment.NewLine}" +
                                 $"description: {t.Description}{System.Environment.NewLine}" +
                                 $"type: {t.IdTrafficViolation}{System.Environment.NewLine}" +
                                 $"car: {t.Car}{System.Environment.NewLine}" +
                                 $"points: {t.Points}{System.Environment.NewLine}" +
                                 $"{System.Environment.NewLine}");
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public TrafficViolationEnum GetEnumerator()
        {
            return new TrafficViolationEnum(_trafficViolations);
        }
        public class TrafficViolationEnum : IEnumerator
        {
            public TrafficViolation[] _trafficViolations;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public TrafficViolationEnum(TrafficViolation[] list)
            {
                _trafficViolations = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _trafficViolations.Length);
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
                        if (position == -1) return "ERROR: There are no traffic violations";
                        return _trafficViolations[position].ToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            public string CurrentDriver
            {
                get
                {
                    try
                    {
                        if (position == -1) return "ERROR: There are no traffic violations";
                        return _trafficViolations[position].driverToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            public string CurrentTrafficViolation
            {
                get
                {
                    try
                    {
                        if (position == -1) return "ERROR: There are no traffic violations";
                        return _trafficViolations[position].policeTrafficToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }

    public class TrafficViolationType : TrafficViolation
    {
        private string idTrafficViolation;
        private double arcticle;
        private string description;
        private int points;
        private int numberOfViolations = 0;

        public double Arcticle { get => arcticle; set => arcticle = value; }
        public string Description { get => description; set => description = value; }
        public int Points { get => points; set => points = value; }
        public int NumberOfViolations { get => numberOfViolations; set => numberOfViolations = value; }
        public string IdTrafficViolation1 { get => idTrafficViolation; set => idTrafficViolation = value; }

        public TrafficViolationType(string idTrafficViolation, double arcticle, string description, int points)
        {
            IdTrafficViolation = idTrafficViolation;
            Arcticle = arcticle;
            Description = description;
            Points = points;
        }
        public override string ToString()
        {
            return $"id: {this.IdTrafficViolation}" +
                             $"article: {this.Arcticle.ToString().Replace(',', '.')}" +
                             $"description: {this.Description}" +
                             $"points: {this.Points}" +
                             $"numberOfViolations: {this.NumberOfViolations}";
        }
    }
    public class TrafficViolationTypes : IEnumerable
    {
        private TrafficViolationType[] _trafficViolationTypes;
        public TrafficViolationTypes(TrafficViolationType[] tvArray)
        {
            _trafficViolationTypes = new TrafficViolationType[tvArray.Length];
            for (int i = 0; i < tvArray.Length; i++)
            {
                _trafficViolationTypes[i] = tvArray[i];
                Console.Write($"id: {_trafficViolationTypes[i].IdTrafficViolation}{System.Environment.NewLine}" +
                                 $"article: {_trafficViolationTypes[i].Arcticle}{System.Environment.NewLine}" +
                                 $"description: {_trafficViolationTypes[i].Description}{System.Environment.NewLine}" +
                                 $"numberOfViolations: {_trafficViolationTypes[i].NumberOfViolations}{System.Environment.NewLine}");
            }
        }
        public TrafficViolationTypes(List<TrafficViolationType> trafficViolationTypesList)
        {
            trafficViolationTypesList = trafficViolationTypesList.Where(x => x.NumberOfViolations > 0).OrderByDescending(x => x.NumberOfViolations).ToList();
            foreach (TrafficViolationType t in trafficViolationTypesList)
            {
                _trafficViolationTypes = trafficViolationTypesList.ToArray();
                Console.Write($"id: {t.IdTrafficViolation}{System.Environment.NewLine}" +
                                 $"article: {t.Arcticle.ToString(CultureInfo.InvariantCulture).Replace(",", ".")}{System.Environment.NewLine}" +
                                 $"description: {t.Description}{System.Environment.NewLine}" +
                                 $"points: {t.Points}{System.Environment.NewLine}" +
                                 $"numberOfViolations: {t.NumberOfViolations}{System.Environment.NewLine}" +
                                 $"{System.Environment.NewLine}");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public TrafficViolationTypeEnum GetEnumerator()
        {
            return new TrafficViolationTypeEnum(_trafficViolationTypes);
        }
        public class TrafficViolationTypeEnum : IEnumerator
        {
            public TrafficViolationType[] _trafficViolationTypes;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            int position = -1;

            public TrafficViolationTypeEnum(TrafficViolationType[] list)
            {
                _trafficViolationTypes = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _trafficViolationTypes.Length);
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
                        if (position == -1) return "ERROR: There are no traffic violations";
                        return _trafficViolationTypes[position].ToString();
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
