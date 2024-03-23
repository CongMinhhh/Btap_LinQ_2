using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btap_LinQ_2
{
    class Program
    {
        private static List<Position> positions = new List<Position>
    {
        new Position(1, "Manager", new List<Employee>()),
        new Position(2, "Developer", new List<Employee>()),
        new Position(3, "Tester", new List<Employee>())
    };

        private static List<Department> departments = new List<Department>
    {
        new Department(1, "HR", new List<Employee>()),
        new Department(2, "IT", new List<Employee>()),
        new Department(3, "Marketing", new List<Employee>())
    };

        private static List<Employee> employees = new List<Employee>
    {
        new Employee(1, "Cong Minh", 18,departments[1], positions[1]),
        new Employee(2, "Quang", 20,departments[2], positions[2]),
        new Employee(3, "Viet Thang", 25,departments[0], positions[0])
    };
        static void Main(string[] args)
        {
            Setup();

            Console.WriteLine("Nhap ten nhan vien muon tim:");
            var searchByName = Console.ReadLine();
            var employee = employees.FirstOrDefault(e => e.Name.ToLower().Contains(searchByName.ToLower()));
            Console.WriteLine(employee is null ? "Khong tim thay nhan vien can tim!" : $"Tim thay nhan vien: {employee.Name}"  );

            Console.WriteLine("Nhap ten phong ban muon tim:");
            var searchByDepartment = Console.ReadLine();
            var department = departments.FirstOrDefault(d => d.Name.ToLower().Contains(searchByDepartment.ToLower()));
            Console.WriteLine(department is null ? "Khong tim thay phong ban can tim!" : $"Tim thay phong ban: {department.Name}"  );

            Console.WriteLine("Nhap ten vi tri muon tim:");
            var searchByPosition = Console.ReadLine();
            var position = positions.FirstOrDefault(p => p.Name.ToLower().Contains(searchByPosition.ToLower()));
            Console.WriteLine(position is null ? "Khon tim thay vi tri can tim!" : $"Tim thay vi tri: {position.Name}"  );

            Console.WriteLine("Nhap do tuoi ban muon tim kiem!");
            Console.WriteLine("Nhap do tuoi nho nhat:");
            var minAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap do tuoi lon nhat:");
            var maxAge = int.Parse(Console.ReadLine());
            var employeesByAge = employees.Where(e => e.Age >= minAge && e.Age <= maxAge).ToList();
            employeesByAge.ForEach(e => Console.WriteLine($"Tim thay nhan vien: {e.Name}, Age: {e.Age}"));

            Console.WriteLine("Nhap ten vi tri muon tim:");
            var positionName = Console.ReadLine();
            var employeesByPosition = employees
                .Where(e => e.Position.Name.ToLower().Contains(positionName.ToLower())).ToList();
            if (employeesByPosition.Count == 0)
                Console.WriteLine("Khong tim thay ten vi tri muon tim");
            else
                employeesByPosition.ForEach(e => Console.WriteLine($"Tim thay nhan vien: {e.Name}\n Vi tri: {e.Position.Name}"));

            Console.WriteLine("Nhap ten phong ban muon tim:");
            var departmentName = Console.ReadLine();
            var employeesByDepartment = employees
                .Where(e => e.Department.Name.ToLower().Contains(departmentName.ToLower())).ToList();
            if (employeesByDepartment.Count == 0)
                Console.WriteLine("Khong co nhan vien trong phong ban nay");
            else
                employeesByDepartment.ForEach(e => Console.WriteLine($"Tim thay nhan vien: {e.Name}\n Phong ban: {e.Department.Name}"));
            Console.ReadKey();
        }

        private static void Setup()
        {
            foreach (var employee in employees)
            {
                employee.Department.Employees.Add(employee);
                employee.Position.Employees.Add(employee);
            }
        }
    }
    }
}
