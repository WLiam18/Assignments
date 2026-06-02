using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Appointment> appointmentList =
            new List<Appointment>()
            {

                new Appointment()
                {
                    AppointmentId=201,
                    PatientName="Liam",
                    DoctorName="Dr Strange",
                    Department="Cardiology",
                    AppointmentDate=DateTime.Now.AddDays(3),
                    Status="Scheduled",
                    ConsultationFee=700
                },

                new Appointment()
                {
                    AppointmentId=202,
                    PatientName="John",
                    DoctorName="Dr Adi",
                    Department="Neurology",
                    AppointmentDate=DateTime.Now.AddDays(-2),
                    Status="Completed",
                    ConsultationFee=900
                },

                new Appointment()
                {
                    AppointmentId=203,
                    PatientName="Karun",
                    DoctorName="Dr Arjun",
                    Department="Orthopedics",
                    AppointmentDate=DateTime.Now.AddDays(4),
                    Status="Scheduled",
                    ConsultationFee=450
                },

                new Appointment()
                {
                    AppointmentId=204,
                    PatientName="Joel",
                    DoctorName="Dr Ravi",
                    Department="Cardiology",
                    AppointmentDate=DateTime.Now.AddDays(-5),
                    Status="Completed",
                    ConsultationFee=800
                },

                new Appointment()
                {
                    AppointmentId=205,
                    PatientName="Akash",
                    DoctorName="Dr Surya",
                    Department="Dermatology",
                    AppointmentDate=DateTime.Now.AddDays(1),
                    Status="Scheduled",
                    ConsultationFee=650
                }

            };


            Console.WriteLine("All Appointments\n");

            foreach(var item in appointmentList)
            {
                Console.WriteLine(item.ShowAppointment());
            }


            Console.WriteLine("Scheduled Appointments\n");

            foreach(var item in appointmentList)
            {
                if(item.Status=="Scheduled")
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }


            Console.WriteLine("Completed Appointments\n");

            foreach(var item in appointmentList)
            {
                if(item.Status=="Completed")
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }


            Console.WriteLine("Appoinments from cardiology department\n");

            foreach(var item in appointmentList)
            {
                if(item.Department=="Cardiology")
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }


            Console.WriteLine("Appointments with consultation fee geater than 500\n");

            foreach(var item in appointmentList)
            {
                if(item.ConsultationFee>500)
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }


            Console.WriteLine("Appointments Sorted By Date\n");

            var sortedAppointments =
            appointmentList.OrderBy(a => a.AppointmentDate);

            foreach(var item in sortedAppointments)
            {
                Console.WriteLine(item.ShowAppointment());
            }


            Console.WriteLine("Search Appointment By Patient Name\n");

            string searchName = "Joel";

            foreach(var item in appointmentList)
            {
                if(item.PatientName.Contains(searchName))
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }


            Console.WriteLine("Appointments grouped by deepartment\n");

            var departmentGroups =
            appointmentList.GroupBy(a => a.Department);

            foreach(var group in departmentGroups)
            {
                Console.WriteLine($"Department : {group.Key}");

                foreach(var item in group)
                {
                    Console.WriteLine(item.ShowAppointment());
                }
            }


            Console.WriteLine("Appointment count by status\n");

            var statusGroups =
            appointmentList.GroupBy(a => a.Status);

            foreach(var group in statusGroups)
            {
                Console.WriteLine(
                $"{group.Key} : {group.Count()}");
            }


            decimal revenue = 0;

            foreach(var item in appointmentList)
            {
                if(item.Status=="Completed")
                {
                    revenue =
                    revenue + item.ConsultationFee;
                }
            }

            Console.WriteLine(
            $"\nTotal revenue from completed aappointments : ₹{revenue}");


            decimal averageFee =
            appointmentList.Average(a =>
            a.ConsultationFee);

            Console.WriteLine(
            $"\nAverage Consultation Fee : ₹{averageFee:F2}");



            Console.WriteLine(
            "\nUpcoming Appointments\n");

            foreach(var item in appointmentList)
            {
                if(item.AppointmentDate>DateTime.Now)
                {
                    Console.WriteLine(
                    item.ShowAppointment());
                }
            }

            Console.ReadKey();

        }
    }
}