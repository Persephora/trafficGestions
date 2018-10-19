using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using trafficGestions;

namespace InnovationStrategies
{
    public class Program
    {
        public static List<Car> carsList = new List<Car>();
        public static List<Driver> driversList = new List<Driver>();
        public static List<Polisman> polismenList = new List<Polisman>();
        public static List<TrafficViolation> trafficViolationsList = new List<TrafficViolation>();
        public static List<TrafficViolationType> trafficViolationTypesList = new List<TrafficViolationType>();
        public static void Main()
        {
            string result = string.Empty;
            drivers();

            addDriver("000000A", "Joan", "Lopez");
            addDriver("111111A", "Philip", "McCarthy");
            addDriver("222222B", "Jooooooohn", "Petit");
            addDriver("333333C", "Peter", "Esteban");
            addDriver("444444D", "Laura", "Torres");

            drivers();

            addDriver("222222B", "John", "Petit");
            addDriver("444444C", "Alba", "O");

            drivers();

            cars();

            addCar("B-2251-VG", "Seat", "Ibiza", "XXXXXXXXXX");
            addCar("B-2251-VG", "Seat", "Ibiza", "222222B");

            addCar("B-2251-VG", "Seat", "Ibiza", "222222B");
            addCar("B-6666-AT", "Seat", "600", "222222B");

            addCar("B-777-VZ", "Seat", "Ibiza", "000000A");
            addCar("B-3413-AA", "Huynday", "IONIQ", "000000A");
            addCar("BMG-53326", "Renoult", "Laguna", "000000A");
            addCar("BMG-533326", "Renoult", "Express", "000000A");
            addCar("BBB-21526", "Renoult", "Clio", "000000A");
            addCar("BBB-23321", "Renoult", "7", "000000A");
            addCar("BCB-22444", "Mercedes", "300i", "000000A");
            addCar("BCB-21392", "Mercedes", "600i", "000000A");
            addCar("BCB-2462", "Mercedes", "700i", "000000A");
            addCar("BCB-1246", "Mercedes", "800i", "000000A");

            addCar("BCB-2222", "Mercedes", "900i", "000000A");

            addCar("BMG-2222", "Audi", "Q3", "444444C");
            addCar("BXX-9131", "Ferrari", "Testarrosa", "444444D");

            drivers();
            cars();

            trafficViolationTypes();
            addTrafficViolationType("TRAFFIC_SIGNAL_LIGHTS", 207.3, "TRAFFIC_SIGNAL_LIGHTS_DESCRIPTION", 3);
            addTrafficViolationType("MAX_SPEED", 500.2, "MAX_SPEED_DESCRIPTION", 5);
            addTrafficViolationType("MOBILE_WHILE_DRIVING", 600.2, "MOBILE_WHILE_DRIVING_DESCRIPTION", 1);
            addTrafficViolationType("DRIVER_WITHOUT_LICENSE", 543.1, "DRIVER_WITHOUT_LICENSE_DESCRIPTION", 2);
            addTrafficViolationType("CHILD_NO_SAFETY_SEAT", 780.33, "CHILD_NO_SAFETY_SEAT_DESCRIPTION", 5);
            addTrafficViolationType("EXCEED_EMISSIONS", 333.1, "EXCEED_EMISSIONS_DESCRIPTION", 1);
            addTrafficViolationType("DRINK_AND_DRIVE", 999.2, "DRINK_AND_DRIVE_DESCRIPTION", 8);

            trafficViolationTypes();

            getDriverTrafficViolations("000000A");
            getDriverTrafficViolations("222222B");

            getDriversPoints("B-2251-VG");

            polismen();

            addPoliceman("P1000", "John", "Smith");
            addPoliceman("P2000", "Eve", "McMackenzie");
            addPoliceman("P3000", "Diana", "Gabaldon");
            addPoliceman("P4000", "Ronald", "Foerster");
            addPoliceman("P5000", "Diana", "Bistrow");

            polismen();

            registerTrafficViolation("B-2251-VG", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-10-2016 20:00:00"), "theDesciption1");
            registerTrafficViolation("B-6666-AT", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("27-10-2016 20:00:00"), "theDesciption2");

            getDriversPoints("B-2251-VG");

            getDriverTrafficViolations("222222B");

            registerTrafficViolation("B-2251-VG", "P5000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-10-2016 19:00:00"), "theDesciption3");

            getDriversPoints("B-2251-VG");

            getDriverTrafficViolations("222222B");

            registerTrafficViolation("B-2251-VG", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-10-2016 20:30:00"), "theDesciption4");

            getDriverTrafficViolations("222222B");

            topTrafficViolations();

            registerTrafficViolation("BCB-2462", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-10-2016 20:30:00"), "theDesciption5");
            registerTrafficViolation("BCB-22444", "P3000", "MAX_SPEED", Convert.ToDateTime("30-10-2016 20:30:00"), "theDesciption6");
            registerTrafficViolation("BMG-2222", "P5000", "MAX_SPEED", Convert.ToDateTime("30-10-2016 20:30:00"), "theDesciption7");

            topTrafficViolations();

            topPolismen();

            drivers();

            registerTrafficViolation("B-777-VZ", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-12-2016 20:30:00"), "theDesciption5");

            drivers();

            registerTrafficViolation("BMG-2222", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-12-2016 20:30:00"), "theDesciption5");
            registerTrafficViolation("BMG-2222", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-12-2016 20:30:00"), "theDesciption4");

            registerTrafficViolation("BMG-2222", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("27-12-2016 20:30:00"), "theDesciption4");

            registerTrafficViolation("BXX-9131", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-12-2016 20:30:00"), "theDesciption5");
            registerTrafficViolation("BXX-9131", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-12-2016 20:30:00"), "theDesciption4");
            registerTrafficViolation("BXX-9131", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("27-12-2016 20:30:00"), "theDesciption4");
            registerTrafficViolation("BXX-9131", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("25-12-2016 20:30:00"), "theDesciption4");
            registerTrafficViolation("BXX-9131", "P3000", "MAX_SPEED", Convert.ToDateTime("29-12-2016 20:30:00"), "theDesciption4");

            drivers();

            getPolismanTrafficViolation("P5000");

            getPolismanTrafficViolation("P3000");
        }



        //Method to add a driver
        public static void addDriver(string dni, string name, string surname = "", int points = 14)
        {
            try
            {
                //Check if driver exists
                if (driversList.Exists(d => d.Id.Equals(dni)))
                {
                    //If driver exists we wil update it
                    Driver foundDriver = driversList.Find(d => d.Id.Equals(dni));
                    //Compare driver to add with driver in list and update
                    if (!foundDriver.Name.Equals(name))
                        foundDriver.Name = name;
                    else if (!foundDriver.Surname.Equals(surname))
                        foundDriver.Surname = surname;
                    else if (foundDriver.Points != points)
                        foundDriver.Points = points;
                    else
                    {
                        //If driver exists return error
                        Console.Write("ERROR: Driver alredy exist");
                    }
                }
                else
                {  //If driver doesn't exists we wil create it
                    driversList.Add(new Driver(dni, name, surname, points));
                }
                //And sort list by id
                driversList = driversList.OrderBy(x => x.Id).ToList();
            }
            catch (Exception e)
            {
                Console.Write($"Method:addDriver. {System.Environment.NewLine}" +
                                $"Error: {e.ToString()}.{System.Environment.NewLine}" +
                                $"Message: {e.Message}.{System.Environment.NewLine}");
            }
        }

        //Method to add a car
        public static string addCar(string carPlate, string brand, string model, string dniUsualDriver)
        {
            string result = string.Empty;
            try
            {
                //Search if driver exists
                //If driver exists
                if (driversList.Exists(d => d.Id.Equals(dniUsualDriver)))
                {
                    Driver usualDriver = driversList.Find(d => d.Id.Equals(dniUsualDriver));
                    //Search if car exists
                    //If car alredy exists
                    if (carsList.Exists(c => c.CarPlate.Equals(carPlate)))
                    {
                        result = "ERROR: Car already exists";
                    }
                    //If car not exist add car to list
                    else
                    {
                        //Check if driver has less than ten cars.
                        if (usualDriver.NumOfCars < 10)
                        {
                            //If numOfCars is less than 10 addCar
                            carsList.Add(new Car(carPlate, brand, model, dniUsualDriver));
                            usualDriver.NumOfCars++;
                            return "";
                        }
                        else
                        {
                            result = "ERROR: Max number of cars";
                        }
                    }
                }
                //If driver not exist
                else
                {
                    result = "ERROR: Driver not found";
                }
                return result;
            }
            catch (Exception e)
            {
                Console.Write($"Method:addCar. {System.Environment.NewLine}" +
                                $"Error: {e.ToString()}.{System.Environment.NewLine}" +
                                $"Message: {e.Message}.{System.Environment.NewLine}");
                return result;
            }
        }

        //Method to register a traffic violation
        public static string registerTrafficViolation(string carPlate, string polismanId, string idTrafficViolation, DateTime date, string description)
        {
            string result = string.Empty;
            try
            {
                //Search and get trafficViolationType
                TrafficViolationType typeOfTrafficViolation = trafficViolationTypesList.Find(x => x.IdTrafficViolation.Equals(idTrafficViolation));
                if (typeOfTrafficViolation != null)
                {
                    //Seach and get driver
                    Driver driverInfractor = driversList.Find(x => x.Id.Equals(carsList.Find(c => c.CarPlate.Equals(carPlate)).Driver));
                    //If driver has a valid license (with points)
                    if (driverInfractor.Points > 0)
                    {
                        //Save trafficViolation in temporal variable
                        TrafficViolation trafficViolationtoAdd = new TrafficViolation(idTrafficViolation, polismanId, typeOfTrafficViolation.Description, date, description, carPlate, typeOfTrafficViolation.Points);
                        //Search all driver's car
                        List<string> driverCars = carsList.Where(x => x.Driver.Equals(driverInfractor.Id)).Select(x => x.CarPlate).ToList();
                        //Search all trafficViolations of all driver's car
                        List<TrafficViolation> driverTrafficViolations = trafficViolationsList.Where(x => driverCars.Contains(x.Car)).OrderByDescending(x => x.Date).ToList();
                        if (driverTrafficViolations.Count() > 0)
                        {
                            TrafficViolation lastDriverTrafficViolation = driverTrafficViolations.First();
                            //If trafficViolation to add is more older than the previous trafficViolation
                            if (lastDriverTrafficViolation.Date.CompareTo(trafficViolationtoAdd.Date) > 0)
                            {
                                //Check points of driver
                                if ((driverInfractor.Points - trafficViolationtoAdd.Points) <= 0 && driverInfractor.Points >= 0)
                                {
                                    trafficViolationsList.Remove(lastDriverTrafficViolation);
                                    //driverInfractor.Points += lastDriverTrafficViolations.Points;
                                    result = updateDriverPoints(driverInfractor, typeOfTrafficViolation);
                                    //Increment numberOfViolations in typeTrafficViolation and policeman
                                    typeOfTrafficViolation.NumberOfViolations++;
                                    polismenList.Find(x => x.PolismanId.Equals(polismanId)).NumberOfViolations++;
                                    //Add trafficViolatio to List
                                    trafficViolationsList.Add(trafficViolationtoAdd);
                                }
                                else
                                {
                                    //Increment numberOfViolations in typeTrafficViolation and policeman
                                    result = updateDriverPoints(driverInfractor, typeOfTrafficViolation);
                                    typeOfTrafficViolation.NumberOfViolations++;
                                    polismenList.Find(x => x.PolismanId.Equals(polismanId)).NumberOfViolations++;
                                    trafficViolationsList.Add(trafficViolationtoAdd);
                                }

                            }
                            else
                            {
                                result = updateDriverPoints(driverInfractor, typeOfTrafficViolation);
                                //Increment numberOfViolations in typeTrafficViolation and policeman
                                typeOfTrafficViolation.NumberOfViolations++;
                                polismenList.Find(x => x.PolismanId.Equals(polismanId)).NumberOfViolations++;
                                trafficViolationsList.Add(trafficViolationtoAdd);
                            }
                        }
                        else
                        {
                            result = updateDriverPoints(driverInfractor, typeOfTrafficViolation);
                            //Increment numberOfViolations in typeTrafficViolation and policeman
                            typeOfTrafficViolation.NumberOfViolations++;
                            polismenList.Find(x => x.PolismanId.Equals(polismanId)).NumberOfViolations++;
                            //If driver hasn't trafficViolations
                            trafficViolationsList.Add(trafficViolationtoAdd);
                        }
                    }
                    else
                    {
                        result = "ERROR: Driver without license";
                        Console.Write($"ERROR: Driver without license{System.Environment.NewLine}");
                    }
                    trafficViolationsList = trafficViolationsList.OrderBy(x => x.Date).ToList();
                }
            }
            catch (Exception e)
            {
                Console.Write($"Method:registerTrafficViolation. {System.Environment.NewLine}" +
                                $"Error: {e.ToString()}.{System.Environment.NewLine}" +
                                $"Message: {e.Message}.{System.Environment.NewLine}");
            }
            return result;
        }

        //Method de add type of traffic violation
        public static void addTrafficViolationType(string idTrafficViolation, double article, string description, int points)
        {
            try
            {
                trafficViolationTypesList.Add(new TrafficViolationType(idTrafficViolation, article, description, points));

            }
            catch (Exception e)
            {
                Console.Write($"Method:addTrafficViolationType. {System.Environment.NewLine}" +
                                $"Error: {e.ToString()}.{System.Environment.NewLine}" +
                                $"Message: {e.Message}.{System.Environment.NewLine}");
            }
        }

        //Method to add a policeman
        public static void addPoliceman(string polismanId, string name, string surname)
        {
            try
            {
                polismenList.Add(new Polisman(polismanId, name, surname));
            }
            catch (Exception e)
            {
                Console.Write($"Method:addPoliceman. {System.Environment.NewLine}" +
                                $"Error: {e.ToString()}.{System.Environment.NewLine}" +
                                $"Message: {e.Message}.{System.Environment.NewLine}");
            }
        }

        //Method to get points of driver
        public static int getDriversPoints(string carPlate)
        {
            try
            {
                int points = 0;
                points = driversList.Where(d => d.Id.Equals(carsList.Find(x => x.CarPlate.Equals(carPlate)).Driver)).Select(d => d.Points).ToList()[0];
                Console.Write(points + System.Environment.NewLine);
                return points;
            }
            catch (Exception e)
            {
                Console.Write($"Method:getDriversPoints. {System.Environment.NewLine}" +
                                $"Error: {e.ToString()}.{System.Environment.NewLine}" +
                                $"Message: {e.Message}.{System.Environment.NewLine}");
                return -1;
            }
        }

        //Get driver's traffic violations
        public static TrafficViolations.TrafficViolationEnum getDriverTrafficViolations(string dni)
        {
            List<TrafficViolation> driverTrafficViolationsList = new List<TrafficViolation>();
            List<Car> driverCars = carsList.Where(x => x.Driver.Equals(dni)).ToList();
            foreach (Car driverCar in driverCars)
            {
                List<TrafficViolation> trafficViolations = trafficViolationsList.Where(tv => tv.Car.Equals(driverCar.CarPlate)).Select(x => x).ToList();
                foreach (TrafficViolation trafficViolation in trafficViolations)
                {
                    if (trafficViolation != null)
                        driverTrafficViolationsList.Add(trafficViolation);
                }
            }
            TrafficViolations driverTrafficViolations = new TrafficViolations(driverTrafficViolationsList.ToArray());
            return driverTrafficViolations.GetEnumerator();
        }

        //Method to get most frecuent traffic violations
        public static TrafficViolationTypes.TrafficViolationTypeEnum topTrafficViolations()
        {
            TrafficViolationTypes topTrafficViolations = new TrafficViolationTypes(trafficViolationTypesList);
            return topTrafficViolations.GetEnumerator();
        }

        //Method to get traffic violations of policeman
        public static TrafficViolations.TrafficViolationEnum getPolismanTrafficViolation(string polismanId)
        {
            TrafficViolations polismanTrafficViolations = new TrafficViolations(trafficViolationsList, polismanId);
            return polismanTrafficViolations.GetEnumerator();
        }

        //Get top polismenS
        public static Polismen.PolismenEnum topPolismen()
        {
            Polismen polismen = new Polismen(polismenList, true);
            return polismen.GetEnumerator();
        }

        //Getter drivers
        public static Drivers.DriversEnum drivers()
        {
            Drivers drivers = new Drivers(driversList);
            Drivers.DriversEnum driversEnum = drivers.GetEnumerator();
            return driversEnum;
        }

        //Method to get cars
        public static Cars.CarsEnum cars()
        {
            Cars cars = new Cars(carsList);
            return cars.GetEnumerator();
        }
        //Method to get polismen
        public static Polismen.PolismenEnum polismen()
        {
            Polismen polismen = new Polismen(polismenList);
            return polismen.GetEnumerator();
        }
        //Method to get traffic violation types
        public static TrafficViolationTypes.TrafficViolationTypeEnum trafficViolationTypes()
        {
            TrafficViolationTypes trafficViolationTypes = new TrafficViolationTypes(trafficViolationTypesList.ToArray());
            return trafficViolationTypes.GetEnumerator();
        }
        //Method to update driver points
        static string updateDriverPoints(Driver driver, TrafficViolationType typeOfTrafficViolation)
        {
            if ((driver.Points - typeOfTrafficViolation.Points) > 0)
            {
                driver.Points = driver.Points - typeOfTrafficViolation.Points;
            }
            else
                driver.Points = 0;
            Console.Write($"Driver ({driver.Id}) with {driver.Points} points{System.Environment.NewLine}");
            return $"Driver ({driver.Id}) with {driver.Points} points";
        }
    }
}
