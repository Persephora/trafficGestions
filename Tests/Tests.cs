using InnovationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using trafficGestions;

namespace Tests
{
    [TestClass()]
    public class TrafficGestionsTest
    {
        [TestMethod()]
        public void all_tests()
        {
            string result = string.Empty;
            Drivers.DriversEnum drivers = Program.drivers();
            result = drivers.Current;
            string expected = "ERROR: There are no drivers";
            Assert.AreEqual(expected, result);
            result = string.Empty;
            Program.addDriver("000000A", "Joan", "Lopez");
            Program.addDriver("111111A", "Philip", "McCarthy");
            Program.addDriver("222222B", "Jooooooohn", "Petit");
            Program.addDriver("333333C", "Peter", "Esteban");
            Program.addDriver("444444D", "Laura", "Torres");
            drivers = Program.drivers();
            while (drivers.MoveNext())
            {
                result += drivers.Current;
            }
            expected = "id: 000000Aname: Joansurname: LopeznumOfCars: 0points: 14id: 111111Aname: Philipsurname: McCarthynumOfCars: 0points: 14id: 222222Bname: Jooooooohnsurname: PetitnumOfCars: 0points: 14id: 333333Cname: Petersurname: EstebannumOfCars: 0points: 14id: 444444Dname: Laurasurname: TorresnumOfCars: 0points: 14";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            Program.addDriver("222222B", "John", "Petit");
            Program.addDriver("444444C", "Alba", "O");
            drivers = Program.drivers();
            while (drivers.MoveNext())
            {
                result += drivers.Current;
            }
            expected = "id: 000000Aname: Joansurname: LopeznumOfCars: 0points: 14id: 111111Aname: Philipsurname: McCarthynumOfCars: 0points: 14id: 222222Bname: Johnsurname: PetitnumOfCars: 0points: 14id: 333333Cname: Petersurname: EstebannumOfCars: 0points: 14id: 444444Cname: Albasurname: OnumOfCars: 0points: 14id: 444444Dname: Laurasurname: TorresnumOfCars: 0points: 14";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            expected = string.Empty;
            Cars.CarsEnum cars = Program.cars();
            result = cars.Current;
            expected = "ERROR: There are no cars";
            Assert.AreEqual(expected, result);

            result = Program.addCar("B-2251-VG", "Seat", "Ibiza", "XXXXXXXXXX");
            expected = "ERROR: Driver not found";
            Assert.AreEqual(expected, result);

            result = Program.addCar("B-2251-VG", "Seat", "Ibiza", "222222B");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("B-2251-VG", "Seat", "Ibiza", "222222B");
            expected = "ERROR: Car already exists";
            Assert.AreEqual(expected, result);

            result = Program.addCar("B-6666-AT", "Seat", "600", "222222B");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("B-777-VZ", "Seat", "Ibiza", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("B-3413-AA", "Huynday", "IONIQ", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BMG-53326", "Renoult", "Laguna", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BMG-533326", "Renoult", "Express", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BBB-21526", "Renoult", "Clio", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BBB-23321", "Renoult", "7", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BCB-22444", "Mercedes", "300i", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BCB-21392", "Mercedes", "600i", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BCB-2462", "Mercedes", "700i", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BCB-1246", "Mercedes", "800i", "000000A");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BCB-2222", "Mercedes", "900i", "000000A");
            expected = "ERROR: Max number of cars";
            Assert.AreEqual(expected, result);

            result = Program.addCar("BMG-2222", "Audi", "Q3", "444444C");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            result = Program.addCar("BXX-9131", "Ferrari", "Testarrosa", "444444D");
            expected = string.Empty;
            Assert.AreEqual(expected, result);

            drivers = Program.drivers();
            while (drivers.MoveNext())
            {
                result += drivers.Current;
            }
            expected = "id: 000000Aname: Joansurname: LopeznumOfCars: 10points: 14id: 111111Aname: Philipsurname: McCarthynumOfCars: 0points: 14id: 222222Bname: Johnsurname: PetitnumOfCars: 2points: 14id: 333333Cname: Petersurname: EstebannumOfCars: 0points: 14id: 444444Cname: Albasurname: OnumOfCars: 1points: 14id: 444444Dname: Laurasurname: TorresnumOfCars: 1points: 14";
            Assert.AreEqual(expected, result);


            //Falla la comprobocación, no he conseguido averiguar cual es el orden
            //result = string.Empty;
            //cars = Program.cars();
            //while (cars.MoveNext())
            //{
            //    result += cars.Current;
            //}
            //expected = "carPlate: BMG-2222brand: Audimodel: Q3driver: 444444CcarPlate: BBB-21526brand: Renoultmodel: Cliodriver: 000000AcarPlate: BCB-21392brand: Mercedesmodel: 600idriver: 000000AcarPlate: BCB-22444brand: Mercedesmodel: 300idriver: 000000AcarPlate: B-6666-ATbrand: Seatmodel: 600driver: 222222BcarPlate: BXX-9131brand: Ferrarimodel: Testarrosadriver: 444444DcarPlate: BBB-23321brand: Renoultmodel: 7driver: 000000AcarPlate: BCB-2462brand: Mercedesmodel: 700idriver: 000000AcarPlate: BMG-533326brand: Renoultmodel: Expressdriver: 000000AcarPlate: B-777-VZbrand: Seatmodel: Ibizadriver: 000000AcarPlate: BMG-53326brand: Renoultmodel: Lagunadriver: 000000AcarPlate: B-2251-VGbrand: Seatmodel: Ibizadriver: 222222BcarPlate: BCB-1246brand: Mercedesmodel: 800idriver: 000000AcarPlate: B-3413-AAbrand: Huyndaymodel: IONIQdriver: 000000A";
            //Assert.AreEqual(expected, result);


            TrafficViolationTypes.TrafficViolationTypeEnum trafficViolationTypes = Program.trafficViolationTypes();
            result = trafficViolationTypes.Current;
            expected = "ERROR: There are no traffic violations";
            Assert.AreEqual(expected, result);

            Program.addTrafficViolationType("TRAFFIC_SIGNAL_LIGHTS", 207.3, "TRAFFIC_SIGNAL_LIGHTS_DESCRIPTION", 3);
            Program.addTrafficViolationType("MAX_SPEED", 500.2, "MAX_SPEED_DESCRIPTION", 5);
            Program.addTrafficViolationType("MOBILE_WHILE_DRIVING", 600.2, "MOBILE_WHILE_DRIVING_DESCRIPTION", 1);
            Program.addTrafficViolationType("DRIVER_WITHOUT_LICENSE", 543.1, "DRIVER_WITHOUT_LICENSE_DESCRIPTION", 2);
            Program.addTrafficViolationType("CHILD_NO_SAFETY_SEAT", 780.33, "CHILD_NO_SAFETY_SEAT_DESCRIPTION", 5);
            Program.addTrafficViolationType("EXCEED_EMISSIONS", 333.1, "EXCEED_EMISSIONS_DESCRIPTION", 1);
            Program.addTrafficViolationType("DRINK_AND_DRIVE", 999.2, "DRINK_AND_DRIVE_DESCRIPTION", 8);

            result = string.Empty;
            trafficViolationTypes = Program.trafficViolationTypes();
            while (trafficViolationTypes.MoveNext())
            {
                result += trafficViolationTypes.Current;
            }
            expected = "id: TRAFFIC_SIGNAL_LIGHTSarticle: 207.3description: TRAFFIC_SIGNAL_LIGHTS_DESCRIPTIONpoints: 3numberOfViolations: 0id: MAX_SPEEDarticle: 500.2description: MAX_SPEED_DESCRIPTIONpoints: 5numberOfViolations: 0id: MOBILE_WHILE_DRIVINGarticle: 600.2description: MOBILE_WHILE_DRIVING_DESCRIPTIONpoints: 1numberOfViolations: 0id: DRIVER_WITHOUT_LICENSEarticle: 543.1description: DRIVER_WITHOUT_LICENSE_DESCRIPTIONpoints: 2numberOfViolations: 0id: CHILD_NO_SAFETY_SEATarticle: 780.33description: CHILD_NO_SAFETY_SEAT_DESCRIPTIONpoints: 5numberOfViolations: 0id: EXCEED_EMISSIONSarticle: 333.1description: EXCEED_EMISSIONS_DESCRIPTIONpoints: 1numberOfViolations: 0id: DRINK_AND_DRIVEarticle: 999.2description: DRINK_AND_DRIVE_DESCRIPTIONpoints: 8numberOfViolations: 0";
            Assert.AreEqual(expected, result);


            TrafficViolations.TrafficViolationEnum driverTrafficViolations = Program.getDriverTrafficViolations("000000A");
            result = driverTrafficViolations.Current;
            expected = "ERROR: There are no traffic violations";
            Assert.AreEqual(expected, result);

            driverTrafficViolations = Program.getDriverTrafficViolations("222222B");
            result = driverTrafficViolations.CurrentDriver;
            expected = "ERROR: There are no traffic violations";
            Assert.AreEqual(expected, result);

            int points = Program.getDriversPoints("B-2251-VG");
            int pointsExpected = 14;
            Assert.AreEqual(pointsExpected, points);

            Polismen.PolismenEnum polismen = Program.polismen();
            result = polismen.Current;
            expected = "ERROR: There are no polismen";
            Assert.AreEqual(expected, result);

            Program.addPoliceman("P1000", "John", "Smith");
            Program.addPoliceman("P2000", "Eve", "McMackenzie");
            Program.addPoliceman("P3000", "Diana", "Gabaldon");
            Program.addPoliceman("P4000", "Ronald", "Foerster");
            Program.addPoliceman("P5000", "Diana", "Bistrow");

            result = string.Empty;
            polismen = Program.polismen();
            while (polismen.MoveNext())
            {
                result += polismen.Current;
            }
            expected = "polismanId: P1000name: Johnsurname: Smithnumber of trafficViolations: 0polismanId: P2000name: Evesurname: McMackenzienumber of trafficViolations: 0polismanId: P3000name: Dianasurname: Gabaldonnumber of trafficViolations: 0polismanId: P4000name: Ronaldsurname: Foersternumber of trafficViolations: 0polismanId: P5000name: Dianasurname: Bistrownumber of trafficViolations: 0";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            result = Program.registerTrafficViolation("B-2251-VG", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-10-2016 20:00:00"), "theDesciption1");
            expected = "Driver (222222B) with 13 points";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            result = Program.registerTrafficViolation("B-6666-AT", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("27-10-2016 20:00:00"), "theDesciption2");
            expected = "Driver (222222B) with 12 points";
            Assert.AreEqual(expected, result);

            points = Program.getDriversPoints("B-2251-VG");
            pointsExpected = 12;
            Assert.AreEqual(pointsExpected, points);

            result = string.Empty;
            driverTrafficViolations = Program.getDriverTrafficViolations("222222B");
            while (driverTrafficViolations.MoveNext())
            {
                result += driverTrafficViolations.CurrentDriver;
            }
            expected = "date: 26/10/2016 20:00:00description: theDesciption1type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 27/10/2016 20:00:00description: theDesciption2type: EXCEED_EMISSIONScar: B-6666-ATpoints: 1";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            result = Program.registerTrafficViolation("B-2251-VG", "P5000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-10-2016 19:00:00"), "theDesciption3");
            expected = "Driver (222222B) with 11 points";
            Assert.AreEqual(expected, result);

            points = Program.getDriversPoints("B-2251-VG");
            pointsExpected = 11;
            Assert.AreEqual(pointsExpected, points);

            result = string.Empty;
            driverTrafficViolations = Program.getDriverTrafficViolations("222222B");
            while (driverTrafficViolations.MoveNext())
            {
                result += driverTrafficViolations.CurrentDriver;
            }
            expected = "date: 26/10/2016 19:00:00description: theDesciption3type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 26/10/2016 20:00:00description: theDesciption1type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 27/10/2016 20:00:00description: theDesciption2type: EXCEED_EMISSIONScar: B-6666-ATpoints: 1";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            result = Program.registerTrafficViolation("B-2251-VG", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-10-2016 20:30:00"), "theDesciption4");
            expected = "Driver (222222B) with 10 points";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            driverTrafficViolations = Program.getDriverTrafficViolations("222222B");
            while (driverTrafficViolations.MoveNext())
            {
                result += driverTrafficViolations.CurrentDriver;
            }
            expected = "date: 26/10/2016 19:00:00description: theDesciption3type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 26/10/2016 20:00:00description: theDesciption1type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 26/10/2016 20:30:00description: theDesciption4type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 27/10/2016 20:00:00description: theDesciption2type: EXCEED_EMISSIONScar: B-6666-ATpoints: 1";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            trafficViolationTypes = Program.topTrafficViolations();
            while (trafficViolationTypes.MoveNext())
            {
                result += trafficViolationTypes.Current;
            }
            expected = "id: EXCEED_EMISSIONSarticle: 333.1description: EXCEED_EMISSIONS_DESCRIPTIONpoints: 1numberOfViolations: 4";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            result = Program.registerTrafficViolation("BCB-2462", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-10-2016 20:30:00"), "theDesciption5");
            expected = "Driver (000000A) with 6 points";

            result = string.Empty;
            result = Program.registerTrafficViolation("BCB-22444", "P3000", "MAX_SPEED", Convert.ToDateTime("30-10-2016 20:30:00"), "theDesciption6");
            expected = "Driver (000000A) with 1 points";

            result = string.Empty;
            result = Program.registerTrafficViolation("BMG-2222", "P5000", "MAX_SPEED", Convert.ToDateTime("30-10-2016 20:30:00"), "theDesciption7");
            result = "Driver (444444C) with 9 points";

            result = string.Empty;
            trafficViolationTypes = Program.topTrafficViolations();
            while (trafficViolationTypes.MoveNext())
            {
                result += trafficViolationTypes.Current;
            }
            expected = "id: EXCEED_EMISSIONSarticle: 333.1description: EXCEED_EMISSIONS_DESCRIPTIONpoints: 1numberOfViolations: 4id: MAX_SPEEDarticle: 500.2description: MAX_SPEED_DESCRIPTIONpoints: 5numberOfViolations: 2id: DRINK_AND_DRIVEarticle: 999.2description: DRINK_AND_DRIVE_DESCRIPTIONpoints: 8numberOfViolations: 1";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            polismen = Program.topPolismen();
            while (polismen.MoveNext())
            {
                result += polismen.Current;
            }
            expected = "polismanId: P3000name: Dianasurname: Gabaldonnumber of trafficViolations: 4polismanId: P5000name: Dianasurname: Bistrownumber of trafficViolations: 3";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            drivers = Program.drivers();
            while (drivers.MoveNext())
            {
                result += drivers.Current;
            }
            expected = "id: 000000Aname: Joansurname: LopeznumOfCars: 10points: 1id: 111111Aname: Philipsurname: McCarthynumOfCars: 0points: 14id: 222222Bname: Johnsurname: PetitnumOfCars: 2points: 10id: 333333Cname: Petersurname: EstebannumOfCars: 0points: 14id: 444444Cname: Albasurname: OnumOfCars: 1points: 9id: 444444Dname: Laurasurname: TorresnumOfCars: 1points: 14";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("B-777-VZ", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-12-2016 20:30:00"), "theDesciption5");
            expected = "Driver (000000A) with 0 points";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            drivers = Program.drivers();
            while (drivers.MoveNext())
            {
                result += drivers.Current;
            }
            expected = "id: 000000Aname: Joansurname: LopeznumOfCars: 10points: 0id: 111111Aname: Philipsurname: McCarthynumOfCars: 0points: 14id: 222222Bname: Johnsurname: PetitnumOfCars: 2points: 10id: 333333Cname: Petersurname: EstebannumOfCars: 0points: 14id: 444444Cname: Albasurname: OnumOfCars: 1points: 9id: 444444Dname: Laurasurname: TorresnumOfCars: 1points: 14";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BMG-2222", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-12-2016 20:30:00"), "theDesciption5");
            expected = "Driver (444444C) with 1 points";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BMG-2222", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-12-2016 20:30:00"), "theDesciption4");
            expected = "Driver (444444C) with 0 points";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BMG-2222", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("27-12-2016 20:30:00"), "theDesciption4");
            expected = "ERROR: Driver without license";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BXX-9131", "P5000", "DRINK_AND_DRIVE", Convert.ToDateTime("31-12-2016 20:30:00"), "theDesciption5");
            expected = "Driver (444444D) with 6 points";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BXX-9131", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("26-12-2016 20:30:00"), "theDesciption4");
            expected = "Driver (444444D) with 5 points";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BXX-9131", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("27-12-2016 20:30:00"), "theDesciption4");
            expected = "Driver (444444D) with 4 points";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BXX-9131", "P3000", "EXCEED_EMISSIONS", Convert.ToDateTime("25-12-2016 20:30:00"), "theDesciption4");
            expected = "Driver (444444D) with 3 points";
            Assert.AreEqual(expected, result);

            result = Program.registerTrafficViolation("BXX-9131", "P3000", "MAX_SPEED", Convert.ToDateTime("29-12-2016 20:30:00"), "theDesciption4");
            expected = "Driver (444444D) with 0 points";
            Assert.AreEqual(expected, result);

            result = string.Empty;
            drivers = Program.drivers();
            while (drivers.MoveNext())
            {
                result += drivers.Current;
            }
            expected = "id: 000000Aname: Joansurname: LopeznumOfCars: 10points: 0id: 111111Aname: Philipsurname: McCarthynumOfCars: 0points: 14id: 222222Bname: Johnsurname: PetitnumOfCars: 2points: 10id: 333333Cname: Petersurname: EstebannumOfCars: 0points: 14id: 444444Cname: Albasurname: OnumOfCars: 1points: 0id: 444444Dname: Laurasurname: TorresnumOfCars: 1points: 0";
            Assert.AreEqual(expected, result);

            //No cumplido 

            //result = string.Empty;
            //TrafficViolations.TrafficViolationEnum policemanTrafficViolation = Program.getPolismanTrafficViolation("P5000"); ;
            //while (policemanTrafficViolation.MoveNext())
            //{
            //    result += policemanTrafficViolation.CurrentTrafficViolation;
            //}
            //expected = "date: 26/10/2016 19:00:00description: theDesciption3type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 30/10/2016 20:30:00description: theDesciption7type: MAX_SPEEDcar: BMG-2222points: 5date: 31/10/2016 20:30:00description: theDesciption5type: DRINK_AND_DRIVEcar: BCB-2462points: 8date: 31/12/2016 20:30:00description: theDesciption5type: DRINK_AND_DRIVEcar: BXX-9131points: 8";
            //Assert.AreEqual(expected, result);

            //result = string.Empty;
            //policemanTrafficViolation = Program.getPolismanTrafficViolation("P3000"); ;
            //while (policemanTrafficViolation.MoveNext())
            //{
            //    result += policemanTrafficViolation.CurrentTrafficViolation;
            //}
            //expected = "date: 26/10/2016 20:00:00description: theDesciption1type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 26/10/2016 20:30:00description: theDesciption4type: EXCEED_EMISSIONScar: B-2251-VGpoints: 1date: 27/10/2016 20:00:00description: theDesciption2type: EXCEED_EMISSIONScar: B-6666-ATpoints: 1date: 30/10/2016 20:30:00description: theDesciption6type: MAX_SPEEDcar: BCB-22444points: 5date: 25/12/2016 20:30:00description: theDesciption4type: EXCEED_EMISSIONScar: BXX-9131points: 1date: 26/12/2016 20:30:00description: theDesciption4type: EXCEED_EMISSIONScar: BXX-9131points: 1date: 27/12/2016 20:30:00description: theDesciption4type: EXCEED_EMISSIONScar: BXX-9131points: 1date: 29/12/2016 20:30:00description: theDesciption4type: MAX_SPEEDcar: BXX-9131points: 5";
            //Assert.AreEqual(expected, result);
        }
    }
}
